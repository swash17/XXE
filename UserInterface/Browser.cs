using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XXE_UserInterface
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();

        }

        public void DisplayFileInBrowswer(string filename)
        {
            
            //wbrDataFile.Url = "G:\test2.xml";
            //wbrDataFile.Url = "http://www.espn.com";

            wbrDataFile.Navigate(filename);

        }
    }
}