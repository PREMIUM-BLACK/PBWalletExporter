namespace PBWalletExporter
{
    partial class frmSearch
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.bnSearch = new System.Windows.Forms.Button();
            this.nudPerPath = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pgrProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPathesToTry = new System.Windows.Forms.NumericUpDown();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPerPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPathesToTry)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(158, 39);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(263, 23);
            this.txtAddress.TabIndex = 0;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(31, 42);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(121, 15);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address to search for:";
            // 
            // bnSearch
            // 
            this.bnSearch.Location = new System.Drawing.Point(158, 153);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(106, 23);
            this.bnSearch.TabIndex = 2;
            this.bnSearch.Text = "Search path";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // nudPerPath
            // 
            this.nudPerPath.Location = new System.Drawing.Point(158, 113);
            this.nudPerPath.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPerPath.Name = "nudPerPath";
            this.nudPerPath.Size = new System.Drawing.Size(120, 23);
            this.nudPerPath.TabIndex = 3;
            this.nudPerPath.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Addresses per path:";
            // 
            // pgrProgress
            // 
            this.pgrProgress.Location = new System.Drawing.Point(158, 193);
            this.pgrProgress.Name = "pgrProgress";
            this.pgrProgress.Size = new System.Drawing.Size(263, 23);
            this.pgrProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgrProgress.TabIndex = 4;
            this.pgrProgress.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pathes to try:";
            // 
            // nudPathesToTry
            // 
            this.nudPathesToTry.Location = new System.Drawing.Point(158, 75);
            this.nudPathesToTry.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPathesToTry.Name = "nudPathesToTry";
            this.nudPathesToTry.Size = new System.Drawing.Size(120, 23);
            this.nudPathesToTry.TabIndex = 3;
            this.nudPathesToTry.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(158, 225);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 15);
            this.lblResult.TabIndex = 1;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 295);
            this.Controls.Add(this.pgrProgress);
            this.Controls.Add(this.nudPathesToTry);
            this.Controls.Add(this.nudPerPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnSearch);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search & Find";
            ((System.ComponentModel.ISupportInitialize)(this.nudPerPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPathesToTry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.NumericUpDown nudPerPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgrProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPathesToTry;
        private System.Windows.Forms.Label lblResult;
    }
}