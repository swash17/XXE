using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SwashStatistics_ChartingControl;
using XXE_DataStructures;
using System.Windows.Forms.DataVisualization.Charting;
using SwashStatistics_DescriptiveStatistics;
using HCMCalc_Definitions;


namespace XXE_UserInterface
{
    public partial class frmUEresultsFreewayfacilities : Form
    {
        ctrlDistributionDisplay ctrlResultsDisplay = new ctrlDistributionDisplay();
        SwashStatistics_ChartingControl.ChartSettings myChartSettings = new SwashStatistics_ChartingControl.ChartSettings();
        List<UserEquilibriumTimePeriodResult> myResults;
        List<FreewayData> myFreewayFacilities;
        bool IsPhysicalLinksOnly = true;
        int tpIndex = 0;
        List<ODdata> ODdata;
        int FirstPhysicalNode =0;
        int NumOfNodes = 0;
        public enum ResultsChartType
        {
            ConvergenceValue,
            LinkVolume
        }

        ResultsChartType ChartType = ResultsChartType.ConvergenceValue;
        int linkIndex = 0;
        bool WithFreewayFacilityFiles = true;
        public frmUEresultsFreewayfacilities(List<UserEquilibriumTimePeriodResult> resultsImport,List<FreewayData> freewayFacilitiesImport, List<ODdata> ODdataImport, int firstPhysicalNode, int numOfNodes, bool withFreewayFacilityFilesImport)
        {
            InitializeComponent();
            pnlResultsChart.Controls.Add(ctrlResultsDisplay);
            ChartResizing();
            myResults = resultsImport;
            myFreewayFacilities = freewayFacilitiesImport;
            ODdata = ODdataImport;
            FirstPhysicalNode = firstPhysicalNode;
            NumOfNodes = numOfNodes;
            WithFreewayFacilityFiles = withFreewayFacilityFilesImport;
            UpdateChartTimePeriodList();
            cboLinkIDs.Enabled = false;
            if (myResults.Count > 0)
            {
                ctrlResultsDisplay.ClearChart();
                tpIndex = 0;
                if(myResults[tpIndex].NumIterations !=1 && myResults[tpIndex].NumIterations != 0 && myResults[tpIndex].Iterations[0].ConvergeValue != 0)
                {
                    CreateIterationChart();
                    ctrlResultsDisplay.CreateChart(myChartSettings);
                    
                }               
                UpdateDataGridView();
                UpdateConvergenceResults();
            }
            else
            {
                MessageBox.Show("Failed to converge");
            }

        }
        private void UpdateConvergenceResults()
        {
            txtConvergenceValue.Text = myResults[tpIndex].ConvergenceValue.ToString("0.00000");
            txtNumIterations.Text = myResults[tpIndex].NumIterations.ToString();
        }
        private void UpdateChartTimePeriodList()
        {
            cboChartTimePeriod.Items.Clear();
            for(int n =0; n< myResults.Count; n++)
            {
                cboChartTimePeriod.Items.Add(n+1);
            }
        }

