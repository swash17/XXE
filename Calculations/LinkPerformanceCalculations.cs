using System;
using System.Collections.Generic;
using HCMCalc_Definitions;

namespace XXE_Calculations
{
    public static class LinkPerformanceCalculations
    {
        
        public static double[] alpha = new double[16];          //BPR coefficient
        public static double[] beta = new double[16];           //BPR coefficient
        public static double[] alphaInt = new double[16];       //integrated alpha coefficient for integrated BPR function
        public static int[,] CoeffIndex = new int[2500, 24];   //first index is link #, second index is time period

        public static void InitializeBPRparms()
        {
            alpha[1] = .7312;
            alpha[2] = .6128;
            alpha[3] = .8774;
            alpha[4] = .6846;
            alpha[5] = 1.1465;
            alpha[6] = .6190;
            alpha[7] = .6662;
            alpha[8] = .6222;
            alpha[9] = 1.030;
            alpha[10] = .6609;
            alpha[11] = .5423;
            alpha[12] = 1.0091;
            alpha[13] = .8776;
            alpha[14] = .7699;
            alpha[15] = 1.1491;
            beta[1] = 3.6596;
            beta[2] = 3.5038;
            beta[3] = 4.4613;
            beta[4] = 5.1644;
            beta[5] = 4.4239;
            beta[6] = 3.6544;
            beta[7] = 4.9432;
            beta[8] = 5.1409;
            beta[9] = 5.5226;
            beta[10] = 5.0906;
            beta[11] = 5.7894;
            beta[12] = 6.5856;
            beta[13] = 4.9287;
            beta[14] = 5.3443;
            beta[15] = 6.8677;
            //the integrated alpha coefficients (=alpha(i)/[beta(i)+1]
            alphaInt[1] = .157;
            alphaInt[3] = .136;
            alphaInt[4] = .161;
            alphaInt[4] = .111;
            alphaInt[5] = .212;
            alphaInt[6] = .133;
            alphaInt[7] = .112;
            alphaInt[8] = .101;
            alphaInt[9] = .158;
            alphaInt[10] = .109;
            alphaInt[11] = .08;
            alphaInt[12] = .133;
            alphaInt[13] = .148;
            alphaInt[14] = .121;
            alphaInt[15] = .146;
        }

        public static int SelectBPRcoeffsIndex(double speed, double capacity, int linkNum, int tp)
        {
            if (speed <= 30)
            {
                if (capacity < 250)
                    CoeffIndex[linkNum, tp] = 1;
                else if (capacity < 500)
                    CoeffIndex[linkNum, tp] = 2;
                else if (capacity < 750)
                    CoeffIndex[linkNum, tp] = 3;
                else if (capacity < 1000)
                    CoeffIndex[linkNum, tp] = 4;
                else   //capacity >= 1000
                    CoeffIndex[linkNum, tp] = 5;
            }
            else if (speed <= 40)
            {
                if (capacity < 500)
                    CoeffIndex[linkNum, tp] = 6;
                else if (capacity < 750)
                    CoeffIndex[linkNum, tp] = 7;
                else if (capacity < 1000)
                    CoeffIndex[linkNum, tp] = 8;
                else   //capacity >= 1000
                    CoeffIndex[linkNum, tp] = 9;
            }
            else if (speed <= 50)
            {
                if (capacity < 500)
                    CoeffIndex[linkNum, tp] = 10;
                else if (capacity < 1000)
                    CoeffIndex[linkNum, tp] = 11;
                else   //capacity >= 1000
                    CoeffIndex[linkNum, tp] = 12;
            }
            else   //speed > 50
            {
                if (capacity < 500)
                    CoeffIndex[linkNum, tp] = 13;
                else if (capacity < 1000)
                    CoeffIndex[linkNum, tp] = 14;
                else   //capacity >= 1000
                    CoeffIndex[linkNum, tp] = 15;
            }
            return CoeffIndex[linkNum, tp];
        }
        
        public static double TravTimeFcn(int dInfo, double length, double capacity, double ffspeed, double flow, double FLX1, double uninform, double que, double alpha, double beta)
        {
            //BPR travel time function
            double Fcn;     //function value
            Fcn = length / ffspeed;     //free-flow travel time
            if (capacity > 0 && dInfo == 1)
                Fcn = Fcn * (1 + alpha * Math.Pow(((flow + FLX1 * uninform) / capacity), beta));
            else if (capacity > 0 && dInfo == 2)
                Fcn = Fcn * (1 + alpha * Math.Pow(((flow + FLX1 * uninform + que) / capacity), beta));
            return Fcn;
        }

