namespace XXE_UserInterface
{
    partial class frmAnalParm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConvCrit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxIter = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumNodes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstNetworkNode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrintCentroids = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Convergence Criterion";
            // 
            // txtConvCrit
            // 
            this.txtConvCrit.Location = new System.Drawing.Point(191, 17);
            this.txtConvCrit.Name = "txtConvCrit";
            this.txtConvCrit.Size = new System.Drawing.Size(53, 20);
            this.txtConvCrit.TabIndex = 1;
            this.txtConvCrit.Text = "0.0005";
            this.txtConvCrit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum Number of Iterations";
            // 
            // txtMaxIter
            // 
            this.txtMaxIter.Location = new System.Drawing.Point(191, 43);
            this.txtMaxIter.Name = "txtMaxIter";
            this.txtMaxIter.Size = new System.Drawing.Size(53, 20);
            this.txtMaxIter.TabIndex = 3;
            this.txtMaxIter.Text = "25";
            this.txtMaxIter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumNodes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFirstNetworkNode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Info (temporary)";
            // 
            // txtNumNodes
            // 
            this.txtNumNodes.Location = new System.Drawing.Point(177, 55);
            this.txtNumNodes.Name = "txtNumNodes";
            this.txtNumNodes.Size = new System.Drawing.Size(53, 20);
            this.txtNumNodes.TabIndex = 3;
            this.txtNumNodes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Number of Nodes";
            // 
            // txtFirstNetworkNode
            // 
            this.txtFirstNetworkNode.Location = new System.Drawing.Point(177, 24);
            this.txtFirstNetworkNode.Name = "txtFirstNetworkNode";
            this.txtFirstNetworkNode.Size = new System.Drawing.Size(53, 20);
            this.txtFirstNetworkNode.TabIndex = 1;
            this.txtFirstNetworkNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Network Node";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrintCentroids);
            this.groupBox2.Location = new System.Drawing.Point(15, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 80);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Options";
            // 
            // chkPrintCentroids
            // 
            this.chkPrintCentroids.AutoSize = true;
            this.chkPrintCentroids.Location = new System.Drawing.Point(57, 24);
            this.chkPrintCentroids.Name = "chkPrintCentroids";
            this.chkPrintCentroids.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPrintCentroids.Size = new System.Drawing.Size(146, 17);
            this.chkPrintCentroids.TabIndex = 1;
            this.chkPrintCentroids.Text = "Print Centroid Connectors";
            this.chkPrintCentroids.UseVisualStyleBackColor = true;
            this.chkPrintCentroids.CheckedChanged += new System.EventHandler(this.chkPrintCentroids_CheckedChanged);
            // 
            // frmAnalParm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 300);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMaxIter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConvCrit);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnalParm";
            this.Text = "Analysis Parameters";
            this.Load += new System.EventHandler(this.frmAnalParm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConvCrit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxIter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFirstNetworkNode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumNodes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPrintCentroids;
    }
}