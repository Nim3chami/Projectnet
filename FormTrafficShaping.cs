using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace projectnet
{
    public partial class FormTrafficShaping : Form
    {
        private const string RuleFilterPlaceholder = "Enter rule filter...";
        private const string LimitPlaceholder = "Enter limit (Mbps)...";

        private Dictionary<string, int> ruleLimits = new Dictionary<string, int>();
        private Dictionary<string, long> ruleUsage = new Dictionary<string, long>();
        private Dictionary<string, DateTime> ruleTimestamps = new Dictionary<string, DateTime>();
        private Dictionary<string, IntPtr> ruleHandles = new Dictionary<string, IntPtr>();
        private Dictionary<string, TokenBucket> ruleBuckets = new Dictionary<string, TokenBucket>();

        // Locks for thread-safe usage updates per rule
        private Dictionary<string, object> usageLocks = new Dictionary<string, object>();

        private List<Thread> captureThreads = new List<Thread>();

        public FormTrafficShaping()
        {
            InitializeComponent();

            SetPlaceholder(txtRuleFilter, RuleFilterPlaceholder);
            SetPlaceholder(txtLimit, LimitPlaceholder);

            txtRuleFilter.Enter += (s, e) => RemovePlaceholder(txtRuleFilter, RuleFilterPlaceholder);
            txtRuleFilter.Leave += (s, e) => SetPlaceholder(txtRuleFilter, RuleFilterPlaceholder);
            txtLimit.Enter += (s, e) => RemovePlaceholder(txtLimit, LimitPlaceholder);
            txtLimit.Leave += (s, e) => SetPlaceholder(txtLimit, LimitPlaceholder);

            timerUpdate.Start();
        }

        private void StartCaptureForRule(string rule)
        {
            Thread thread = new Thread(() =>
            {
                IntPtr handle;
                try
                {
                    handle = WinDivertSafe.Open(rule);
                    ruleHandles[rule] = handle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open WinDivert for rule '{rule}': {ex.Message}");
                    return;
                }

                while (true)
                {
                    byte[] packet = new byte[65535];
                    WinDivertAddress addr;
                    uint readLen;

                    if (!WinDivertSafe.TryReceive(handle, packet, out readLen, out addr) || readLen == 0)
                        continue;

                    if (ruleBuckets.TryGetValue(rule, out var bucket))
                    {
                        bool sent = false;
                        while (!sent)
                        {
                            if (bucket.TryConsume((int)readLen, out int delayMs))
                            {
                                WinDivertSafe.Send(handle, packet, readLen, addr);
                                // Thread-safe increment
                                lock (usageLocks[rule])
                                {
                                    ruleUsage[rule] += readLen;
                                }
                                sent = true;
                            }
                            else
                            {
                                Thread.Sleep(delayMs < 1 ? 1 : delayMs);
                            }
                        }
                    }
                    else
                    {
                        WinDivertSafe.Send(handle, packet, readLen, addr);
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
            captureThreads.Add(thread);
        }

        private void SetPlaceholder(TextBox tb, string text)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = text;
                tb.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox tb, string text)
        {
            if (tb.Text == text)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            string rule = txtRuleFilter.Text.Trim();
            string limitText = txtLimit.Text.Trim();

            if (string.IsNullOrEmpty(rule) || rule == RuleFilterPlaceholder ||
                !int.TryParse(limitText, out int limit) || limit <= 0)
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            if (ruleLimits.ContainsKey(rule))
            {
                MessageBox.Show("Rule already exists.");
                return;
            }

            try
            {
                IntPtr testHandle = WinDivertSafe.Open(rule);
                WinDivertSafe.Close(testHandle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid WinDivert filter: " + ex.Message);
                return;
            }

            ruleLimits[rule] = limit;
            ruleUsage[rule] = 0;
            ruleTimestamps[rule] = DateTime.Now;
            ruleBuckets[rule] = new TokenBucket(limit);
            usageLocks[rule] = new object();

            lstRules.Items.Add($"Rule: {rule} | Limit: {limit} Mbps | Usage: 0.00 Mbps");
            StartCaptureForRule(rule);

            txtRuleFilter.Text = "";
            txtLimit.Text = "";
            SetPlaceholder(txtRuleFilter, RuleFilterPlaceholder);
            SetPlaceholder(txtLimit, LimitPlaceholder);
        }

        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if (lstRules.SelectedIndex == -1)
            {
                MessageBox.Show("Select a rule to remove.");
                return;
            }

            string selected = lstRules.SelectedItem.ToString();
            int start = selected.IndexOf("Rule: ") + 6;
            int end = selected.IndexOf(" | Limit:");
            string rule = selected.Substring(start, end - start);

            ruleLimits.Remove(rule);
            ruleTimestamps.Remove(rule);
            ruleBuckets.Remove(rule);

            lock (usageLocks[rule])
            {
                ruleUsage.Remove(rule);
            }
            usageLocks.Remove(rule);

            if (ruleHandles.TryGetValue(rule, out var handle))
            {
                WinDivertSafe.Close(handle);
                ruleHandles.Remove(rule);
            }

            lstRules.Items.RemoveAt(lstRules.SelectedIndex);
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            foreach (var rule in ruleLimits.Keys.ToList())
            {
                if (!ruleTimestamps.ContainsKey(rule))
                    ruleTimestamps[rule] = DateTime.Now;

                var elapsed = (DateTime.Now - ruleTimestamps[rule]).TotalSeconds;
                if (elapsed >= 1)
                {
                    ruleTimestamps[rule] = DateTime.Now;

                    long usage;
                    lock (usageLocks[rule])
                    {
                        usage = ruleUsage.ContainsKey(rule) ? ruleUsage[rule] : 0;
                        ruleUsage[rule] = 0;  // reset inside lock
                    }

                    int limit = ruleLimits[rule];
                    double usageMbps = (usage * 8.0) / 1_000_000.0; // bytes to megabits

                    for (int i = 0; i < lstRules.Items.Count; i++)
                    {
                        if (lstRules.Items[i].ToString().Contains($"Rule: {rule}"))
                        {
                            lstRules.Items[i] = $"Rule: {rule} | Limit: {limit} Mbps | Usage: {usageMbps:F2} Mbps";
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            foreach (var handle in ruleHandles.Values)
            {
                WinDivertSafe.Close(handle);
            }

            foreach (var thread in captureThreads)
            {
                if (thread.IsAlive)
                {
                    try { thread.Abort(); } catch { }
                }
            }
        }

        private void btnPredefinedRules_Click(object sender, EventArgs e)
        {
            FormPredefinedRules predefinedForm = new FormPredefinedRules(this);
            predefinedForm.ShowDialog();
        }

        public void AddPredefinedRule(string filter, int limit)
        {
            if (ruleLimits.ContainsKey(filter))
                return;

            try
            {
                IntPtr testHandle = WinDivertSafe.Open(filter);
                WinDivertSafe.Close(testHandle);
            }
            catch
            {
                MessageBox.Show($"Invalid predefined rule: {filter}");
                return;
            }

            ruleLimits[filter] = limit;
            ruleUsage[filter] = 0;
            ruleTimestamps[filter] = DateTime.Now;
            ruleBuckets[filter] = new TokenBucket(limit);
            usageLocks[filter] = new object();

            lstRules.Items.Add($"Rule: {filter} | Limit: {limit} Mbps | Usage: 0.00 Mbps");
            StartCaptureForRule(filter);
        }
    }

    public class TokenBucket
    {
        private double tokens;
        private readonly double rateBytesPerSec;
        private DateTime lastUpdate;

        public TokenBucket(int mbpsLimit)
        {
            rateBytesPerSec = mbpsLimit * 125000; // 1 Mbps = 125000 bytes/sec
            tokens = rateBytesPerSec;
            lastUpdate = DateTime.Now;
        }

        public bool TryConsume(int bytes, out int delayMs)
        {
            lock (this)
            {
                var now = DateTime.Now;
                double elapsedSec = (now - lastUpdate).TotalSeconds;
                lastUpdate = now;

                tokens += elapsedSec * rateBytesPerSec;
                if (tokens > rateBytesPerSec)
                    tokens = rateBytesPerSec;

                if (tokens >= bytes)
                {
                    tokens -= bytes;
                    delayMs = 0;
                    return true;
                }
                else
                {
                    double deficit = bytes - tokens;
                    delayMs = (int)Math.Ceiling((deficit / rateBytesPerSec) * 1000);
                    tokens = 0;
                    return false;
                }
            }
        }
    }
}
