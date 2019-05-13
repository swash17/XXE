using HCMCalc_Definitions;
using SwashStatistics_ChartingControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace XXE_UserInterface
{
    public partial class FreewayFacility : Form
    {
        FreewayData Fwy = new FreewayData();
        List<List<SegmentData>> TPSegs = new List<List<SegmentData>>();
        List<List<double>> ProportionTimePeriodList = new List<List<double>>();
        List<List<double>> RampVolumeTimePeriodList = new List<List<double>>();
        string SourceDir;
        ctrlDistributionDisplay ctrlDistributionDisplay1 = new ctrlDistributionDisplay();
        List<double[]> VolumeTravelTimeList = new List<double[]>();
        ChartSettings myChartSettings = new ChartSettings();
        Series mySeries = new Series();
        List<double> XinputList = new List<double>();
        List<double> YinputList = new List<double>();
        int volumeStepSize = 200;
        int MaxVolume = 8000;
        int MinVolume = 100;
        int IntervalVolume = 50;
        double MaxTravelTime = 12;
        double MinTravelTime = 6;
        double IntervalTravelTime = 1;
        int TPnumber = 2;
        bool IsRampProportion = true;
        XXE_Calculations.FreewayFacilitiesCalculations myFreewayFacilityCalculation = new XXE_Calculations.FreewayFacilitiesCalculations();

        public FreewayFacility(FreewayData fwyImport)
        {
            InitializeComponent();
            panelChartControl.Controls.Add(ctrlDistributionDisplay1);
            ChartResizing();
            GetMainlineInputSettings();
            Fwy = fwyImport;
            TPSegs = Fwy.TPsegs;
            updnTimePeriod.Maximum = Fwy.TotalTimePeriods;
            GenerateInitialRampProportionTimePeriodList();
            //btnCreateChart_Click(null,null);
        }

        private void GetMainlineInputSettings()
        {
            MaxVolume = (int)updnMaxFlow.Value;
            MinVolume = (int)updnMinFlow.Value;
            volumeStepSize = (int)updnIntervalFlow.Value;
            TPnumber = (int)updnTimePeriod.Value;
        }

        private void CreateChart()
        {
            ctrlDistributionDisplay1.ClearChart();
            GetInputListsAndChartSettings();
            GetSeriesSettings();
            myChartSettings.SetDataSeries(mySeries, XinputList, YinputList);
            myChartSettings.DataSeries.Add(mySeries);
            ctrlDistributionDisplay1.CreateChart(myChartSettings);
        }

        private void GetInputListsAndChartSettings()
        {
            SetInputLists();
            SetChartSettings();

        }

        private void SetInputLists()
        {
            XinputList.Clear();
            YinputList.Clear();
            for (int n = 0; n < VolumeTravelTimeList.Count; n++)
            {
                XinputList.Add(VolumeTravelTimeList[n][0]);
                YinputList.Add(VolumeTravelTimeList[n][1]);

            }
        }

        private void SetChartSettings()
        {
            //Chart Settings
            double XAxisInterval = Math.Round(MaxVolume / 10.0);
            double XAxisMinValue = 0;
            double XAxisMaxValue = Math.Round(MaxVolume / 10.0) * 10;
            MinTravelTime = int.MaxValue;
            MaxTravelTime = int.MinValue;
            for (int n = 0; n < VolumeTravelTimeList.Count; n++)
            {
                if (MinTravelTime > VolumeTravelTimeList[n][1])
                {
                    MinTravelTime = VolumeTravelTimeList[n][1];
                }
            }
            for (int n = 0; n < VolumeTravelTimeList.Count; n++)
            {
                if (MaxTravelTime < VolumeTravelTimeList[n][1])
                {
                    MaxTravelTime = VolumeTravelTimeList[n][1];
                }
            }
            double YAxisMinValue = MinTravelTime;
            double YAxisMaxValue = MaxTravelTime;
            double YAxisInterval = (MaxTravelTime - MinTravelTime) / 10;
            if ((MaxTravelTime - MinTravelTime) > 10)
            {
                YAxisInterval = Math.Round((MaxTravelTime - MinTravelTime) / 10.0);
                YAxisMaxValue = MinTravelTime + YAxisInterval * 10;
            }
            else if ((MaxTravelTime - MinTravelTime) > 1)
            {
                YAxisInterval = Math.Round((MaxTravelTime - MinTravelTime) / 10.0, 1);
                YAxisMaxValue = MinTravelTime + YAxisInterval * 10;
            }
            else if ((MaxTravelTime - MinTravelTime) > 0)
            {
                YAxisInterval = Math.Round((MaxTravelTime - MinTravelTime) / 2.0, 2);
                YAxisMaxValue = MinTravelTime + YAxisInterval * 2;
            }
            while (YAxisMaxValue < MaxTravelTime)
            {
                YAxisMaxValue = YAxisMaxValue + YAxisInterval;
            }
            string XAxisLabel = "Mainline Traffic Demand Input (veh/h)";
            string YAxisLabel = "Average Facility Travel Time (min)";

            myChartSettings = new ChartSettings(XAxisInterval, XAxisInterval, XAxisMinValue, XAxisMaxValue, YAxisInterval, YAxisInterval, YAxisMinValue, YAxisMaxValue, XAxisLabel, YAxisLabel, true, false);
        }

        private void GetSeriesSettings()
        {
            mySeries = new Series();
            string seriesName = "Mainline Traffic Demand vs. Average Facility Travel Time";
            mySeries.Name = seriesName;
            mySeries.ChartType = SeriesChartType.FastPoint;
            mySeries.XAxisType = AxisType.Primary;
            mySeries.YAxisType = AxisType.Primary;
            mySeries.IsVisibleInLegend = true;
            //mySeries.BorderWidth = 3;
            mySeries.Color = Color.Blue;
        }

        private void GenerateInitialRampProportionTimePeriodList()
        {
            ProportionTimePeriodList = new List<List<double>>(); //By time period
            RampVolumeTimePeriodList = new List<List<double>>(); //By time period
            List<double> Proportion;
            List<double> Volumes;
            for (int tp = 1; tp < TPSegs.Count; tp++)
            {
                Proportion = new List<double>();
                Volumes = new List<double>();
                for (int seg = 1; seg < TPSegs[tp].Count; seg++)
                {
                    double proportion = 0;
                    double volume = 0;
                    if (TPSegs[tp][seg].SegTypeInput == SegmentType.OnRamp)
                    {
                        proportion = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                        volume = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh;
                        Proportion.Add(proportion);
                        Volumes.Add(volume);
                    }
                    else if (TPSegs[tp][seg].SegTypeInput == SegmentType.OffRamp)
                    {
                        proportion = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                        volume = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh;
                        Proportion.Add(proportion);
                        Volumes.Add(volume);
                    }
                    else if (TPSegs[tp][seg].SegTypeInput == SegmentType.Weaving)
                    {
                        proportion = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                        volume = TPSegs[tp][seg].OnRamp.Inputs.DemandVeh;
                        Proportion.Add(proportion);
                        Volumes.Add(volume);
                        proportion = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh / TPSegs[tp][1].DemandVeh;
                        volume = TPSegs[tp][seg].OffRamp.Inputs.DemandVeh;
                        Proportion.Add(proportion);
                        Volumes.Add(volume);
                        proportion = TPSegs[tp][seg].Weave.Inputs.RampToRampDemandVeh / TPSegs[tp][1].DemandVeh;
                        volume = TPSegs[tp][seg].Weave.Inputs.RampToRampDemandVeh;
                        Proportion.Add(proportion);
                        Volumes.Add(volume);
                    }
                }
                ProportionTimePeriodList.Add(Proportion);
                RampVolumeTimePeriodList.Add(Volumes);
            }
        }

        private void GenerateVolumeTravelTimeList()
        {
            List<double> fitListX = new List<double>();
            List<double> fitListY = new List<double>();
            VolumeTravelTimeList.Clear();
            int NumOfLanes = TPSegs[0][0].NumThruLanes;
            for (int volume = MinVolume; volume <= MaxVolume; volume += volumeStepSize)
            {
                List<List<SegmentData>> TPSegsVolumeApplied = myFreewayFacilityCalculation.ApplyVolumeSteps(TPSegs, volume, ProportionTimePeriodList, RampVolumeTimePeriodList, IsRampProportion);
                ProjectData Project = new ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                HCMCalc_Calculations.CalculationsMain.CalcResults(Project, NumOfLanes, ref Fwy, ref TPSegsVolumeApplied);

                double totalTT = 0;
                for (int seg = 1; seg < TPSegsVolumeApplied[0].Count; seg++)
                {
                    if (volume == 0)
                    {
                        totalTT = totalTT + TPSegsVolumeApplied[TPnumber][seg].Results.TravTimeFreeFlow;
                    }
                    else
                    {
                        totalTT = totalTT + TPSegsVolumeApplied[TPnumber][seg].Results.TravTimeAvg;
                    }

                }
                VolumeTravelTimeList.Add(new double[] { volume, Math.Round(totalTT, 2) });
                fitListX.Add(volume);
                fitListY.Add(totalTT);
            }
            //FindTurningPoint(fitListX, fitListY);
            //FitPower(fitListX,fitListY);
        }

        private void DisplayDataGridView()
        {
            dgvVolumeTravelTime.Rows.Clear();
            int rows = VolumeTravelTimeList.Count;
            if (rows > 0)
            {
                dgvVolumeTravelTime.Rows.Add(rows);
                for (int row = 0; row < rows; row++)
                {
                    dgvVolumeTravelTime.Rows[row].Cells[colID.Name].Value = row + 1;
                    dgvVolumeTravelTime.Rows[row].Cells[colVolume.Name].Value = VolumeTravelTimeList[row][0];
                    dgvVolumeTravelTime.Rows[row].Cells[colAvgTravelTime.Name].Value = VolumeTravelTimeList[row][1].ToString("0.000");
                }
            }
        }

        private void ChartResizing()
        {
            ctrlDistributionDisplay1.ResizeChart(panelChartControl.Width, panelChartControl.Height);
        }

        private void dgvVolumeTravelTime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                int NumOfLanes = TPSegs[0][0].NumThruLanes;
                List<List<SegmentData>> currentTPSegs = myFreewayFacilityCalculation.ApplyVolumeSteps(TPSegs, Convert.ToInt32(dgvVolumeTravelTime.Rows[e.RowIndex].Cells[colVolume.Name].Value), ProportionTimePeriodList, RampVolumeTimePeriodList, IsRampProportion);
                ProjectData Project = new ProjectData("Freeway Facility", AnalysisMode.HCM2016);
                HCMCalc_Calculations.CalculationsMain.CalcResults(Project, NumOfLanes, ref Fwy, ref currentTPSegs);
                HCMCalc_FileInputOutput.FreewayFacilityIO FileIO = new HCMCalc_FileInputOutput.FreewayFacilityIO();
                //string fileName = "C:\\Users\\w.sun2014\\Desktop\\file.xff";
                //FileIO.WriteXmlFile(fileName, false, false, Project, Fwy, currentTPSegs);              
                HCMCalc_FreewayFacility.mdiMain MDIform = new HCMCalc_FreewayFacility.mdiMain(Project, Fwy, currentTPSegs);
                MDIform.Show();
            }
        }

        private void btnCreateChart_Click(object sender, EventArgs e)
        {
            if (TPSegs.Count > 0)
            {
                GetMainlineInputSettings();
                GenerateVolumeTravelTimeList();
                DisplayDataGridView();
                CreateChart();
            }
        }


    }
}
