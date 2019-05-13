using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMCalc_Definitions;
namespace XXE_DataStructures
{
    [Serializable()]
    public class ODResult
    {
        private List<List<int>> _pathLists;
        private int _orig;
        private int _dest;
        private List<double> _travelTimeList;
        private double _minimalPathTravelTime;
        private double _minimalPathFreeFlowTravelTime;
        private List<List<int>> _utilizedPathLists;
        private List<int> _utilizedList; //0 not utilized, 1 utilized
        private List<double> _freeFlowTravelTimeList;
        public ODResult()
        {
            _pathLists = new List<List<int>>();
            _orig = 0;
            _dest = 0;
            _travelTimeList = new List<double>();
            _minimalPathTravelTime = 0;
            _minimalPathFreeFlowTravelTime = 0;
            _utilizedPathLists = new List<List<int>>();
            _utilizedList = new List<int>();
            _freeFlowTravelTimeList = new List<double>();
        }
        public List<List<int>> PathLists
        {
            get
            {
                return _pathLists;
            }

            set
            {
                _pathLists = value;
            }
        }

        public int Orig
        {
            get
            {
                return _orig;
            }

            set
            {
                _orig = value;
            }
        }

        public int Dest
        {
            get
            {
                return _dest;
            }

            set
            {
                _dest = value;
            }
        }

        public List<double> TravelTimeList
        {
            get
            {
                return _travelTimeList;
            }

            set
            {
                _travelTimeList = value;
            }
        }

        public double MinimalPathTravelTime
        {
            get
            {
                return _minimalPathTravelTime;
            }

            set
            {
                _minimalPathTravelTime = value;
            }
        }

        public List<List<int>> UtilizedPathLists
        {
            get
            {
                return _utilizedPathLists;
            }

            set
            {
                _utilizedPathLists = value;
            }
        }

        public List<int> UtilizedList
        {
            get
            {
                return _utilizedList;
            }

            set
            {
                _utilizedList = value;
            }
        }

        public List<double> FreeFlowTravelTimeList
        {
            get
            {
                return _freeFlowTravelTimeList;
            }

            set
            {
                _freeFlowTravelTimeList = value;
            }
        }

        public double MinimalPathFreeFlowTravelTime
        {
            get
            {
                return _minimalPathFreeFlowTravelTime;
            }

            set
            {
                _minimalPathFreeFlowTravelTime = value;
            }
        }
    }
    [Serializable()]
    public class ODvolume
    {
        private int _origZone;
        private int _destZone;
        private double _volume;

        public int OrigZone
        {
            get
            {
                return _origZone;
            }

            set
            {
                _origZone = value;
            }
        }

        public int DestZone
        {
            get
            {
                return _destZone;
            }

            set
            {
                _destZone = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }

        public ODvolume()
        {
            _origZone = 0;
            _destZone = 0;
            _volume = 0;
        }
    }
    [Serializable()]
    public class NodeFlowConservation
    {
        private int _node;
        private byte _type; //0 is transition nodes, 1 is OD nodes
        private List<int[]> _connectedZones;
        private List<int> _connectedLinks;
        private double _flowOD;
        private double _flowLink;

        public NodeFlowConservation()
        {
            _node = 0;
            _type = 0;
            _connectedZones = new List<int[]>();
            _connectedLinks = new List<int>();
            _flowOD = 0;
            _flowLink = 0;
        }

        public int Node
        {
            get
            {
                return _node;
            }

            set
            {
                _node = value;
            }
        }

        public byte Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public List<int[]> ConnectedZones
        {
            get
            {
                return _connectedZones;
            }

            set
            {
                _connectedZones = value;
            }
        }

        public List<int> ConnectedLinks
        {
            get
            {
                return _connectedLinks;
            }

            set
            {
                _connectedLinks = value;
            }
        }

        public double FlowOD
        {
            get
            {
                return _flowOD;
            }

            set
            {
                _flowOD = value;
            }
        }

        public double FlowLink
        {
            get
            {
                return _flowLink;
            }

            set
            {
                _flowLink = value;
            }
        }
    }
    [Serializable()]
    public class UserEquilibriumTimePeriodResult
    {
        private int _timePeriod;
        private int _numIterations;
        private List<Iteration> _iterations;
        private List<LinkResult> _linkResults;
        private double _convergenceValue;
        private double _objFunctionValue;
        bool _isConverged;
        private List<ODResult> _ODResults;
        public UserEquilibriumTimePeriodResult()
        {
            _timePeriod = 1;
            _numIterations = 0;
            _convergenceValue = 0;
            _iterations = new List<Iteration>();
            _linkResults = new List<LinkResult>();
            _objFunctionValue = 0;
            _isConverged = true;
            _ODResults = new List<ODResult>();           
        }

        public int NumIterations
        {
            get
            {
                return _numIterations;
            }

            set
            {
                _numIterations = value;
            }
        }

        public List<Iteration> Iterations
        {
            get
            {
                return _iterations;
            }

            set
            {
                _iterations = value;
            }
        }

        public List<LinkResult> LinkResults
        {
            get
            {
                return _linkResults;
            }

            set
            {
                _linkResults = value;
            }
        }

        public int TimePeriod
        {
            get
            {
                return _timePeriod;
            }

            set
            {
                _timePeriod = value;
            }
        }

        public double ConvergenceValue
        {
            get
            {
                return _convergenceValue;
            }

            set
            {
                _convergenceValue = value;
            }
        }

