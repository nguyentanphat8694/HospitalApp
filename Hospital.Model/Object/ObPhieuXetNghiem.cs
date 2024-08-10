using System;
using System.Collections.Generic;

namespace Hospital.App
{
    [Serializable]
    public class ObPhieuXetNghiem:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public DateTime NgayTra { get; set; }
        public string ChanDoan { get; set; }
        public bool Valid { get; set; }
        public string BSThucHien { get; set; }
        public string KTV1 { get; set; }
        public string KTV2 { get; set; }
        public string KTV3 { get; set; }
        public ClsTTPhieuXetNghiem TTChung { get; set; }
        public void SetNew(ObPhieuXetNghiem ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            NgayTra = ob.NgayTra;
            ChanDoan = ob.ChanDoan;
            Valid = ob.Valid;
            BSThucHien = ob.BSThucHien;
            KTV1 = ob.KTV1;
            KTV2 = ob.KTV2;
            KTV3 = ob.KTV3;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }
        public ObPhieuXetNghiem() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            NgayTra = MainNTP.MinValue;
            ChanDoan = "";
            Valid = false;
            BSThucHien = "";
            KTV1 = "";
            KTV2 = "";
            KTV3 = "";
            TTChung = new ClsTTPhieuXetNghiem();
            TrangThai = etrangthai.Đang_chờ.ToString();
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
        }
        public ObPhieuXetNghiem(ObPhieuXetNghiem ob)
        {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            NgayTra = ob.NgayTra;
            ChanDoan = ob.ChanDoan;
            Valid = ob.Valid;
            BSThucHien = ob.BSThucHien;
            KTV1 = ob.KTV1;
            KTV2 = ob.KTV2;
            KTV3 = ob.KTV3;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }

        public string TenBSThucHien
        {
            get
            {
                if (NTPValidate.IsEmpty(BSThucHien)) return "";
                ObDMNhanSu ns = MainNTP.ObDMNhanSuList.Get(BSThucHien);
                return ns != null ? ns.Ten : BSThucHien;
            }
        }
    }
    [Serializable]
    public class ClsTTPhieuXetNghiem
    {
        public string KetLuan { get; set; }
        public List<ObCTXetNghiem> ObCTXetNghiems { get; set; }
        public bool DaXuLy { get; set; }
        public ClsTTPhieuXetNghiem() {
            ObCTXetNghiems = new List<ObCTXetNghiem>();
            KetLuan = "";
            DaXuLy = false;
        }
        public ClsTTPhieuXetNghiem(ClsTTPhieuXetNghiem cls) {
            ObCTXetNghiems = cls.ObCTXetNghiems;
            KetLuan = cls.KetLuan;
            DaXuLy = cls.DaXuLy;
        }

        public System.Drawing.Color BgColor { get; set; }
    }
}
