using System.Drawing;
using System.Windows.Forms;

namespace projectnet
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnStartStop;
        private Button btnTrafficShaping;
        private Button btnClearLog;
        private Button btnExportLog;
        private Button btnViewGraph;
        private TextBox txtFilterRules;
        private ListBox lstTrafficLog;
        private Label lblFilter;
        private Button btnContentFiltering;


        private void InitializeComponent()
        {
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnTrafficShaping = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.btnViewGraph = new System.Windows.Forms.Button();
            this.txtFilterRules = new System.Windows.Forms.TextBox();
            this.lstTrafficLog = new System.Windows.Forms.ListBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnContentFiltering = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.FlatAppearance.BorderSize = 0;
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartStop.ForeColor = System.Drawing.Color.White;
            this.btnStartStop.Location = new System.Drawing.Point(20, 20);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(259, 40);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start Monitoring";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnTrafficShaping
            // 
            this.btnTrafficShaping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnTrafficShaping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrafficShaping.FlatAppearance.BorderSize = 0;
            this.btnTrafficShaping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTrafficShaping.ForeColor = System.Drawing.Color.White;
            this.btnTrafficShaping.Location = new System.Drawing.Point(295, 20);
            this.btnTrafficShaping.Name = "btnTrafficShaping";
            this.btnTrafficShaping.Size = new System.Drawing.Size(240, 40);
            this.btnTrafficShaping.TabIndex = 1;
            this.btnTrafficShaping.Text = "Traffic Shaping";
            this.btnTrafficShaping.UseVisualStyleBackColor = false;
            this.btnTrafficShaping.Click += new System.EventHandler(this.btnTrafficShaping_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(1303, 20);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(140, 40);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnExportLog
            // 
            this.btnExportLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnExportLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLog.FlatAppearance.BorderSize = 0;
            this.btnExportLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportLog.ForeColor = System.Drawing.Color.White;
            this.btnExportLog.Location = new System.Drawing.Point(1167, 20);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(130, 40);
            this.btnExportLog.TabIndex = 5;
            this.btnExportLog.Text = "Export Log";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);
            // 
            // btnViewGraph
            // 
            this.btnViewGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.btnViewGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewGraph.FlatAppearance.BorderSize = 0;
            this.btnViewGraph.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewGraph.ForeColor = System.Drawing.Color.White;
            this.btnViewGraph.Location = new System.Drawing.Point(1011, 20);
            this.btnViewGraph.Name = "btnViewGraph";
            this.btnViewGraph.Size = new System.Drawing.Size(150, 40);
            this.btnViewGraph.TabIndex = 6;
            this.btnViewGraph.Text = "View Graph";
            this.btnViewGraph.UseVisualStyleBackColor = false;
            this.btnViewGraph.Click += new System.EventHandler(this.btnViewGraph_Click);
            // 
            // txtFilterRules
            // 
            this.txtFilterRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterRules.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFilterRules.Location = new System.Drawing.Point(75, 75);
            this.txtFilterRules.Name = "txtFilterRules";
            this.txtFilterRules.Size = new System.Drawing.Size(610, 30);
            this.txtFilterRules.TabIndex = 3;
            // 
            // lstTrafficLog
            // 
            this.lstTrafficLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTrafficLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstTrafficLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTrafficLog.Font = new System.Drawing.Font("Consolas", 10.8F);
            this.lstTrafficLog.ForeColor = System.Drawing.Color.LightGreen;
            this.lstTrafficLog.FormattingEnabled = true;
            this.lstTrafficLog.ItemHeight = 22;
            this.lstTrafficLog.Location = new System.Drawing.Point(20, 110);
            this.lstTrafficLog.Name = "lstTrafficLog";
            this.lstTrafficLog.Size = new System.Drawing.Size(1423, 618);
            this.lstTrafficLog.TabIndex = 4;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilter.ForeColor = System.Drawing.Color.LightGray;
            this.lblFilter.Location = new System.Drawing.Point(20, 78);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(51, 23);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Filter:";
            // 
            // btnContentFiltering
            // 
            this.btnContentFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContentFiltering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnContentFiltering.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContentFiltering.FlatAppearance.BorderSize = 0;
            this.btnContentFiltering.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnContentFiltering.ForeColor = System.Drawing.Color.White;
            this.btnContentFiltering.Location = new System.Drawing.Point(550, 20);
            this.btnContentFiltering.Name = "btnContentFiltering";
            this.btnContentFiltering.Size = new System.Drawing.Size(221, 40);
            this.btnContentFiltering.TabIndex = 7;
            this.btnContentFiltering.Text = "Content Filtering";
            this.btnContentFiltering.UseVisualStyleBackColor = false;
            this.btnContentFiltering.Click += new System.EventHandler(this.btnContentFiltering_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1469, 766);
            this.Controls.Add(this.btnContentFiltering);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnTrafficShaping);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnExportLog);
            this.Controls.Add(this.btnViewGraph);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtFilterRules);
            this.Controls.Add(this.lstTrafficLog);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "Form1";
            this.Text = "Traffic Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
