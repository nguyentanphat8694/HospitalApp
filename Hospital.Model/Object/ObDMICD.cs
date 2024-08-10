using System;

namespace Hospital.App
{
    [Serializable]
    public class ObDMICD
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMICD _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMICD TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMICD()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMICD();
            m_Action = ActionRec.None;
        }
        public ObDMICD(ObDMICD cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMICD
    {
        public Cls_TTDMICD(){
        }
        public Cls_TTDMICD(Cls_TTDMICD cls)
        {
        }
    }
}
