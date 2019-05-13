using System;
using System.Collections.Generic;
using HCMCalc_Definitions;

namespace XXE_Calculations
{
    public class FreewayFacilitiesCalculations
    {
        public List<List<SegmentData>> ApplyVolumeSteps(List<List<SegmentData>> TPSegs, int volume, List<List<double>> ProportionTimePeriodList, List<List<double>> RampVolumeTimePeriodList, bool IsRampProportion)
        {
            int NumTP = TPSegs.Count - 1;

            List<SegmentData> temp = new List<SegmentData>(TPSegs[1]);
            int NumSeg = temp.Count;
            List<List<SegmentData>> TPSegTemp = new List<List<SegmentData>>();
            for (int i = 0; i <= NumTP; i++)
            {
                List<SegmentData> SegmentsTemp = new List<SegmentData>();
                for (int j = 0; j < NumSeg; j++)
                {
                    SegmentsTemp.Add((SegmentData)TPSegs[i][j].Clone());
                }
                TPSegTemp.Add(SegmentsTemp);
            }
            for (int tp = 1; tp < TPSegTemp.Count; tp++)
            {
                //assign mainline demand
                TPSegTemp[tp][1].DemandVeh = volume;

                //assign ramp demand
                int ProportionIndex = 0;
                if (IsRampProportion == true)
                {
                    for (int seg = 2; seg < TPSegTemp[tp].Count; seg++)
                    {
                        if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.OnRamp)
                        {
                            TPSegTemp[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }
                        else if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.OffRamp)
                        {
                            TPSegTemp[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }
                        else if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.Weaving)
                        {
                            TPSegTemp[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                            TPSegTemp[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                            TPSegTemp[tp][seg].Weave.Inputs.RampToRampDemandVeh = Math.Round(volume * ProportionTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }

                    }
                }
                else
                {
                    for (int seg = 2; seg < TPSegTemp[tp].Count; seg++)
                    {
                        if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.OnRamp)
                        {
                            TPSegTemp[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(RampVolumeTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }
                        else if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.OffRamp)
                        {
                            TPSegTemp[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(RampVolumeTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }
                        else if (TPSegTemp[tp][seg].SegTypeInput == SegmentType.Weaving)
                        {
                            TPSegTemp[tp][seg].OnRamp.Inputs.DemandVeh = Math.Round(RampVolumeTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                            TPSegTemp[tp][seg].OffRamp.Inputs.DemandVeh = Math.Round(RampVolumeTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                            TPSegTemp[tp][seg].Weave.Inputs.RampToRampDemandVeh = Math.Round(RampVolumeTimePeriodList[tp - 1][ProportionIndex]);
                            ProportionIndex++;
                        }

                    }
                }

            }


            return TPSegTemp;
        }


    }
}
