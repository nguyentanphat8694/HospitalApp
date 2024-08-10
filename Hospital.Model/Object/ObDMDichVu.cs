using System;

namespace Hospital.App
{
    [Serializable]
    public class ObDMDichVu
    {
        ActionRec m_Action;
        public ActionRec _Action { get { return m_Action; } set { m_Action = value; } }
        string _Ma, _Ten;
        int _Loai = -1;
        Cls_TTDMDichVu _TTChung;
        public string Ma { get { return _Ma; } set { _Ma = value; } }
        public string Ten { get { return _Ten; } set { _Ten = value; } }
        public int Loai { get { return _Loai; } set { _Loai = value; } }
        public Cls_TTDMDichVu TTChung { get { return _TTChung; } set { _TTChung = value; } }
        public ObDMDichVu()
        {
            _Ma = "";
            _Ten = "";
            _TTChung = new Cls_TTDMDichVu();
            m_Action = ActionRec.None;
        }
        public ObDMDichVu(ObDMDichVu cls)
        {
            _Ma = cls.Ma;
            _Ten = cls.Ten;
            _Loai = cls.Loai;
            _TTChung = cls.TTChung;
            m_Action = cls._Action;
        }
        public string TenNhom {
            get {
                if (TTChung == null) return "";
                ObDMNhomDichVu dm = MainNTP.ObDMNhomDichVuList.Get(TTChung.Nhom);
                return dm == null ? TTChung.Nhom : dm.Ten;
            }
        }
    }
    [Serializable]
    public class Cls_TTDMDichVu
    {
        string _DonVi = "";
        double _DG = 0;
        string _Nhom = "";
        string _Mau = "";
        DateTime _NgayHetHan = MainNTP.MinValue;
        public string DonVi { get { return _DonVi; } set { _DonVi = value; } }
        public double DG { get { return _DG; } set { _DG = value; } }
        public string Nhom { get { return _Nhom; } set { _Nhom = value; } }
        public string Mau { get { return _Mau; } set { _Mau = value; } }
        public DateTime NgayHetHan { get { return _NgayHetHan; } set { _NgayHetHan = value; } }
        public string HamLuong { get; set; }
        public string DuongDung { get; set; }
        public string HoatChat { get; set; }
        public double DGMua { get; set; }
        public string LanDung { get; set; }
        public string LieuDung { get; set; }
        public string CachDung { get; set; }
        public bool HHThuocKho { get; set; }
        public Cls_TTDMDichVu(){
        }
        public Cls_TTDMDichVu(Cls_TTDMDichVu cls)
        {
            _DonVi = cls.DonVi;
            _DG = cls.DG;
            _Nhom = cls.Nhom;
            _Mau = cls.Mau;
            _NgayHetHan = cls.NgayHetHan;
            HamLuong = cls.HamLuong;
            DuongDung = cls.DuongDung;
            HoatChat = cls.HoatChat;
            DGMua = cls.DGMua;
            LanDung = cls.LanDung;
            LieuDung = cls.LieuDung;
            CachDung = cls.CachDung;
            HHThuocKho = cls.HHThuocKho;
        }
    }
}
