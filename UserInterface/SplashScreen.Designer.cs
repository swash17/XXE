namespace XXE_UserInterface
{
    partial class frmSplashScreen
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.lblVersion2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenExistProj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartNewProj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(174, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 73);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "XXE";
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrip.Location = new System.Drawing.Point(56, 98);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(398, 29);
            this.lblDescrip.TabIndex = 2;
            this.lblDescrip.Text = "Network Travel Demand Analysis";
            // 
            // lblVersion2
            // 
            this.lblVersion2.AutoSize = true;
            this.lblVersion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion2.Location = new System.Drawing.Point(151, 190);
            this.lblVersion2.Name = "lblVersion2";
            this.lblVersion2.Size = new System.Drawing.Size(178, 24);
            this.lblVersion2.TabIndex = 3;
            this.lblVersion2.Text = "Version Date: 4/2/19";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenExistProj);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStartNewProj);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(61, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 134);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Startup Options";
            // 
            // btnOpenExistProj
            // 
            this.btnOpenExistProj.Location = new System.Drawing.Point(219, 65);
            this.btnOpenExistProj.Name = "btnOpenExistProj";
            this.btnOpenExistProj.Size = new System.Drawing.Size(140, 35);
            this.btnOpenExistProj.TabIndex = 3;
            this.btnOpenExistProj.Text = "Open an existing project";
            this.btnOpenExistProj.UseVisualStyleBackColor = true;
            this.btnOpenExistProj.Click += new System.EventHandler(this.btnOpenExistProj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "or";
            // 
            // btnStartNewProj
            // 
            this.btnStartNewProj.Location = new System.Drawing.Point(24, 65);
            this.btnStartNewProj.Name = "btnStartNewProj";
            this.btnStartNewProj.Size = new System.Drawing.Size(139, 35);
            this.btnStartNewProj.TabIndex = 1;
            this.btnStartNewProj.Text = "Start a new project";
            this.btnStartNewProj.UseVisualStyleBackColor = true;
            this.btnStartNewProj.Click += new System.EventHandler(this.btnStartNewProj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Would you like to...";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(196, 164);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(105, 24);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version 3.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XXE_UserInterface.Properties.Resources.SeattleFlowMap;
            this.pictureBox1.Location = new System.Drawing.Point(521, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 545);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(151, 287);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(191, 92);
            this.lblAuthor.TabIndex = 6;
            this.lblAuthor.Text = "by\r\nDr. Wei Sun\r\nDr. Scott Washburn \r\nDr. Fred Mannering\r\n";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyright.Location = new System.Drawing.Point(163, 236);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(159, 24);
            this.labelCopyright.TabIndex = 28;
            this.labelCopyright.Text = "Copyright ©  2007";
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 573);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblVersion2);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XXE";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label lblVersion2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenExistProj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartNewProj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label labelCopyright;
    }
}