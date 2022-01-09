namespace PBWalletExporter
{
    partial class frmExportAddresses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bnClose = new System.Windows.Forms.Button();
            this.txtAddresses = new System.Windows.Forms.TextBox();
            this.nudAddressCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bnExport = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAddIndexColumn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddressCount)).BeginInit();
            this.SuspendLayout();
            // 
            // bnClose
            // 
            this.bnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnClose.Location = new System.Drawing.Point(601, 339);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(103, 23);
            this.bnClose.TabIndex = 0;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // txtAddresses
            // 
            this.txtAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddresses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddresses.Location = new System.Drawing.Point(269, 13);
            this.txtAddresses.Multiline = true;
            this.txtAddresses.Name = "txtAddresses";
            this.txtAddresses.ReadOnly = true;
            this.txtAddresses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddresses.Size = new System.Drawing.Size(435, 320);
            this.txtAddresses.TabIndex = 1;
            // 
            // nudAddressCount
            // 
            this.nudAddressCount.Location = new System.Drawing.Point(164, 73);
            this.nudAddressCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAddressCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAddressCount.Name = "nudAddressCount";
            this.nudAddressCount.Size = new System.Drawing.Size(99, 23);
            this.nudAddressCount.TabIndex = 2;
            this.nudAddressCount.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudAddressCount.ValueChanged += new System.EventHandler(this.nudAddressCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Addresscount:";
            // 
            // bnExport
            // 
            this.bnExport.Location = new System.Drawing.Point(150, 162);
            this.bnExport.Name = "bnExport";
            this.bnExport.Size = new System.Drawing.Size(113, 23);
            this.bnExport.TabIndex = 4;
            this.bnExport.Text = "Export as CSV";
            this.bnExport.UseVisualStyleBackColor = true;
            this.bnExport.Click += new System.EventHandler(this.bnExport_Click);
            // 
            // sfd
            // 
            this.sfd.Filter = "CSV file *.csv|*.csv";
            this.sfd.Title = "Export address list";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(102, 32);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(161, 23);
            this.cmbCurrency.TabIndex = 6;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Currency:";
            // 
            // chkAddIndexColumn
            // 
            this.chkAddIndexColumn.AutoSize = true;
            this.chkAddIndexColumn.Checked = true;
            this.chkAddIndexColumn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddIndexColumn.Location = new System.Drawing.Point(102, 113);
            this.chkAddIndexColumn.Name = "chkAddIndexColumn";
            this.chkAddIndexColumn.Size = new System.Drawing.Size(126, 19);
            this.chkAddIndexColumn.TabIndex = 8;
            this.chkAddIndexColumn.Text = "Add Index Column";
            this.chkAddIndexColumn.UseVisualStyleBackColor = true;
            // 
            // frmExportAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 374);
            this.Controls.Add(this.chkAddIndexColumn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.bnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAddressCount);
            this.Controls.Add(this.txtAddresses);
            this.Controls.Add(this.bnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportAddresses";
            this.Text = "Export addresses";
            this.Load += new System.EventHandler(this.frmExportAddresses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAddressCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnClose;
        public System.Windows.Forms.TextBox txtAddresses;
        private System.Windows.Forms.NumericUpDown nudAddressCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnExport;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.CheckBox chkAddIndexColumn;
    }
}