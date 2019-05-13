using System;

namespace XXE_DataStructures
{
    [Serializable()]
    public enum ProjectType
    {
        BPRlinks = 0,
        FreewayFacilities = 1,
    }
    #region Project Data
    [Serializable()]
    public class ProjectData
    {
        /**** Fields ****/

        string _fileName;
        string _title;
        DateTime _analDate;
        string _analName;
        string _userNotes;
        bool _printDiagnosticResults;
        ProjectType _type;
        string _networkFileName;
        string _oDfileName;

        /**** Constructors ****/
        public ProjectData()
        {
            _fileName = "untitled.xml";
            _title = "";
            _analName = "";
            _analDate = System.DateTime.Now;
            _userNotes = "";
            _printDiagnosticResults = false;
            _type = ProjectType.FreewayFacilities;
            _networkFileName = "untitled.xml";
            _oDfileName = "untitled.xml";
        }

        public ProjectData(string projTitle, DateTime analDate, string analName, string userNotes,ProjectType type)
        {
            _fileName = "untitled.xml";
            Title = projTitle;
            AnalDate = analDate;
            AnalName = analName;
            UserNotes = userNotes;
            _printDiagnosticResults = false;
            _type = type;
            _networkFileName = "untitled.xml";
            _oDfileName = "untitled.xml";
        }

        /**** Properties ****/
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public DateTime AnalDate
        {
            get { return _analDate; }
            set { _analDate = value; }
        }
        public string AnalName
        {
            get { return _analName; }
            set { _analName = value; }
        }
        public string UserNotes
        {
            get { return _userNotes; }
            set { _userNotes = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public bool PrintDiagnosticResults
        {
            get { return _printDiagnosticResults; }
            set { _printDiagnosticResults = value; }
        }

        public ProjectType Type
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

        public string ODfileName
        {
            get
            {
                return _oDfileName;
            }

            set
            {
                _oDfileName = value;
            }
        }

        public string NetworkFileName
        {
            get
            {
                return _networkFileName;
            }

            set
            {
                _networkFileName = value;
            }
        }
    }
    #endregion
}
