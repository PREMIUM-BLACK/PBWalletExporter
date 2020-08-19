namespace PBWalletExporter
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bnShow = new System.Windows.Forms.Button();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bnGetPublicKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.bnShowAdresses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(23, 582);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(624, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Huge thanks to NBitcoin (https://github.com/MetacoSA/NBitcoin) and NEthereum (htt" +
    "ps://github.com/Nethereum/Nethereum)";
            // 
            // txtWords
            // 
            this.txtWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWords.Location = new System.Drawing.Point(23, 164);
            this.txtWords.Multiline = true;
            this.txtWords.Name = "txtWords";
            this.txtWords.PasswordChar = '#';
            this.txtWords.Size = new System.Drawing.Size(624, 82);
            this.txtWords.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fill in your Mnemonic (12 or more words)";
            // 
            // bnShow
            // 
            this.bnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnShow.Location = new System.Drawing.Point(546, 252);
            this.bnShow.Name = "bnShow";
            this.bnShow.Size = new System.Drawing.Size(101, 23);
            this.bnShow.TabIndex = 4;
            this.bnShow.Text = "Show";
            this.bnShow.UseVisualStyleBackColor = true;
            this.bnShow.Click += new System.EventHandler(this.bnShow_Click);
            this.bnShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnShow_MouseDown);
            this.bnShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnShow_MouseUp);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "Bitcoin",
            "Ethereum",
            "Litecoin",
            "Litecoin (Ltub)",
            "DASH",
            "DASH (drkp)"});
            this.cmbCurrency.Location = new System.Drawing.Point(23, 321);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(144, 23);
            this.cmbCurrency.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Choose your currency";
            // 
            // bnGetPublicKey
            // 
            this.bnGetPublicKey.Location = new System.Drawing.Point(23, 361);
            this.bnGetPublicKey.Name = "bnGetPublicKey";
            this.bnGetPublicKey.Size = new System.Drawing.Size(144, 23);
            this.bnGetPublicKey.TabIndex = 6;
            this.bnGetPublicKey.Text = "Get Public Key";
            this.bnGetPublicKey.UseVisualStyleBackColor = true;
            this.bnGetPublicKey.Click += new System.EventHandler(this.bnGetPublicKey_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Your Public Key";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicKey.Location = new System.Drawing.Point(23, 442);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(624, 50);
            this.txtPublicKey.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(23, 504);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(37, 15);
            this.lblPath.TabIndex = 7;
            this.lblPath.Text = "Path: ";
            // 
            // bnShowAdresses
            // 
            this.bnShowAdresses.Location = new System.Drawing.Point(23, 522);
            this.bnShowAdresses.Name = "bnShowAdresses";
            this.bnShowAdresses.Size = new System.Drawing.Size(142, 23);
            this.bnShowAdresses.TabIndex = 8;
            this.bnShowAdresses.Text = "Show first addresses";
            this.bnShowAdresses.UseVisualStyleBackColor = true;
            this.bnShowAdresses.Click += new System.EventHandler(this.bnShowAdresses_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 633);
            this.Controls.Add(this.bnShowAdresses);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.bnGetPublicKey);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.bnShow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "PREMIUM BLACK Wallet Exporter Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnShow;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnGetPublicKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button bnShowAdresses;
    }
}

