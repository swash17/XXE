using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XXE_DataStructures;

namespace XXE_UserInterface
{
    public partial class ODresults : Form
    {
        List<UserEquilibriumTimePeriodResult> myResults;
        int TPindex = 0;
        int ODindex = 0;
        public ODresults(List<UserEquilibriumTimePeriodResult> resultsImport)
        {
            InitializeComponent();
            myResults = resultsImport;
            LoadComboBoxTpSet();
            LoadComboBoxODdataSet();
            UpdateDataGridView();
        }

        private void LoadComboBoxTpSet()
        {
            cboTimePeriod.Items.Clear();
            int numTP = myResults.Count;
            if (numTP > 0)
            {
                for(int tp =0; tp < numTP; tp++)
                {
                    cboTimePeriod.Items.Add(tp+1);
                }
                cboTimePeriod.SelectedItem = cboTimePeriod.Items[0];
            }
            
        }

        private void LoadComboBoxODdataSet()
        {
            cboODdataset.Items.Clear();
            int numOD = myResults[TPindex].ODResults.Count;
            if (numOD > 0)
            {
                for (int od = 0; od < numOD; od++)
                {
                    string origDest = myResults[TPindex].ODResults[od].Orig.ToString() + "-" + myResults[TPindex].ODResults[od].Dest.ToString();
                    cboODdataset.Items.Add(origDest);
                }
                cboODdataset.SelectedItem = cboODdataset.Items[0];
            }           
        }

        private void UpdateDataGridView()
        {
            dgvODresults.Rows.Clear();
            int numPath = myResults[TPindex].ODResults[ODindex].PathLists.Count;
            if (numPath > 0)
            {
                for (int path = 0; path < numPath; path++)
                {
                    dgvODresults.Rows.Add(1);
                    dgvODresults.Rows[path].Cells[colID.Name].Value = path + 1;
                    string pathNodes = "";

                    for (int node = 0; node < myResults[TPindex].ODResults[ODindex].PathLists[path].Count; node++)
                    {
                        if (node != myResults[TPindex].ODResults[ODindex].PathLists[path].Count - 1)
                        {
                            pathNodes += myResults[TPindex].ODResults[ODindex].PathLists[path][node].ToString() + "-";
                        }
                        else
                        {
                            pathNodes += myResults[TPindex].ODResults[ODindex].PathLists[path][node].ToString();
                        }
                    }

                    dgvODresults.Rows[path].Cells[colPathNodes.Name].Value = pathNodes;
                    string pathLinks = "";
                    double pathTravelTime = 0;
                    for (int node = 0; node < myResults[TPindex].ODResults[ODindex].PathLists[path].Count - 1; node++)
                    {
                        int linkFromNode = myResults[TPindex].ODResults[ODindex].PathLists[path][node];
                        int linkToNode = myResults[TPindex].ODResults[ODindex].PathLists[path][node + 1];
                        for (int link = 0; link < myResults[TPindex].LinkResults.Count; link++)
                        {
                            if (linkFromNode == myResults[TPindex].LinkResults[link].FromNode && linkToNode == myResults[TPindex].LinkResults[link].ToNode)
                            {
                                if (node != myResults[TPindex].ODResults[ODindex].PathLists[path].Count - 2)
                                {
                                    pathLinks += myResults[TPindex].LinkResults[link].ID.ToString() + "-";
                                }
                                else
                                {
                                    pathLinks += myResults[TPindex].LinkResults[link].ID.ToString();
                                }

                                pathTravelTime += myResults[TPindex].LinkResults[link].TravelTime;
                                break;
                            }
                        }
                    }
                    dgvODresults.Rows[path].Cells[colPathLinks.Name].Value = pathLinks;
                    dgvODresults.Rows[path].Cells[colPathTravelTime.Name].Value = pathTravelTime.ToString("0.00");
                }
            }
        }

        private void cboTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            TPindex = cboTimePeriod.SelectedIndex;
            UpdateDataGridView();
        }

        private void cboODdataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            ODindex = cboODdataset.SelectedIndex;
            UpdateDataGridView();
        }
    }
}
