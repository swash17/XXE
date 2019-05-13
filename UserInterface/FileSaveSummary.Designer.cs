namespace XXE_UserInterface
{
    partial class frmFileSaveSummary
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
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkODdata = new System.Windows.Forms.CheckBox();
            this.chkLinkData = new System.Windows.Forms.CheckBox();
            this.chkProjData = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(56, 127);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkODdata);
            this.groupBox1.Controls.Add(this.chkLinkData);
            this.groupBox1.Controls.Add(this.chkProjData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 109);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Items Saved to the File";
            // 
            // chkODdata
            // 
            this.chkODdata.AutoSize = true;
            this.chkODdata.Location = new System.Drawing.Point(15, 75);
            this.chkODdata.Name = "chkODdata";
            this.chkODdata.Size = new System.Drawing.Size(135, 17);
            this.chkODdata.TabIndex = 6;
            this.chkODdata.Text = "Origin-Destination Data";
            this.chkODdata.UseVisualStyleBackColor = true;
            // 
            // chkLinkData
            // 
            this.chkLinkData.AutoSize = true;
            this.chkLinkData.Location = new System.Drawing.Point(15, 52);
            this.chkLinkData.Name = "chkLinkData";
            this.chkLinkData.Size = new System.Drawing.Size(101, 17);
            this.chkLinkData.TabIndex = 5;
            this.chkLinkData.Text = "Link-Node Data";
            this.chkLinkData.UseVisualStyleBackColor = true;
            // 
            // chkProjData
            // 
            this.chkProjData.AutoSize = true;
            this.chkProjData.Location = new System.Drawing.Point(15, 29);
            this.chkProjData.Name = "chkProjData";
            this.chkProjData.Size = new System.Drawing.Size(149, 17);
            this.chkProjData.TabIndex = 4;
            this.chkProjData.Text = "Project and Network Data";
            this.chkProjData.UseVisualStyleBackColor = true;
            // 
            // frmFileSaveSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 169);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileSaveSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Save Summary";
            this.Load += new System.EventHandler(this.frmFileSaveSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkODdata;
        private System.Windows.Forms.CheckBox chkLinkData;
        private System.Windows.Forms.CheckBox chkProjData;
    }
}