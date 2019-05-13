using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XXE_UserInterface
{
    public partial class frmFileSaveSummary : Form
    {
        public frmFileSaveSummary()
        {
            InitializeComponent();

        }

        private void frmFileSaveSummary_Load(object sender, EventArgs e)
        {
            if (frmProjProp.DataSaved == true)
                chkProjData.Checked = true;
            else
                chkProjData.Checked = false;

            if (frmLinkData.DataSaved == true)
                chkLinkData.Checked = true;
            else
                chkLinkData.Checked = false;

            if (frmOrigDest.DataSaved == true)
                chkODdata.Checked = true;
            else
                chkODdata.Checked = false;

            //if (frmProjProp.DataSaved == false && frmLinkData.DataSaved == false && frmOrigDest.DataSaved == false)
            //    MessageBox.Show("The following data items were not saved to the file: \n Project and Network Data \n Link-Node Data \n Origin-Destination Data", "File Save Summary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}