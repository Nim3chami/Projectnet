using System.Windows.Forms;

namespace projectnet
{
    partial class FormTrafficShaping
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRuleFilter;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.ListBox lstRules;
        private System.Windows.Forms.Button btnRemoveRule;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label lblRuleFilter;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Button btnPredefinedRules; 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtRuleFilter = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.lstRules = new System.Windows.Forms.ListBox();
            this.btnRemoveRule = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblRuleFilter = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.btnPredefinedRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRuleFilter
            // 
            this.txtRuleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtRuleFilter.Location = new System.Drawing.Point(110, 15);
            this.txtRuleFilter.Name = "txtRuleFilter";
            this.txtRuleFilter.Size = new System.Drawing.Size(329, 28);
            this.txtRuleFilter.TabIndex = 4;
            // 
            // txtLimit
            // 
            this.txtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtLimit.Location = new System.Drawing.Point(555, 15);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(165, 28);
            this.txtLimit.TabIndex = 3;
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddRule.ForeColor = System.Drawing.Color.White;
            this.btnAddRule.Location = new System.Drawing.Point(810, 16);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(110, 33);
            this.btnAddRule.TabIndex = 2;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = false;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // lstRules
            // 
            this.lstRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstRules.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstRules.ForeColor = System.Drawing.Color.LightGreen;
            this.lstRules.FormattingEnabled = true;
            this.lstRules.ItemHeight = 28;
            this.lstRules.Location = new System.Drawing.Point(15, 60);
            this.lstRules.Name = "lstRules";
            this.lstRules.Size = new System.Drawing.Size(905, 340);
            this.lstRules.TabIndex = 1;
            // 
            // btnRemoveRule
            // 
            this.btnRemoveRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveRule.ForeColor = System.Drawing.Color.White;
            this.btnRemoveRule.Location = new System.Drawing.Point(780, 430);
            this.btnRemoveRule.Name = "btnRemoveRule";
            this.btnRemoveRule.Size = new System.Drawing.Size(140, 38);
            this.btnRemoveRule.TabIndex = 0;
            this.btnRemoveRule.Text = "Remove Rule";
            this.btnRemoveRule.UseVisualStyleBackColor = false;
            this.btnRemoveRule.Click += new System.EventHandler(this.btnRemoveRule_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // lblRuleFilter
            // 
            this.lblRuleFilter.AutoSize = true;
            this.lblRuleFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRuleFilter.ForeColor = System.Drawing.Color.White;
            this.lblRuleFilter.Location = new System.Drawing.Point(12, 15);
            this.lblRuleFilter.Name = "lblRuleFilter";
            this.lblRuleFilter.Size = new System.Drawing.Size(100, 25);
            this.lblRuleFilter.TabIndex = 6;
            this.lblRuleFilter.Text = "Rule Filter:";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLimit.ForeColor = System.Drawing.Color.White;
            this.lblLimit.Location = new System.Drawing.Point(475, 16);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(57, 25);
            this.lblLimit.TabIndex = 7;
            this.lblLimit.Text = "Limit:";
            // 
            // btnPredefinedRules
            // 
            this.btnPredefinedRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPredefinedRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnPredefinedRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredefinedRules.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPredefinedRules.ForeColor = System.Drawing.Color.White;
            this.btnPredefinedRules.Location = new System.Drawing.Point(15, 430);
            this.btnPredefinedRules.Name = "btnPredefinedRules";
            this.btnPredefinedRules.Size = new System.Drawing.Size(195, 33);
            this.btnPredefinedRules.TabIndex = 8;
            this.btnPredefinedRules.Text = "Predefined Rules";
            this.btnPredefinedRules.UseVisualStyleBackColor = false;
            this.btnPredefinedRules.Click += new System.EventHandler(this.btnPredefinedRules_Click);
            // 
            // FormTrafficShaping
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(935, 480);
            this.Controls.Add(this.btnPredefinedRules);
            this.Controls.Add(this.lblRuleFilter);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.txtRuleFilter);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.lstRules);
            this.Controls.Add(this.btnRemoveRule);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FormTrafficShaping";
            this.Text = "Traffic Shaping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
