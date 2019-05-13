using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XXE_DataStructures;


namespace XXE_UserInterface
{
    public partial class frmLinkTimePerData : Form
    {

        /**** Fields ****/
        public NetworkData Network;
        private List<LinkData> Links;
        public TimePeriodData[] tpdArr;

        public static bool IsOpen = false;

        public frmLinkTimePerData(NetworkData NetworkImport, List<LinkData> LinkArrImport)
        {
            InitializeComponent();

            Network = NetworkImport;
            Links = LinkArrImport;
            this.tpdArr = new TimePeriodData[24];
            for (int i = 0; i < 24; i++)
                tpdArr[i] = new TimePeriodData();

            IsOpen = true;
        }

        public TimePeriodData[] ShowDialog(int rowIndex, int fromNode, int toNode, IWin32Window parent)
        {
            // Put the customer id in the window title.
            this.Text = "Link # " + rowIndex + ": " + " From node " + fromNode + " to node " + toNode;

            PopulateDataGridView(Links, rowIndex);

            // Show the dialog.
            this.ShowDialog(parent);
            return this.tpdArr;
        }

        private void PopulateDataGridView(List<LinkData> Link, int linkNum)
        {
            // Add a row for each time period.
            dgvTimePerData.Rows.Add(Network.NumTimePeriods);
            for (int timePer = 1; timePer <= dgvTimePerData.Rows.Count; timePer++)
            {
                dgvTimePerData.Rows[timePer-1].Cells[0].Value = timePer;
                if (Link[linkNum].TimePerData == true)
                {
                    tpdArr[timePer].PropCap = Link[linkNum].PropCap[timePer];
                    dgvTimePerData.Rows[timePer-1].Cells[1].Value = tpdArr[timePer].PropCap.ToString("0.00");
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //write table values to the time period data array
            for (int i = 1; i <= dgvTimePerData.Rows.Count; i++)
            {
                tpdArr[i].TimePer = Convert.ToInt32(dgvTimePerData.Rows[i - 1].Cells[0].Value);      //change to int16?
                tpdArr[i].PropCap = Convert.ToDouble(dgvTimePerData.Rows[i - 1].Cells[1].Value);
            }
            CloseForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void dgvTimePerData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Paint the row number on the row header.
            // The using statement automatically disposes the brush.
            using (SolidBrush b = new SolidBrush(dgvTimePerData.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void frmLinkTimePerData_FormClosed(object sender, FormClosedEventArgs e)
        {
                CloseForm();
        }

        private void CloseForm()
        {
            IsOpen = false;
            //linkDataToolStripMenuItem.Checked = false;
            this.Dispose();
            //this.Hide();
        }


    }

    
}