        private void LoadLinkComboBox()
        {
            cboLinkIDs.Items.Clear();
            for (int n = 0; n < myFreewayFacilities.Count; n++)
            {
                if (myFreewayFacilities[n].PhysicalLinkXXE == true)
                {
                    cboLinkIDs.Text = myFreewayFacilities[n].Id.ToString();
                    break;
                }
            }

            for (int n = 0; n < myFreewayFacilities.Count; n++)
            {
                if (myFreewayFacilities[n].PhysicalLinkXXE == true)
                {
                    cboLinkIDs.Items.Add(myFreewayFacilities[n].Id);
                }
            }
        }
        private void UpdateDataGridView()
        {
            dgvResults.Rows.Clear();
            int rowID = 0;
           
            for(int tp =0; tp< myResults.Count; tp++)
            {
                if (IsPhysicalLinksOnly == false)
                {
                    int NumRows = myResults[tp].LinkResults.Count;
                    if (NumRows > 0)
                    {
                        dgvResults.Rows.Add(NumRows);
                        for (int n = 0; n < NumRows; n++)
                        {
                            dgvResults.Rows[rowID].Cells[colTimePeriod.Name].Value = tp + 1;
                            dgvResults.Rows[rowID].Cells[colID.Name].Value = myResults[tp].LinkResults[n].ID;
                            dgvResults.Rows[rowID].Cells[colFromNode.Name].Value = myResults[tp].LinkResults[n].FromNode;
                            dgvResults.Rows[rowID].Cells[colToNode.Name].Value = myResults[tp].LinkResults[n].ToNode;
                            dgvResults.Rows[rowID].Cells[colVolume.Name].Value = myResults[tp].LinkResults[n].Volume.ToString("0");
                            dgvResults.Rows[rowID].Cells[colTravelTime.Name].Value = Math.Round(myResults[tp].LinkResults[n].TravelTime, 2);
                            dgvResults.Rows[rowID].Cells[colPhysicalLink.Name].Value = myResults[tp].LinkResults[n].PhysLink.ToString();
                            rowID++;
                        }

                    }
                }
                else
                {
                    for(int n = 0; n< myResults[tp].LinkResults.Count; n++)
                    {
                        if (myResults[tp].LinkResults[n].PhysLink == true)
                        {
                            dgvResults.Rows.Add(1);
                            dgvResults.Rows[rowID].Cells[colTimePeriod.Name].Value = tp + 1;
                            dgvResults.Rows[rowID].Cells[colID.Name].Value = myResults[tp].LinkResults[n].ID;
                            dgvResults.Rows[rowID].Cells[colFromNode.Name].Value = myResults[tp].LinkResults[n].FromNode;
                            dgvResults.Rows[rowID].Cells[colToNode.Name].Value = myResults[tp].LinkResults[n].ToNode;
                            dgvResults.Rows[rowID].Cells[colVolume.Name].Value = myResults[tp].LinkResults[n].Volume.ToString("0");
                            dgvResults.Rows[rowID].Cells[colTravelTime.Name].Value = Math.Round(myResults[tp].LinkResults[n].TravelTime, 2);
                            dgvResults.Rows[rowID].Cells[colPhysicalLink.Name].Value = myResults[tp].LinkResults[n].PhysLink.ToString();
                            rowID++;
                        }                     
                    }
                }
                
            }

            if(WithFreewayFacilityFiles == true)
            {
                dgvResults.Columns[colFreewayFacilities.Name].Visible = true;
            }
            else
            {
                dgvResults.Columns[colFreewayFacilities.Name].Visible = false;
            }
           
        }
        private void GetInputLists(List<double> xInputList, List<double> yInputList, List<double> yInputListObjValues,List<double> yInputListLinkVolumes)
        {
            int NumIteration = myResults[tpIndex].Iterations.Count;
            if(ChartType == ResultsChartType.ConvergenceValue)
            {
                for (int n = 0; n < NumIteration; n++)
                {
                    xInputList.Add(n + 1);
                    yInputList.Add(Math.Round(myResults[tpIndex].Iterations[n].ConvergeValue, 3));
                }
            }
            else if(ChartType == ResultsChartType.LinkVolume)
            {
                for (int n = 0; n < NumIteration; n++)
                {
                    xInputList.Add(n + 1);
                    yInputListLinkVolumes.Add(Math.Round(myResults[tpIndex].Iterations[n].LinkVolumes[linkIndex].Volume,0));
                }
            }
            
        }

        private void GetSeriesSettingsConvergenceValues(Series mySeries)
        {
            mySeries.Name = "Convergence Values";
            mySeries.ChartType = SeriesChartType.FastLine;
            mySeries.XAxisType = AxisType.Primary;
            mySeries.YAxisType = AxisType.Primary;
            mySeries.IsVisibleInLegend = true;
            mySeries.Color = Color.Blue;
        }

        private void GetSeriesSettingsObjValues(Series mySeries)
        {
            mySeries.Name = "Total Link Travel Times";
            mySeries.ChartType = SeriesChartType.FastLine;
            mySeries.XAxisType = AxisType.Primary;
            mySeries.YAxisType = AxisType.Primary;
            mySeries.IsVisibleInLegend = true;
            mySeries.Color = Color.Red;
        }

        private void GetSeriesSettingsLinkVolumes(Series mySeries)
        {
            mySeries.Name = "Link " + (linkIndex+1).ToString() +" Volumes";
            mySeries.ChartType = SeriesChartType.FastLine;
            mySeries.XAxisType = AxisType.Primary;
            mySeries.YAxisType = AxisType.Primary;
            mySeries.IsVisibleInLegend = true;
            mySeries.Color = Color.Green;
        }

