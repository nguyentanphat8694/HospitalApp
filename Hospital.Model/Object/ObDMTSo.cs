using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDMTSo
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMTSo _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMTSo TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMTSo()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMTSo();
            m_Action = ActionRec.None;
        }
        public ObDMTSo(ObDMTSo cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMTSo
    {
        string _DonVi = "";
        double _DG = 0;
        string _Nhom = "";
        public string DonVi { get { return _DonVi; } set { _DonVi = value; } }
        public double DG { get { return _DG; } set { _DG = value; } }
        public string Nhom { get { return _Nhom; } set { _Nhom = value; } }
        public Cls_TTDMTSo(){
        }
        public Cls_TTDMTSo(Cls_TTDMTSo cls)
        {
            _DonVi = cls.DonVi;
            _DG = cls.DG;
            _Nhom = cls.Nhom;
        }
    }
}