        public double ObjFunctionValue
        {
            get
            {
                return _objFunctionValue;
            }

            set
            {
                _objFunctionValue = value;
            }
        }

        public bool IsConverged
        {
            get
            {
                return _isConverged;
            }

            set
            {
                _isConverged = value;
            }
        }

        public List<ODResult> ODResults
        {
            get
            {
                return _ODResults;
            }

            set
            {
                _ODResults = value;
            }
        }
    }

    public class SegmentTravelTime
    {
        private int _iD;
        private double _travelTime;

        public SegmentTravelTime()
        {
            _iD = 0;
            _travelTime = 0;
        }

        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public double TravelTime
        {
            get
            {
                return _travelTime;
            }

            set
            {
                _travelTime = value;
            }
        }
    }
    [Serializable()]
    public class LinkResult
    {
        private int _iD;
        private int _fromNode;
        private int _toNode;
        private bool _physLink;
        private double _volume;
        private double _travelTime;
        private double _freeFlowTravelTime;
        private double _vehMilesTravDemand;
        private double _vehMilesTravVolume;
        private double _vehHoursTrav;
        private double _vehHoursDelay;
        private double _avgSpeed;
        private double _densityVeh;
        private double _densityPC;
        private List<SegmentTravelTime> _segmentTravelTimes;
        public LinkResult()
        {
            _iD = 0;
            _fromNode = 0;
            _toNode = 0;
            _physLink = false;
            _volume = 0;
            _travelTime = 0;
            _freeFlowTravelTime = 0;
            _vehMilesTravDemand = 0;
            _vehMilesTravVolume = 0;
            _vehHoursTrav = 0;
            _vehHoursDelay = 0;
            _avgSpeed = 0;
            _densityVeh = 0;
            _densityPC = 0;
            _segmentTravelTimes = new List<SegmentTravelTime>();
        }

        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public int FromNode
        {
            get
            {
                return _fromNode;
            }

            set
            {
                _fromNode = value;
            }
        }

        public int ToNode
        {
            get
            {
                return _toNode;
            }

            set
            {
                _toNode = value;
            }
        }

        public bool PhysLink
        {
            get
            {
                return _physLink;
            }

            set
            {
                _physLink = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }

        public double TravelTime
        {
            get
            {
                return _travelTime;
            }

            set
            {
                _travelTime = value;
            }
        }

        public double FreeFlowTravelTime
        {
            get
            {
                return _freeFlowTravelTime;
            }

            set
            {
                _freeFlowTravelTime = value;
            }
        }

        public double VehMilesTravDemand
        {
            get
            {
                return _vehMilesTravDemand;
            }

            set
            {
                _vehMilesTravDemand = value;
            }
        }

        public double VehMilesTravVolume
        {
            get
            {
                return _vehMilesTravVolume;
            }

            set
            {
                _vehMilesTravVolume = value;
            }
        }

        public double VehHoursTrav
        {
            get
            {
                return _vehHoursTrav;
            }

            set
            {
                _vehHoursTrav = value;
            }
        }

        public double VehHoursDelay
        {
            get
            {
                return _vehHoursDelay;
            }

            set
            {
                _vehHoursDelay = value;
            }
        }

        public double AvgSpeed
        {
            get
            {
                return _avgSpeed;
            }

            set
            {
                _avgSpeed = value;
            }
        }

        public double DensityVeh
        {
            get
            {
                return _densityVeh;
            }

            set
            {
                _densityVeh = value;
            }
        }

        public double DensityPC
        {
            get
            {
                return _densityPC;
            }

            set
            {
                _densityPC = value;
            }
        }

        public List<SegmentTravelTime> SegmentTravelTimes
        {
            get
            {
                return _segmentTravelTimes;
            }

            set
            {
                _segmentTravelTimes = value;
            }
        }
    }

    public class IterationLinkVolume
    {
        private int _iD;
        private int _fromNode;
        private int _toNode;
        private bool _physLink;
        private double _volume;

        public IterationLinkVolume()
        {
            _iD = 0;
            _fromNode = 0;
            _toNode = 0;
            _physLink = false;
            _volume = 0;
        }
        public int ID
        {
            get
            {
                return _iD;
            }

            set
            {
                _iD = value;
            }
        }

        public int FromNode
        {
            get
            {
                return _fromNode;
            }

            set
            {
                _fromNode = value;
            }
        }

        public int ToNode
        {
            get
            {
                return _toNode;
            }

            set
            {
                _toNode = value;
            }
        }

        public bool PhysLink
        {
            get
            {
                return _physLink;
            }

            set
            {
                _physLink = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }      
    }
    [Serializable()]
    public class Iteration
    {
        private int _iternationNum;
        private double _convergeValue;
        private double _objFunction;
        private List<IterationLinkVolume> _linkVolumes;
        public Iteration()
        {
            _iternationNum = 0;
            _convergeValue = 0;
            _objFunction = 0;
            _linkVolumes = new List<IterationLinkVolume>();    
        }

        public int IternationNum
        {
            get
            {
                return _iternationNum;
            }

            set
            {
                _iternationNum = value;
            }
        }

        public double ConvergeValue
        {
            get
            {
                return _convergeValue;
            }

            set
            {
                _convergeValue = value;
            }
        }

        public double ObjFunction
        {
            get
            {
                return _objFunction;
            }

            set
            {
                _objFunction = value;
            }
        }

        public List<IterationLinkVolume> LinkVolumes
        {
            get
            {
                return _linkVolumes;
            }

            set
            {
                _linkVolumes = value;
            }
        }
    }
}