        private void GetChartSettingsConvergenceValues(List<double> xInputList, List<double> yInputList)
        {
            string XAxisLabel = "Iteration Number";
            string YAxisLabel = "Converge Value";
            double XAxisInterval = 5;
            double XAxisMinValue = 1;
            double XAxisMaxValue = myResults[tpIndex].NumIterations;
            double YAxisInterval = 0;
            double YAxisMinValue = 0;
            double YAxisMaxValue = 0;

            YAxisMaxValue = BasicStatsCalculations.GetMaximum(yInputList);         
            YAxisInterval = Math.Round(YAxisMaxValue / 10,2);
            myChartSettings = new SwashStatistics_ChartingControl.ChartSettings(XAxisInterval, XAxisInterval, XAxisMinValue, XAxisMaxValue, YAxisInterval, YAxisInterval, YAxisMinValue, YAxisMaxValue, XAxisLabel, YAxisLabel, true, false);
        }

        private void GetChartSettingsObjValues(List<double> xInputList, List<double> yInputList)
        {
            string XAxisLabel = "Iteration Number";
            string YAxisLabel = "Total Link Travel Time";
            double XAxisInterval = 5;
            double XAxisMinValue = 1;
            double XAxisMaxValue = myResults[tpIndex].NumIterations;
            double YAxisInterval = 0;
            double YAxisMinValue = 0;
            double YAxisMaxValue = 0;
            YAxisMinValue = BasicStatsCalculations.GetMinimum(yInputList);
            YAxisMaxValue = BasicStatsCalculations.GetMaximum(yInputList);
            YAxisInterval = Math.Round(YAxisMaxValue / 10, 2);
            myChartSettings = new SwashStatistics_ChartingControl.ChartSettings(XAxisInterval, XAxisInterval, XAxisMinValue, XAxisMaxValue, YAxisInterval, YAxisInterval, YAxisMinValue, YAxisMaxValue, XAxisLabel, YAxisLabel, true, false);
        }

        private void GetChartSettingsLinkVolumes(List<double> xInputList, List<double> yInputList)
        {
            string XAxisLabel = "Iteration Number";
            string YAxisLabel = "Link Volume";
            double XAxisInterval = 5;
            double XAxisMinValue = 1;
            double XAxisMaxValue = myResults[tpIndex].NumIterations;
            double YAxisInterval = 0;
            double YAxisMinValue = 0;
            double YAxisMaxValue = 0;
            YAxisMinValue = Math.Round(BasicStatsCalculations.GetMinimum(yInputList));
            YAxisMaxValue = Math.Round(BasicStatsCalculations.GetMaximum(yInputList));
            YAxisInterval = Math.Round(YAxisMaxValue / 10, 0);
            if (YAxisMinValue == YAxisMaxValue)
            {
                YAxisMinValue = 0;
                YAxisInterval = YAxisMaxValue;                                
            }
            if(YAxisInterval == 0)
            {
                YAxisInterval = YAxisMaxValue - YAxisMinValue;
            }
            
            myChartSettings = new SwashStatistics_ChartingControl.ChartSettings(XAxisInterval, XAxisInterval, XAxisMinValue, XAxisMaxValue, YAxisInterval, YAxisInterval, YAxisMinValue, YAxisMaxValue, XAxisLabel, YAxisLabel, true, false);
        }

        private void CreateIterationChart()
        {
            if(myResults[tpIndex].IsConverged == true)
            {
                lblConverged.Text = "Converged";
                lblConverged.ForeColor = Color.Green;
            }
            else
            {
                lblConverged.Text = "Not Converged";
                lblConverged.ForeColor = Color.Red;
            }
            
            ctrlResultsDisplay.ClearChart();
            myChartSettings.DataSeries = new List<Series>();
            List<double> xInputList = new List<double>();
            List<double> yInputList = new List<double>();
            List<double> yInputListObjValues = new List<double>();
            List<double> yInputListLinkVolumes = new List<double>();
            GetInputLists(xInputList, yInputList,yInputListObjValues,yInputListLinkVolumes);
            if(ChartType == ResultsChartType.ConvergenceValue)
            {
                Series mySeriesConvergenceValues = new Series();
                GetSeriesSettingsConvergenceValues(mySeriesConvergenceValues);
                GetChartSettingsConvergenceValues(xInputList, yInputList);
                myChartSettings.SetDataSeries(mySeriesConvergenceValues, xInputList, yInputList);
                myChartSettings.DataSeries.Add(mySeriesConvergenceValues);
            }
            else if (ChartType == ResultsChartType.LinkVolume)
            {
                Series mySeriesLinkVolumes = new Series();
                GetSeriesSettingsLinkVolumes(mySeriesLinkVolumes);
                GetChartSettingsLinkVolumes(xInputList, yInputListLinkVolumes);
                myChartSettings.SetDataSeries(mySeriesLinkVolumes, xInputList, yInputListLinkVolumes);
                myChartSettings.DataSeries.Add(mySeriesLinkVolumes);
            }


        }

