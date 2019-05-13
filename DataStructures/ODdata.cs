using System;
namespace XXE_DataStructures
{
    [Serializable()]
    public class ODdata
    {
        /**** Fields ****/
        
        int _origZone;
        int _destZone;
        long _numTrips;
        long _numAdjTrips;  //Number of trips adjusted by the network intensity ratio

        /**** Constructors ****/
        public ODdata()
        {
            _origZone = 0;
            _destZone = 0;
            _numTrips = 0;
            _numAdjTrips = 0;
        }

        //Specify Link Attributes
        public ODdata(int origZone, int destZone, long numTrips, long numAdjTrips)
        {
            OrigZone = origZone;
            DestZone = destZone;
            NumTrips = numTrips;
            NumAdjTrips = numAdjTrips;
        }

        /**** Properties ****/
        
        public int OrigZone
        {
            get { return _origZone; }
            set { _origZone = value; }
        }
        public int DestZone
        {
            get { return _destZone; }
            set { _destZone = value; }
        }
        public long NumTrips
        {
            get { return _numTrips; }
            set { _numTrips = value; }
        }
        public long NumAdjTrips
        {
            get { return _numAdjTrips; }
            set { _numAdjTrips = value; }
        }

        
    }

}
