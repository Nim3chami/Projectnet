using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace projectnet
{
    public partial class FormContentFiltering : Form
    {
        private List<string> socialDomains = new List<string>();
        private List<string> adultDomains = new List<string>();
        private List<string> violenceDomains = new List<string>();
        private List<string> manualDomains = new List<string>();

        private Thread filterThread;
        private bool isRunning = false;
        private string baseDir;

        public FormContentFiltering()
        {
            InitializeComponent();
            baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blocklists");
            LoadDomainLists();
            LoadManualToListbox();
        }

        private void LoadDomainLists()
        {
            socialDomains = LoadDomainsFromFile(Path.Combine(baseDir, "social.txt"));
            adultDomains = LoadDomainsFromFile(Path.Combine(baseDir, "adult.txt"));
            violenceDomains = LoadDomainsFromFile(Path.Combine(baseDir, "violence.txt"));
            manualDomains = LoadDomainsFromFile(Path.Combine(baseDir, "manual.txt"));
        }

        private List<string> LoadDomainsFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllLines(path)
                        .Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                        .Select(line => line.Trim().ToLower())
                        .Distinct()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading " + path + ":\n" + ex.Message);
            }
            return new List<string>();
        }

        private void SaveManualDomains()
        {
            try
            {
                string path = Path.Combine(baseDir, "manual.txt");
                Directory.CreateDirectory(baseDir);
                File.WriteAllLines(path, manualDomains.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving manual domains: " + ex.Message);
            }
        }

        private void LoadManualToListbox()
        {
            lstBlockedUrls.Items.Clear();
            foreach (var domain in manualDomains)
            {
                lstBlockedUrls.Items.Add(domain);
            }
        }

        // -----------------------------
        // Manual URL Management
        // -----------------------------
        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            string domain = txtUrl.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("Please enter a valid domain or URL.");
                return;
            }

            if (!manualDomains.Contains(domain))
            {
                manualDomains.Add(domain);
                SaveManualDomains();
                lstBlockedUrls.Items.Add(domain);
                txtLog.AppendText($"[+] Added manual block: {domain}\r\n");
                txtUrl.Clear();
            }
            else
            {
                MessageBox.Show("This domain is already in the block list.");
            }
        }

        private void btnRemoveUrl_Click(object sender, EventArgs e)
        {
            if (lstBlockedUrls.SelectedItem == null)
            {
                MessageBox.Show("Select a domain to remove.");
                return;
            }

            string selected = lstBlockedUrls.SelectedItem.ToString();
            manualDomains.Remove(selected);
            lstBlockedUrls.Items.Remove(selected);
            SaveManualDomains();
            txtLog.AppendText($"[-] Removed manual block: {selected}\r\n");
        }

        // -----------------------------
        // Filtering Controls
        // -----------------------------
        private void btnStartFiltering_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                filterThread = new Thread(FilterTraffic);
                filterThread.IsBackground = true;
                filterThread.Start();
                lblStatus.Text = "Status: Running";
                txtLog.AppendText(">>> Content filtering started...\r\n");
            }
        }

        private void btnStopFiltering_Click(object sender, EventArgs e)
        {
            isRunning = false;
            lblStatus.Text = "Status: Stopped";
            txtLog.AppendText(">>> Content filtering stopped.\r\n");
        }

        private void FilterTraffic()
        {
            string filter = "ip and tcp.DstPort == 80 or tcp.DstPort == 443";
            IntPtr handle = WinDivertAPI.WinDivertOpen(filter, 0, 0, 0);

            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open WinDivert.");
                return;
            }

            byte[] packet = new byte[65535];
            WinDivertAddress addr = new WinDivertAddress();
            addr.Reserved = new byte[60];

            while (isRunning)
            {
                uint readLen = 0;
                bool success = WinDivertAPI.WinDivertRecv(handle, packet, (uint)packet.Length, ref addr, ref readLen);

                if (!success || readLen == 0)
                    continue;

                string host = GetHostFromPacket(packet, (int)readLen);

                if (!string.IsNullOrEmpty(host) && ShouldBlock(host))
                {
                    txtLog.Invoke(new Action(() =>
                        txtLog.AppendText($"[BLOCKED] {host}\r\n")));
                    continue; // drop packet
                }

                uint sendLen = 0;
                WinDivertAPI.WinDivertSend(handle, packet, readLen, ref addr, ref sendLen);
            }

            WinDivertAPI.WinDivertClose(handle);
        }

        private bool ShouldBlock(string host)
        {
            host = host.ToLower();

            if (manualDomains.Any(d => host.Contains(d))) return true;
            if (chkSocial.Checked && socialDomains.Any(d => host.Contains(d))) return true;
            if (chkAdult.Checked && adultDomains.Any(d => host.Contains(d))) return true;
            if (chkViolence.Checked && violenceDomains.Any(d => host.Contains(d))) return true;

            return false;
        }

        private string GetHostFromPacket(byte[] packet, int length)
        {
            try
            {
                string payload = Encoding.UTF8.GetString(packet, 0, length);
                if (payload.Contains("Host:"))
                {
                    int start = payload.IndexOf("Host:") + 5;
                    int end = payload.IndexOf("\r\n", start);
                    if (start > 0 && end > start)
                        return payload.Substring(start, end - start).Trim();
                }
            }
            catch { }
            return null;
        }
    }
}
