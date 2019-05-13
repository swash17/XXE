using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XXE_DataStructures;


namespace XXE_UserInterface
{
    public partial class frmOrigDest : Form
    {

        /**** Fields ****/
        NetworkData Network;
        List<ODdata> ODpairs;
        ProjectData Project;
        public static bool CellDataError = true;  //True if data have been successfully saved to the data structure
        public static bool DataSaved = false;
        public static bool DataCurrent = true;  //Used to track whether the user has made a change to a cell since the last data save

        //XXE_Calculations.FileInputOutput FileIO = new XXE_Calculations.FileInputOutput();

        public static bool IsOpen = false;

        string FileListingTitle = "XXE Network File";
        string RegistryDirectory = "Software\\XXE\\ProjectFiles";
        string RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
        string Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
        string InitialDirectory = Application.StartupPath;
        /**** Constructors ****/
        public frmOrigDest(ref NetworkData networkImport, ref List<ODdata> ODpairsImport,ProjectData ProjectImport)
        {
            InitializeComponent();

            Network = networkImport;
            ODpairs = ODpairsImport;
            Project = ProjectImport;
            IsOpen = true;
        }

        private void frmOrigDest_Load(object sender, EventArgs e)
        {
            // Attach DataGridView events to the corresponding event handlers.
            this.dgvODdata.CellValidating += new
                DataGridViewCellValidatingEventHandler(dgvODdata_CellValidating);
            this.dgvODdata.CellEndEdit += new
                DataGridViewCellEventHandler(dgvODdata_CellEndEdit);
            LoadODdata();
            
        }

