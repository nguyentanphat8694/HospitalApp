using System;
using System.Collections.Generic;

namespace Hospital.App
{
    [Serializable]
    public class ObCDHA:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }//1 là thai, 0 là bình thường
        public string ChanDoan { get; set; }
        public double KeyCTChiDinh { get; set; }
        public string BSThucHien { get; set; }
        public string KTV1 { get; set; }
        public string KTV2 { get; set; }
        public string KTV3 { get; set; }
        public string Para { get; set; }
        public ClsTTCDHA TTChung { get; set; }
        public string KetLuan { get; set; }
        public void SetNew(ObCDHA ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = ob.MaBA;
            ChanDoan = ob.ChanDoan.ToUpper();
            KeyCTChiDinh = ob.KeyCTChiDinh;
            BSThucHien = ob.BSThucHien;
            KTV1 = ob.KTV1;
            KTV2 = ob.KTV2;
            KTV3 = ob.KTV3;
            TTChung.SetNew(ob.TTChung);
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
            KetLuan = ob.KetLuan;
            if (TTChung.NgayChiDinh != null && TTChung.NgayChiDinh != MainNTP.MinValue)
            {
                if (MainNTP.ObSinhHieuList == null)
                {
                    MainNTP.ObSinhHieuList = new KeysListObSinhHieu();
                }

                var sh = MainNTP.ObSinhHieuList.GetOb(MaBN, TTChung.NgayChiDinh);
                if (sh != null)
                {
                    Para = sh.TTChung.Para;
                }
            }
        }
        public ObCDHA() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            MaBA = 0;
            ChanDoan = "";
            KeyCTChiDinh = 0;
            BSThucHien = "";
            KTV1 = "";
            KTV2 = "";
            KTV3 = "";
            TTChung = new ClsTTCDHA();
            TrangThai = etrangthai.Đang_chờ.ToString();
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
            KetLuan = "";
        }
        public ObCDHA(ObCDHA ob)
        {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = ob.MaBA;
            ChanDoan = ob.ChanDoan;
            KeyCTChiDinh = ob.KeyCTChiDinh;
            BSThucHien = ob.BSThucHien;
            KTV1 = ob.KTV1;
            KTV2 = ob.KTV2;
            KTV3 = ob.KTV3; 
            TTChung = new ClsTTCDHA();
            TTChung.SetNew(ob.TTChung);
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
            KetLuan = ob.KetLuan;
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
    public class ClsTTCDHA : ClsTTBenhAn
    {
        public string DeNghi { get; set; }
        public List<ObImage> Images { get; set; }
        public DateTime NgayKinhCuoi { get; set; }
        public DateTime NgayDuSanh { get; set; }
        public bool SAThai { get; set; }
        public decimal SoTuoiThai { get; set; }
        public string TuoiThai { get; set; }
        public DateTime NgayChiDinh { get; set; }
        public void SetNew(ClsTTCDHA cls)
        {
            DeNghi = cls.DeNghi;
            Images = new List<ObImage>();
            if (cls.Images != null)
            {
                foreach (var item in cls.Images)
                {
                    Images.Add(item);
                }
            }
            
            NgayKinhCuoi = cls.NgayKinhCuoi;
            NgayDuSanh = cls.NgayDuSanh;
            SAThai = cls.SAThai;
            SoTuoiThai = cls.SoTuoiThai;
            TuoiThai = cls.TuoiThai;
            MaMau = cls.MaMau;
            NoiDungMau = cls.NoiDungMau;
            LoiDan = cls.LoiDan;
            NgayChiDinh = cls.NgayChiDinh;
        }
        public ClsTTCDHA() {
            DeNghi = "";
            Images = new List<ObImage>();
            NgayKinhCuoi = MainNTP.MinValue;
            NgayDuSanh = MainNTP.MinValue;
            SAThai = false;
            SoTuoiThai = 0;
            TuoiThai = "";
            NgayChiDinh = MainNTP.MinValue;
        }
        public ClsTTCDHA(ClsTTCDHA cls) {
            
        }
    }
}
