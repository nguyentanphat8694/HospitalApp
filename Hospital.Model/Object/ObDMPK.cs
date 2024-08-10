using System;

namespace Hospital.App
{
    [Serializable]
    public class ObDMPK
    {
        bool _CHON = false;
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMPK _TTChung;
        double _IDBC = 0;
        public double IDBC { get { return _IDBC; } set { _IDBC = value; } }
        public bool CHON { get { return _CHON; } set { _CHON = value; } }
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
       
        public Cls_TTDMPK TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMPK()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMPK();
            m_Action = ActionRec.None;
        }
        public ObDMPK(ObDMPK cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
            _IDBC = cls.IDBC;
        }
        public ObDMPK(bool V_NULL)
        {
            _Ma = "NULL";
            _Ten = "Chọn phòng khám";
            _Loai = 0;
            _TTChung = null;
        }
    }
    [Serializable]
    public class Cls_TTDMPK
    {
        string _MaDV = "";
        public string MaDV { get { return _MaDV; } set { _MaDV = value; } }
        public bool MienPhi { get; set; }
        public Cls_TTDMPK(){
            MienPhi = false;
        }
        public Cls_TTDMPK(Cls_TTDMPK cls)
        {
            _MaDV = cls.MaDV;
            MienPhi = cls.MienPhi;
        }
    }
}
