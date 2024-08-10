using System;

namespace Hospital.App
{
    [Serializable]
    public class ObRecord
    {
        string _IPAd, _NameTBL;
        DateTime _TimeMX;
        string _IDOB;
        int _Action;
        string _Time_Static;
        object _OBUPDATE = null;
        public int Action { get { return _Action; } set { _Action = value; } }
        public string IPAd { get { return _IPAd; } set { _IPAd = value; } }
        public string NameTBL { get { return _NameTBL; } set { _NameTBL = value; } }
        public DateTime TimeMX { get { return _TimeMX; } set { _TimeMX = value; } }
        public string IDOB { get { return _IDOB; } set { _IDOB = value; } }
        public object OBUPDATE { get { return _OBUPDATE; } set { _OBUPDATE = value; } }
        public string Time_Static { get { return _Time_Static; } set { _Time_Static = value; } }
        public ObRecord()
        {
            _IPAd = "";
            _NameTBL = "";
            _TimeMX = new DateTime(1900, 01, 01);
            _IDOB = "";
            _Action = (int)ActionRec.Insert;
            _OBUPDATE = null;
            _Time_Static = "";
        }
        public ObRecord(ObRecord cls)
        {
            _IPAd = cls.IPAd;
            _NameTBL = cls.NameTBL;
            _TimeMX = cls.TimeMX;
            _IDOB = cls.IDOB;
            _Action = cls.Action;
            _OBUPDATE = cls.OBUPDATE;
            _Time_Static = cls.Time_Static;
        }
        public ObRecord(string time_static, string nametbl, string idob, int action,object OBUpdate)
        {
            _IPAd = MainNTP.IP_ADDRESS;
            _NameTBL = nametbl;
            _IDOB = idob;
            _Action = action;
            _OBUPDATE = OBUpdate;
            _Time_Static = MainNTP._Time_Static;
        }
    }
    [Serializable]
    public class Cls_TTRecord
    {
        public Cls_TTRecord(){
        }
        public Cls_TTRecord(Cls_TTRecord cls)
        {
        }
    }
}
