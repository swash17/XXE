namespace XXE_UserInterface
{
    partial class frmBrowser
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
            this.wbrDataFile = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbrDataFile
            // 
            this.wbrDataFile.Location = new System.Drawing.Point(12, 12);
            this.wbrDataFile.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrDataFile.Name = "wbrDataFile";
            this.wbrDataFile.Size = new System.Drawing.Size(871, 608);
            this.wbrDataFile.TabIndex = 0;
            this.wbrDataFile.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 676);
            this.Controls.Add(this.wbrDataFile);
            this.Name = "frmBrowser";
            this.Text = "Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrDataFile;
    }
}