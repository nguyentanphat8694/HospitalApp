using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDMMau
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMMau _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMMau TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMMau()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMMau();
            m_Action = ActionRec.None;
        }
        public ObDMMau(ObDMMau cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMMau
    {
        List<string> _DSDichVu = new List<string>();
        string _NoiDung = "";
        string _PhanLoai = "";
        public List<string> DSDichVu { get { return _DSDichVu; } set { _DSDichVu = value; } }
        public string NoiDung { get { return _NoiDung; } set { _NoiDung = value; } }
        public string PhanLoai { get { return _PhanLoai; } set { _PhanLoai = value; } }
        public string KetLuan { get; set; }
        public Cls_TTDMMau(){
        }
        public Cls_TTDMMau(Cls_TTDMMau cls)
        {
            _DSDichVu = cls.DSDichVu;
            _NoiDung = cls.NoiDung;
            _PhanLoai = cls.PhanLoai;
            KetLuan = cls.KetLuan;
        }
    }
}
