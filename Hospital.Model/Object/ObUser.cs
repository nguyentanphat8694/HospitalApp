using System;
using System.Drawing;

namespace Hospital.App
{
    [Serializable]
    public class ObUser
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        Cls_TTUser _TTChung;
        public string UserName { get { return _Ma; } set { _Ma = value; } }
        public string PassWord { get { return _Ten; } set { _Ten = value; } }
        public Cls_TTUser TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObUser()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTUser();
            m_Action = ActionRec.None;
        }
        public ObUser(ObUser cls)
        {
            _Ma = cls.UserName;
            _Ten = cls.PassWord;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
        public ePhanquyen eQuyen {
            get {
                return MainNTP.listQuyen.Find(o => o.ToString() == TTChung.Quyen);
            }
        }
        public string TenUser {
            get {
                if (TTChung == null || MainNTP.ObDMNhanSuList==null) return "";
                ObDMNhanSu ns = MainNTP.ObDMNhanSuList.GetOb(TTChung.MaNS);
                if (ns == null) return TTChung.MaNS;
                return ns.Ten;
            }
        }
    }
    [Serializable]
    public class Cls_TTUser
    {
        string _MaNS;
        public string MaNS { get { return _MaNS==null?"":_MaNS; } set { _MaNS = value; } }
        Image _Hinhanh;
        public Image Hinhanh { get { return _Hinhanh; } set { _Hinhanh = value; } }
        string _Quyen;
        string _NhomDV;
        public string Quyen { get { return _Quyen; } set { _Quyen = value; } }
        public string NhomDV { get { return string.IsNullOrEmpty(_NhomDV) ? "" : _NhomDV; } set { _NhomDV = value; } }
        public Cls_TTUser(){
            _Hinhanh = null;
            _Quyen = "";
            _MaNS = "";
            _NhomDV = "";
        }
        public Cls_TTUser(Cls_TTUser cls)
        {
            _MaNS = cls.MaNS;
            _Hinhanh = cls.Hinhanh;
            _Quyen = cls.Quyen;
            _NhomDV = cls.NhomDV;
        }
    }
}