        private void tsbSaveODdata_Click(object sender, EventArgs e)
        {
            bool DataSaved = SaveLinkData();
            if (DataSaved == true)
                MessageBox.Show("Data successfully saved.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //save OD data file
            FileListingTitle = "XXE OD Data File";
            RegistryDirectory = "Software\\XXE\\ProjectFiles";
            RegistryPathForStoredFilenames = "Software\\XXE\\ProjectFiles\\MostRecentlyUsedFiles";
            Filter = "OD Files (*.xml)|*.xml|All Files (*.*)|*.*";
            InitialDirectory = Application.StartupPath;
            string FileName = SwashWare_FileManagement.Main.GetFileNameForSave(Filter, RegistryDirectory, RegistryPathForStoredFilenames);
            if (FileName != "")
            {
                XXE_Calculations.FileInputOutput.WriteODdataFile(FileName, ODpairs);
                Project.ODfileName = FileName;
            }
        }

        private Boolean SaveLinkData()
        {
            ODpairs.Clear();
            ODpairs.Add(new ODdata());
            //write table values to the ODArr data structure
            Network.NumODrecords = 0;
            ODdata od;
            try
            {
                for (int i = 1; i <= dgvODdata.Rows.Count; i++)
                {
                    od = new ODdata();
                    od.OrigZone = Convert.ToInt32(dgvODdata.Rows[i - 1].Cells[0].Value); 
                    od.DestZone = Convert.ToInt32(dgvODdata.Rows[i - 1].Cells[1].Value); 
                    od.NumTrips = Convert.ToInt64(dgvODdata.Rows[i - 1].Cells[2].Value);
                    ODpairs.Add(od);
                    Network.NumODrecords++;
                    //ODpairs[i].OrigZone = Convert.ToInt32(dgvODdata.Rows[i - 1].Cells[0].Value);   //change to int16?
                    //ODpairs[i].DestZone = Convert.ToInt32(dgvODdata.Rows[i - 1].Cells[1].Value);   //change to int16?
                    //ODpairs[i].NumTrips = Convert.ToInt64(dgvODdata.Rows[i - 1].Cells[2].Value);   //change to int16?
                    //Network.NumODrecords++;
                }
                DataSaved = true;
                DataCurrent = false;
                return true;
            }
            catch
            {
                MessageBox.Show("Data cannot be saved. Check data entry cells with a yellow background and/or red font.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataSaved = false;
                DataCurrent = false;
                return false;
            }
        }

        private Boolean LoadODdata()
        {
            //LinkData[] LinkArr = new LinkData[20];
            if ((ODpairs == null) || (Network.NumODrecords == 0))
            {
                ODdata NewODpair = new ODdata();
                ODpairs.Add(NewODpair);
                dgvODdata.Rows.Add(1);
                return false;
            }
            else
            {
                try
                {
                    dgvODdata.Rows.Add(Network.NumODrecords);
                    for (int i = 1; i <= Network.NumODrecords; i++)
                    {
                        dgvODdata.Rows[i - 1].Cells[0].Value = ODpairs[i].OrigZone.ToString();
                        dgvODdata.Rows[i - 1].Cells[1].Value = ODpairs[i].DestZone.ToString();
                        dgvODdata.Rows[i - 1].Cells[2].Value = ODpairs[i].NumTrips.ToString();
                    }
                    dgvODdata.DefaultCellStyle.BackColor = Color.White;
                    dgvODdata.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    DataSaved = true;
                    DataCurrent = true;
                    return true;
                }
                catch
                {
                    MessageBox.Show("Invalid Input Data. Check your saved data file for invalid entries and try again.", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void dgvODdata_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validate the values input into the fields

            // Origin Zone must be a positive integer
            if (dgvODdata.Columns[e.ColumnIndex].Name == "OrigZone")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }

            // Destination Zone must be a positive integer
            if (dgvODdata.Columns[e.ColumnIndex].Name == "DestZone")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }

            // Number of Trips must be a positive integer
            if (dgvODdata.Columns[e.ColumnIndex].Name == "NumTrips")
            {
                if (!ValidateData.IsUInt16(e.FormattedValue.ToString()))
                //value is not a positive integer
                {
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
                    CellDataError = true;
                }
                else
                    CellDataError = false;
            }
        }

        private void dgvODdata_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDataError == false)
            {
                dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                dgvODdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvODdata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataCurrent = false;
        }

        private void dgvODdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgvODdata.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvODdata_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Paint the row number on the row header.
            // The using statement automatically disposes the brush.
            using (SolidBrush b = new SolidBrush(dgvODdata.RowHeadersDefaultCellStyle.ForeColor))
            {
                int RowNum = e.RowIndex + 1;   //RowIndex starts at zero
                e.Graphics.DrawString(RowNum.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void tsbDiscardODdataChanges_Click(object sender, EventArgs e)
        {
            //discard changes to table and unload form
            DialogResult DiagRes = MessageBox.Show("Close form without saving data?", "XXE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DiagRes == DialogResult.Yes)
            {
                CloseForm();
            }
        }

        private void tsbAddODrecord_Click(object sender, EventArgs e)
        {
            /*
            int NumODpairs = dgvODdata.Rows.Count;  //get number of entered OD pairs
            if (NumODpairs == 1600) //maximum, based on 40 traffic analysis zones (40^2 - 40 = 1360)
            {
                MessageBox.Show("The number of entered OD pairs is limited to a maximum of 1600.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            dgvODdata.Rows.Add(1);
            for (int i = 0; i < dgvODdata.Columns.Count; i++)
                dgvODdata.Rows[dgvODdata.Rows.Count-1].Cells[i].Style.BackColor = Color.Yellow;
            if (dgvODdata.Rows.Count > 1)
                tsbDeleteODrecord.Enabled = true;

            ODdata NewODpair = new ODdata();
            ODpairs.Add(NewODpair);
        }

        private void tsbInsertODrecord_Click(object sender, EventArgs e)
        {
            /*
            int NumODpairs = dgvODdata.Rows.Count;  //get number of entered OD pairs
            if (NumODpairs == 1600) //maximum, based on 40 traffic analysis zones (40^2 - 40 = 1360)
            {
                MessageBox.Show("The number of entered OD pairs is limited to a maximum of 1600.", "XXE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            try
            {
                //insert a new link between two current intersections
                int SelectedRow = dgvODdata.SelectedRows[0].Index;
                dgvODdata.Rows.Insert(SelectedRow, 1);
                if (dgvODdata.Rows.Count > 1)
                    tsbDeleteODrecord.Enabled = true;
                for (int i = 0; i < dgvODdata.Columns.Count; i++)
                    dgvODdata.Rows[SelectedRow].Cells[i].Style.BackColor = Color.Yellow;

                ODdata NewODpair = new ODdata();
                ODpairs.Insert(SelectedRow, NewODpair);
            }
            catch
            {
                MessageBox.Show("To insert a row, you must select a row by clicking on the row number on the left-hand side of the grid.  The new row will be inserted above this row selection.",
                    "Row Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDeleteODrecord_Click(object sender, EventArgs e)
        {
            try
            {
                //delete the intersection at the selected position
                int SelectedRow = dgvODdata.SelectedRows[0].Index;
                if (SelectedRow != dgvODdata.Rows.Count)
                    dgvODdata.Rows.RemoveAt(SelectedRow);
                if (dgvODdata.Rows.Count < 2)
                    tsbDeleteODrecord.Enabled = false;
            }
            catch
            {
                MessageBox.Show("To delete a row, you must select the link by clicking on the row number on the left-hand side of the grid.", "Row Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbLoadODdata_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "DAT Files (*.dat)|*.dat|XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                ODpairs.Clear();
                ODpairs.Add(new ODdata());
                XXE_Calculations.FileInputOutput.ReadODxmlFile(FileName, Network, ODpairs);
                Project.ODfileName = FileName;
                dgvODdata.Rows.Clear();
                for (int i = 1; i <= Network.NumODrecords; i++)
                {
                    object[] NewRow = new object[] { ODpairs[i].OrigZone, ODpairs[i].DestZone, ODpairs[i].NumTrips };
                    dgvODdata.Rows.Add(NewRow);
                }
            }
        }

        private void frmOrigDest_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ask user if they want to save the current data before closing form, if any data items have not been changed since last data save
            if (DataCurrent == false)
            {
                DialogResult DiagRes = MessageBox.Show("Save O-D data before closing? ", "XXE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DiagRes == DialogResult.Yes)
                {
                    bool DataSaved = SaveLinkData();
                    if (DataSaved == false)
                        e.Cancel = true;
                }
                else if (DiagRes == DialogResult.No)
                { }
                else if (DiagRes == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmOrigDest_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            MDImain.theMain.originDestinationDataToolStripMenuItem_Click(null, null);
            IsOpen = false;
            this.Dispose();
            //this.Hide();
        }

                        
               
    }
}