        private void ChartResizing()
        {
            ctrlResultsDisplay.ResizeChart(pnlResultsChart.Width, pnlResultsChart.Height);

        }

        private void frmUEresultsFreewayfacilities_SizeChanged(object sender, EventArgs e)
        {
            ChartResizing();
        }

        private int GetFacilityID(int fwyID)
        {
            int facilityID = 0;
            for(int n = 0; n< myFreewayFacilities.Count; n++)
            {
                if(myFreewayFacilities[n].Id == fwyID)
                {
                    facilityID = n;
                    break;
                }
            }
            return facilityID;
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(WithFreewayFacilityFiles == true)
            {
                if (e.ColumnIndex > 0 && e.RowIndex >= 0)
                {
                    int link = Convert.ToInt32(dgvResults.Rows[e.RowIndex].Cells[colID.Name].Value);
                    int tp = Convert.ToInt32(dgvResults.Rows[e.RowIndex].Cells[colTimePeriod.Name].Value);

                    if (e.ColumnIndex == 7) // Load in FreewawFacilities program
                    {
                        int freewayID = (int)dgvResults.Rows[e.RowIndex].Cells[colID.Name].Value;
                        GetLinkIndex(freewayID);
                        int numTPs = myResults.Count;
                        //numTPs-1: the last time period results contains them all
                        FreewayData fwy = myFreewayFacilities[GetFacilityID(freewayID)];
                        List<List<SegmentData>> tpsegs = fwy.TPsegs;
                        int NumOfLanes = tpsegs[0][0].NumThruLanes;
                        HCMCalc_Definitions.ProjectData FFproject = new HCMCalc_Definitions.ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                        HCMCalc_Calculations.CalculationsMain.CalcResults(FFproject, NumOfLanes, ref fwy, ref tpsegs);
                        HCMCalc_FreewayFacility.mdiMain MDIform = new HCMCalc_FreewayFacility.mdiMain(FFproject, fwy, tpsegs);
                        MDIform.Show();
                    }
                }
            }
            
        }

        private void cboChartTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            tpIndex = cboChartTimePeriod.SelectedIndex;
            if (myResults[tpIndex].NumIterations != 1 && myResults[tpIndex].NumIterations != 0 && myResults[tpIndex].Iterations[0].ConvergeValue != 0)
            {
                CreateIterationChart();
                ctrlResultsDisplay.CreateChart(myChartSettings);
                UpdateConvergenceResults();
            }
            else
            {
                ctrlResultsDisplay.ClearChart();
                MessageBox.Show("Failed to converge");
            }
        }

        private void cboObjValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboObjValues.SelectedIndex == 0)
            {
                ChartType = ResultsChartType.ConvergenceValue;
                cboLinkIDs.Enabled = false;
            }
            else if(cboObjValues.SelectedIndex == 1)
            {
                ChartType = ResultsChartType.LinkVolume;
                cboLinkIDs.Enabled = true;
                LoadLinkComboBox();
            }

            CreateIterationChart();
            ctrlResultsDisplay.CreateChart(myChartSettings);
            UpdateConvergenceResults();

        }

        private void GetLinkIndex(int id)
        {          
            int numLinks = myResults[0].LinkResults.Count;
            for(int n =0; n< numLinks; n++)
            {
                if(myResults[0].LinkResults[n].ID == id)
                {
                    linkIndex = n;
                    break;
                }
            }
        }

        private void cboLinkIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLinkIndex(Convert.ToInt32(cboLinkIDs.SelectedItem));
            CreateIterationChart();
            ctrlResultsDisplay.CreateChart(myChartSettings);
        }

        private void btnODresults_Click(object sender, EventArgs e)
        {
            ODresults myODresultsForm = new ODresults(myResults);
            myODresultsForm.StartPosition = FormStartPosition.CenterScreen;       
            myODresultsForm.Show();
        }

        private void btnFlowConservation_Click(object sender, EventArgs e)
        {           
            FlowConservation myFlowConservation = new FlowConservation(myResults,myFreewayFacilities,ODdata, FirstPhysicalNode, NumOfNodes);
            myFlowConservation.StartPosition = FormStartPosition.CenterScreen;
            myFlowConservation.Show();
        }
    }
}
