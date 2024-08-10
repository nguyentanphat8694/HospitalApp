using System;

namespace Hospital.App
{
    [Serializable]
    public class ObDMQuan
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        string _MaTinh;
        Cls_TTDMQuan _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public string MaTinh { get { return _MaTinh; } set { _MaTinh = value; } }
        public Cls_TTDMQuan TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMQuan()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMQuan();
            m_Action = ActionRec.None;
        }
        public ObDMQuan(ObDMQuan cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _MaTinh = cls._MaTinh;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMQuan
    {
        public Cls_TTDMQuan(){
        }
        public Cls_TTDMQuan(Cls_TTDMQuan cls)
        {
        }
    }
}
