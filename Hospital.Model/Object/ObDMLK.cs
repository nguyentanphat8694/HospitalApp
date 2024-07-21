using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDMLK
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMLK _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMLK TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMLK()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMLK();
            m_Action = ActionRec.None;
        }
        public ObDMLK(ObDMLK cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMLK
    {
        string _MaDV = "", _MaPK = "", _Mau = "";
        public string MaDV { get { return _MaDV; } set { _MaDV = value; } }
        public string MaPK { get { return _MaPK; } set { _MaPK = value; } }
        public string Mau { get { return _Mau; } set { _Mau = value; } }
        public Cls_TTDMLK(){
        }
        public Cls_TTDMLK(Cls_TTDMLK cls)
        {
            _MaDV = cls.MaDV;
            _MaPK = cls.MaPK;
            _Mau = cls.Mau;
        }
    }
}
