using System;

namespace Hospital.App
{
    [Serializable]
    public class ObNhapKho:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string GhiChu { get; set; }
        public string NguoiNhap { get; set; }
        public string Kho { get; set; }
        public ClsTTNhapKho TTChung { get; set; }
        public string TenNguoiNhap {
            get {
                if (NTPValidate.IsEmpty(NguoiNhap)) return "";
                ObDMNhanSu ns = MainNTP.ObDMNhanSuList.Get(NguoiNhap);
                return ns == null ? NguoiNhap : ns.Ten;
            }
        }

        public ObNhapKho() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            GhiChu = "";
            NguoiNhap = "";
            Kho = "";
            TTChung = new ClsTTNhapKho();
            TrangThai = "";
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
        }
        public ObNhapKho(ObNhapKho ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            GhiChu = ob.GhiChu;
            NguoiNhap = ob.NguoiNhap;
            Kho = ob.Kho;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }
    }
    [Serializable]
    public class ClsTTNhapKho { }
    
}
