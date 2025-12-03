namespace projectnet
{
    partial class FormContentFiltering
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.CheckBox chkSocial;
        private System.Windows.Forms.CheckBox chkAdult;
        private System.Windows.Forms.CheckBox chkViolence;

        private System.Windows.Forms.Panel panelManualBlock;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.ListBox lstBlockedUrls;
        private System.Windows.Forms.Button btnRemoveUrl;

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnStartFiltering;
        private System.Windows.Forms.Button btnStopFiltering;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.chkSocial = new System.Windows.Forms.CheckBox();
            this.chkAdult = new System.Windows.Forms.CheckBox();
            this.chkViolence = new System.Windows.Forms.CheckBox();
            this.panelManualBlock = new System.Windows.Forms.Panel();
            this.lblManual = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.lstBlockedUrls = new System.Windows.Forms.ListBox();
            this.btnRemoveUrl = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnStartFiltering = new System.Windows.Forms.Button();
            this.btnStopFiltering = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();

            this.panelTop.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelManualBlock.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSubtitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(30);
            this.panelTop.Size = new System.Drawing.Size(750, 120);
            this.panelTop.TabIndex = 3;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(316, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Content Filtering";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblSubtitle.Location = new System.Drawing.Point(32, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(363, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Block social media, adult & violent websites";

            // panelOptions
            this.panelOptions.BackColor = System.Drawing.Color.FromArgb(60, 60, 64);
            this.panelOptions.Controls.Add(this.chkSocial);
            this.panelOptions.Controls.Add(this.chkAdult);
            this.panelOptions.Controls.Add(this.chkViolence);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOptions.Location = new System.Drawing.Point(0, 120);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.panelOptions.Size = new System.Drawing.Size(750, 70);
            this.panelOptions.TabIndex = 2;

            // chkSocial
            this.chkSocial.AutoSize = true;
            this.chkSocial.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkSocial.ForeColor = System.Drawing.Color.White;
            this.chkSocial.Location = new System.Drawing.Point(30, 20);
            this.chkSocial.Name = "chkSocial";
            this.chkSocial.Size = new System.Drawing.Size(192, 29);
            this.chkSocial.TabIndex = 0;
            this.chkSocial.Text = "Block Social Media";

            // chkAdult
            this.chkAdult.AutoSize = true;
            this.chkAdult.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkAdult.ForeColor = System.Drawing.Color.White;
            this.chkAdult.Location = new System.Drawing.Point(250, 20);
            this.chkAdult.Name = "chkAdult";
            this.chkAdult.Size = new System.Drawing.Size(201, 29);
            this.chkAdult.TabIndex = 1;
            this.chkAdult.Text = "Block Adult Content";

            // chkViolence
            this.chkViolence.AutoSize = true;
            this.chkViolence.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkViolence.ForeColor = System.Drawing.Color.White;
            this.chkViolence.Location = new System.Drawing.Point(481, 20);
            this.chkViolence.Name = "chkViolence";
            this.chkViolence.Size = new System.Drawing.Size(216, 29);
            this.chkViolence.TabIndex = 2;
            this.chkViolence.Text = "Block Violent Content";

            // panelManualBlock
            this.panelManualBlock.BackColor = System.Drawing.Color.FromArgb(50, 50, 52);
            this.panelManualBlock.Controls.Add(this.lblManual);
            this.panelManualBlock.Controls.Add(this.txtUrl);
            this.panelManualBlock.Controls.Add(this.btnAddUrl);
            this.panelManualBlock.Controls.Add(this.lstBlockedUrls);
            this.panelManualBlock.Controls.Add(this.btnRemoveUrl);
            this.panelManualBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelManualBlock.Location = new System.Drawing.Point(0, 190);
            this.panelManualBlock.Name = "panelManualBlock";
            this.panelManualBlock.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.panelManualBlock.Size = new System.Drawing.Size(750, 180);
            this.panelManualBlock.TabIndex = 5;

            // lblManual
            this.lblManual.AutoSize = true;
            this.lblManual.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblManual.ForeColor = System.Drawing.Color.White;
            this.lblManual.Location = new System.Drawing.Point(30, 10);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(250, 25);
            this.lblManual.TabIndex = 0;
            this.lblManual.Text = "Manually Block Specific URLs";

            // txtUrl
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUrl.Location = new System.Drawing.Point(35, 45);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(440, 30);
            this.txtUrl.TabIndex = 1;

            // btnAddUrl
            this.btnAddUrl.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAddUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddUrl.ForeColor = System.Drawing.Color.White;
            this.btnAddUrl.Location = new System.Drawing.Point(490, 43);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(100, 33);
            this.btnAddUrl.TabIndex = 2;
            this.btnAddUrl.Text = "Add";
            this.btnAddUrl.UseVisualStyleBackColor = false;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);

            // lstBlockedUrls
            this.lstBlockedUrls.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lstBlockedUrls.ForeColor = System.Drawing.Color.White;
            this.lstBlockedUrls.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstBlockedUrls.FormattingEnabled = true;
            this.lstBlockedUrls.ItemHeight = 20;
            this.lstBlockedUrls.Location = new System.Drawing.Point(35, 85);
            this.lstBlockedUrls.Name = "lstBlockedUrls";
            this.lstBlockedUrls.Size = new System.Drawing.Size(555, 84);
            this.lstBlockedUrls.TabIndex = 3;

            // btnRemoveUrl
            this.btnRemoveUrl.BackColor = System.Drawing.Color.FromArgb(196, 0, 0);
            this.btnRemoveUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveUrl.ForeColor = System.Drawing.Color.White;
            this.btnRemoveUrl.Location = new System.Drawing.Point(600, 125);
            this.btnRemoveUrl.Name = "btnRemoveUrl";
            this.btnRemoveUrl.Size = new System.Drawing.Size(110, 35);
            this.btnRemoveUrl.TabIndex = 4;
            this.btnRemoveUrl.Text = "Remove";
            this.btnRemoveUrl.UseVisualStyleBackColor = false;
            this.btnRemoveUrl.Click += new System.EventHandler(this.btnRemoveUrl_Click);

            // panelControls
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.panelControls.Controls.Add(this.btnStartFiltering);
            this.panelControls.Controls.Add(this.btnStopFiltering);
            this.panelControls.Controls.Add(this.lblStatus);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 370);
            this.panelControls.Name = "panelControls";
            this.panelControls.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.panelControls.Size = new System.Drawing.Size(750, 60);
            this.panelControls.TabIndex = 1;

            // btnStartFiltering
            this.btnStartFiltering.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnStartFiltering.FlatAppearance.BorderSize = 0;
            this.btnStartFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartFiltering.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStartFiltering.ForeColor = System.Drawing.Color.White;
            this.btnStartFiltering.Location = new System.Drawing.Point(30, 10);
            this.btnStartFiltering.Name = "btnStartFiltering";
            this.btnStartFiltering.Size = new System.Drawing.Size(140, 40);
            this.btnStartFiltering.TabIndex = 0;
            this.btnStartFiltering.Text = "Start Filtering";
            this.btnStartFiltering.UseVisualStyleBackColor = false;
            this.btnStartFiltering.Click += new System.EventHandler(this.btnStartFiltering_Click);

            // btnStopFiltering
            this.btnStopFiltering.BackColor = System.Drawing.Color.FromArgb(196, 0, 0);
            this.btnStopFiltering.FlatAppearance.BorderSize = 0;
            this.btnStopFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopFiltering.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStopFiltering.ForeColor = System.Drawing.Color.White;
            this.btnStopFiltering.Location = new System.Drawing.Point(190, 10);
            this.btnStopFiltering.Name = "btnStopFiltering";
            this.btnStopFiltering.Size = new System.Drawing.Size(140, 40);
            this.btnStopFiltering.TabIndex = 1;
            this.btnStopFiltering.Text = "Stop Filtering";
            this.btnStopFiltering.UseVisualStyleBackColor = false;
            this.btnStopFiltering.Click += new System.EventHandler(this.btnStopFiltering_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.LightGray;
            this.lblStatus.Location = new System.Drawing.Point(360, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: Idle";

            // txtLog
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtLog.Location = new System.Drawing.Point(0, 430);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(750, 200);
            this.txtLog.TabIndex = 0;

            // FormContentFiltering
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(750, 630);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelManualBlock);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormContentFiltering";
            this.Text = "Content Filtering";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelManualBlock.ResumeLayout(false);
            this.panelManualBlock.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
