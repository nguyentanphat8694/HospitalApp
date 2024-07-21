using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObDMNhanSu
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        eLoaiNS _Loai = eLoaiNS.Bác_sĩ;
        Cls_TTDMNhanSu _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public eLoaiNS Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMNhanSu TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMNhanSu()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMNhanSu();
            m_Action = ActionRec.None;
        }
        public ObDMNhanSu(ObDMNhanSu cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
    }
    [Serializable]
    public class Cls_TTDMNhanSu
    {
        string _Diachi = "", _Dienthoai = "", _NgaySinh = "";
        public string Diachi { get { return _Diachi; } set { _Diachi = value; } }
        public string Dienthoai { get { return _Dienthoai; } set { _Dienthoai = value; } }
        public string NgaySinh { get { return _NgaySinh; } set { _NgaySinh = value; } }
        public Cls_TTDMNhanSu(){
        }
        public Cls_TTDMNhanSu(Cls_TTDMNhanSu cls)
        {
            _Diachi = cls._Diachi;
            Dienthoai = cls.Dienthoai;
            NgaySinh = cls.NgaySinh;
        }
    }
}
