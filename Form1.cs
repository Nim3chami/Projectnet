using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace projectnet
{
    public partial class Form1 : Form
    {
        private IntPtr handle;
        private Thread captureThread;
        private bool capturing = false;
        private long totalBytes = 0;

        public Form1()
        {
            InitializeComponent();
            txtFilterRules.Text = "true"; // Capture all packets
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!capturing)
            {
                StartMonitoring();
                btnStartStop.Text = "Stop Monitoring";
            }
            else
            {
                StopMonitoring();
                btnStartStop.Text = "Start Monitoring";
            }
        }

        private void btnTrafficShaping_Click(object sender, EventArgs e)
        {
            var shapingForm = new FormTrafficShaping();
            shapingForm.Show();
        }

        private void btnContentFiltering_Click(object sender, EventArgs e)
        {
            var filteringForm = new FormContentFiltering();
            filteringForm.Show();
        }


        private void btnViewGraph_Click(object sender, EventArgs e)
        {
            var chartForm = new FormBandwidthChart(() => Interlocked.Read(ref totalBytes));
            chartForm.Show();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstTrafficLog.Items.Clear();
        }

        private void StartMonitoring()
        {
            string filter = txtFilterRules.Text;
            handle = WinDivertAPI.WinDivertOpen(filter, 0, 0, 0);

            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open WinDivert. Run as Administrator.");
                return;
            }

            capturing = true;
            captureThread = new Thread(CapturePackets) { IsBackground = true };
            captureThread.Start();
        }

        private void StopMonitoring()
        {
            capturing = false;
            captureThread?.Join();
            WinDivertAPI.WinDivertClose(handle);
        }

        private void CapturePackets()
        {
            byte[] packet = new byte[65535];
            WinDivertAddress addr = new WinDivertAddress();

            while (capturing)
            {
                uint packetLen = (uint)packet.Length;
                bool success = WinDivertAPI.WinDivertRecv(handle, packet, packetLen, ref addr, ref packetLen);

                if (success && packetLen > 0)
                {
                    Interlocked.Add(ref totalBytes, packetLen);
                    string direction = addr.Direction == 0 ? "Inbound" : "Outbound";
                    string log;

                    try
                    {
                        log = ParsePacket(packet, packetLen, direction);
                    }
                    catch (Exception ex)
                    {
                        log = $"[Error parsing packet]: {ex.Message}";
                    }

                    BeginInvoke((Action)(() =>
                    {
                        lstTrafficLog.Items.Add(log);
                        lstTrafficLog.TopIndex = lstTrafficLog.Items.Count - 1;
                    }));
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        private string ParsePacket(byte[] packet, uint length, string direction)
        {
            if (length < 20) return "[Invalid packet]";

            int ipVersion = (packet[0] >> 4);
            if (ipVersion != 4)
            {
                int previewLength = (int)Math.Min(length, 20);
                string hex = BitConverter.ToString(packet, 0, previewLength);
                string ascii = new string(packet.Take(previewLength).Select(b => (b >= 32 && b <= 126) ? (char)b : '.').ToArray());

                byte potentialProto = packet.Length > 9 ? packet[9] : (byte)0;
                string timeStamp = DateTime.Now.ToString("HH:mm:ss");

                return $"[Non-IPv4] Version: {ipVersion} | Len: {length}B | Hex: {hex} | ASCII: {ascii} | ProtoByte[9]: 0x{potentialProto:X2} | Time: {timeStamp}";
            }

            int ihl = packet[0] & 0x0F;
            int ipHeaderLength = ihl * 4;
            byte tos = packet[1];
            ushort totalLength = (ushort)((packet[2] << 8) | packet[3]);
            ushort identification = (ushort)((packet[4] << 8) | packet[5]);
            ushort flagsOffset = (ushort)((packet[6] << 8) | packet[7]);
            byte ttl = packet[8];
            byte protocol = packet[9];
            ushort checksum = (ushort)((packet[10] << 8) | packet[11]);

            string srcIp = $"{packet[12]}.{packet[13]}.{packet[14]}.{packet[15]}";
            string dstIp = $"{packet[16]}.{packet[17]}.{packet[18]}.{packet[19]}";

            ushort srcPort = 0, dstPort = 0;
            string protoName = protocol == 1 ? "ICMP" : protocol == 6 ? "TCP" : protocol == 17 ? "UDP" : $"Prot#{protocol}";
            StringBuilder extras = new StringBuilder();

            if ((protocol == 6 || protocol == 17) && length >= ipHeaderLength + 4)
            {
                int portStart = ipHeaderLength;
                srcPort = (ushort)((packet[portStart] << 8) | packet[portStart + 1]);
                dstPort = (ushort)((packet[portStart + 2] << 8) | packet[portStart + 3]);

                if (protocol == 6 && length >= ipHeaderLength + 20)
                {
                    int tcpHeaderStart = ipHeaderLength;
                    byte flags = packet[tcpHeaderStart + 13];
                    uint seqNum = BitConverter.ToUInt32(packet, tcpHeaderStart + 4);
                    ushort window = (ushort)((packet[tcpHeaderStart + 14] << 8) | packet[tcpHeaderStart + 15]);

                    extras.Append($"| Seq: {seqNum} | Win: {window}");

                    int tcpHeaderLen = ((packet[tcpHeaderStart + 12] >> 4) & 0x0F) * 4;
                    int payloadStart = tcpHeaderStart + tcpHeaderLen;
                    int payloadLength = (int)length - payloadStart;

                    if (payloadLength > 0 && payloadStart < packet.Length)
                    {
                        string httpPayload = Encoding.ASCII.GetString(packet, payloadStart, Math.Min(512, packet.Length - payloadStart));
                        if (httpPayload.StartsWith("GET") || httpPayload.StartsWith("POST") || httpPayload.StartsWith("HTTP"))
                        {
                            string[] lines = httpPayload.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            string host = lines.FirstOrDefault(l => l.StartsWith("Host:")) ?? "";
                            string userAgent = lines.FirstOrDefault(l => l.StartsWith("User-Agent:")) ?? "";

                            return $"[{direction}] HTTP | {srcIp}:{srcPort} → {dstIp}:{dstPort} | {lines[0]} | {host} | {userAgent}";
                        }
                    }
                }

                if (protocol == 17 && (srcPort == 53 || dstPort == 53) && length >= ipHeaderLength + 12)
                {
                    int dnsStart = ipHeaderLength;
                    ushort txId = (ushort)((packet[dnsStart] << 8) | packet[dnsStart + 1]);
                    byte flagsHi = packet[dnsStart + 2];
                    bool isQuery = (flagsHi & 0x80) == 0;

                    int qdCount = (packet[dnsStart + 4] << 8) | packet[dnsStart + 5];
                    string queryName = "";

                    try
                    {
                        int offset = dnsStart + 12;
                        while (offset < length && packet[offset] != 0)
                        {
                            int labelLen = packet[offset++];
                            if (offset + labelLen >= length) break;
                            queryName += Encoding.ASCII.GetString(packet, offset, labelLen) + ".";
                            offset += labelLen;
                        }

                        if (queryName.EndsWith("."))
                            queryName = queryName.Substring(0, queryName.Length - 1);
                    }
                    catch { }

                    return $"[{direction}] DNS {(isQuery ? "Query" : "Response")} | TxID: 0x{txId:X4} | Qs: {qdCount} | Host: {queryName} | {srcIp}:{srcPort} → {dstIp}:{dstPort}";
                }
            }

            return $"[{direction}] {protoName} | {srcIp}:{srcPort} → {dstIp}:{dstPort} | TTL: {ttl} | Len: {totalLength}B | ID: {identification} | Checksum: 0x{checksum:X4} | TOS: 0x{tos:X2} | FragOffset: {flagsOffset & 0x1FFF}{extras}";
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            if (lstTrafficLog.Items.Count == 0)
            {
                MessageBox.Show("No logs to export.", "Export Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"TrafficLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                        {
                            foreach (var item in lstTrafficLog.Items)
                            {
                                writer.WriteLine(item.ToString());
                            }
                        }
                        MessageBox.Show("Log exported successfully!", "Export Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to export log: {ex.Message}", "Export Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