        /*
        public static double TravTimeFcn1(double length, double capacity, int ffspeed, double flow, double que, double alpha, double beta)
        {
            //BPR travel time function
            double Fcn1;     //function value
            Fcn1 = length / ffspeed;     //free-flow travel time
            if (capacity > 0)
                Fcn1 = Fcn1 * (1 + alpha * Math.Pow(((flow + que) / capacity), beta));
            return Fcn1;
        }
        */

        public static double IntegratedTravTimeFcn(int dInfo, double length, double capacity, double ffspeed, double flow, double FLX1, double uninform, double que, double alpha, double beta)
        {
            double IntFcn = 0;  //integrated function value

            if (capacity > 0 && dInfo == 1)
            {
                IntFcn = length / ffspeed * (flow + FLX1 * uninform);  //units of veh-hr
                IntFcn = IntFcn * (1 + alpha * Math.Pow(((flow + FLX1 * uninform) / capacity), beta));  //Integrated BPR travel time function
            }
            else if (capacity > 0 && dInfo == 2)
            {
                IntFcn = length / ffspeed * (flow + FLX1 * uninform + que);
                IntFcn = IntFcn * (1 + alpha * Math.Pow(((flow + FLX1 * uninform + que) / capacity), beta));
            }
            return IntFcn;
        }

   

    }

    public static class HCM_FF_Method
    {
        public static void ApplyVolumeSteps(List<List<SegmentData>> TPSegs, double volume, List<List<double>> ProportionTimePeriodList, int tp)
        {
            //assign mainline demand
            TPSegs[tp][1].DemandVeh = volume;

            //assign ramp demand
            int ProportionIndex = 0;
            for (int seg = 2; seg < TPSegs[tp].Count; seg++)
            {
                if (TPSegs[tp][seg].SegTypeInput == SegmentType.OnRamp)
                {
                    TPSegs[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                    ProportionIndex++;
                }
                else if (TPSegs[tp][seg].SegTypeInput == SegmentType.OffRamp)
                {
                    TPSegs[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                    ProportionIndex++;
                }
                else if (TPSegs[tp][seg].SegTypeInput == SegmentType.Weaving)
                {
                    TPSegs[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                    ProportionIndex++;
                    TPSegs[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                    ProportionIndex++;
                    TPSegs[tp][seg].Weave.Inputs.RampToRampDemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                    ProportionIndex++;
                }

            }
        }
        public static double TravTimeFcnFreewayFacilities(List<List<double>> ProportionTimePeriodList, FreewayData fwy, int tp, double flowImport)
        {
            int flow = (int)flowImport;
            if (fwy.PhysicalLinkXXE == false)
            {
                tp = 1;
            }
            //Calculate travel time through HCM-CALC Freeway Facilities module

            ApplyVolumeSteps(fwy.TPsegs, flow, ProportionTimePeriodList, tp);
            List<List<SegmentData>> tpsegs = fwy.TPsegs;

            ProjectData FFproject = new ProjectData("Freeway Facility", AnalysisMode.HCM2016);
            HCMCalc_Calculations.CalculationsMain.CalcResults(FFproject, fwy.TPsegs[0][0].NumThruLanes, ref fwy, ref tpsegs);
            //Fcn = fwy.Results[tp].TravTimeAvg;

            double facilityTravTimeAvg = 0;
            ////Save to 0.1 minute
            if (flow == 0)
            {
                facilityTravTimeAvg = Math.Round(fwy.Results[tp].TravTimeFreeFlow, 1);
            }
            else if (flow > 0)
            {
                facilityTravTimeAvg = Math.Round(fwy.Results[tp].TravTimeAvg, 1);
            }

            //int numSegments = fwy.TPsegs[0].Count - 2;
            ////Save to 0.1 minute
            //if (flow == 0)
            //{
            //    for(int seg =1; seg<=numSegments; seg++)
            //    {
            //        facilityTravTimeAvg = facilityTravTimeAvg + Math.Round(fwy.TPsegs[tp][seg].Results.TravTimeFreeFlow, 1);
            //    }

            //}
            //else if (flow > 0)
            //{
            //    for (int seg = 1; seg <= numSegments; seg++)
            //    {
            //        facilityTravTimeAvg = facilityTravTimeAvg + Math.Round(fwy.TPsegs[tp][seg].Results.TravTimeAvg, 1);
            //    }
            //}

            return facilityTravTimeAvg;
        }
    }
}
