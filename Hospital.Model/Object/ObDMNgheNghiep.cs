using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDMNgheNghiep
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai;
        Cls_TTDMNgheNghiep _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMNgheNghiep TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMNgheNghiep()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMNgheNghiep();
            m_Action = ActionRec.None;
        }
        public ObDMNgheNghiep(ObDMNgheNghiep cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls._Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMNgheNghiep
    {
        public Cls_TTDMNgheNghiep(){
        }
        public Cls_TTDMNgheNghiep(Cls_TTDMNgheNghiep cls)
        {
        }
    }
}
