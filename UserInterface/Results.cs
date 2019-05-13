using System;
using System.Windows.Forms;
using System.IO;
using XXE_DataStructures;


namespace XXE_UserInterface
{
    public partial class frmResults : Form
    {

        TimePeriod timePeriodType;

        public frmResults(TimePeriod timePeriodTypeImport)
        {
            InitializeComponent();

            timePeriodType = timePeriodTypeImport;
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            OpenResultsFile();

        }

        public void OpenResultsFile()
        {
            string OutputStream;
            string OutputFilename;

            // create reader & open file
            //StreamReader sr = File.OpenText("H:\\My Documents\\Research\\XXE\\OT.out");
            
            if(timePeriodType == TimePeriod.Single)
                OutputFilename = "results.txt";
            else
                OutputFilename = "results.txt";     //"resultsTP.txt";
            
            StreamReader sr = new StreamReader(Application.StartupPath + "\\" + OutputFilename);

            try
            {
                OutputStream = sr.ReadToEnd();
                this.rtbResults.Text = OutputStream;
                sr.Close();
            }
            catch
            {
                this.rtbResults.Text = "File not found";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        private void frmResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}