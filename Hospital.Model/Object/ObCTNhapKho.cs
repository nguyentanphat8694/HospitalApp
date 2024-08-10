using System;

namespace Hospital.App
{
    [Serializable]
    public class ObCTNhapKho : ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaDV { get; set; }
        public double SL { get; set; }
        public double DGNhap { get; set; }
        public double DGBan { get; set; }
        public string Kho { get; set; }
        public string Solo { get; set; }
        public double KeyPhieuNhap { get; set; }
        public ClsTTCTNhapKho TTChung { get; set; }
        public string Ten { get; set; }
        public string Nhom { get; set; }
        public double SLTon { get; set; }
        public ObCTNhapKho()
        {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaDV = "";
            SL = 0;
            DGNhap = 0;
            DGBan = 0;
            Kho = "";
            Solo = "";
            KeyPhieuNhap = 0;
            TTChung = new ClsTTCTNhapKho();
            Ten = "";
            Nhom = "";
            TrangThai = "";
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
        }
        public ObCTNhapKho(ObCTNhapKho ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaDV = ob.MaDV;
            SL = ob.SL;
            DGNhap = ob.DGNhap;
            DGBan = ob.DGBan;
            Kho = ob.Kho;
            Solo = ob.Solo;
            KeyPhieuNhap = ob.KeyPhieuNhap;
            TTChung = ob.TTChung;
            Ten = ob.Ten;
            Nhom = ob.Nhom;
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
    public class ClsTTCTNhapKho
    {
        public double SLTon { get; set; }
        public double SLNhap { get; set; }
        public double SLXuat { get; set; }
    }
}
