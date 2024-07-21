using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObBenhAn : ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }
        public string ChanDoanChinh { get; set; }
        public string ChanDoanPhu { get; set; }
        public double KeyCTChiDinh { get; set; }
        public string BSThucHien { get; set; }
        public ClsTTBenhAn TTChung { get; set; }
        public string Para { get; set; }
        
        
        public ObBenhAn() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            MaBA = 0;
            ChanDoanChinh = "";
            ChanDoanPhu = "";
            KeyCTChiDinh = 0;
            BSThucHien = "";
            TTChung = new ClsTTBenhAn();
        }
        public ObBenhAn(ObBenhAn ob)
        {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = ob.MaBA;
            ChanDoanChinh = ob.ChanDoanChinh;
            ChanDoanPhu = ob.ChanDoanPhu;
            KeyCTChiDinh = ob.KeyCTChiDinh;
            BSThucHien = ob.BSThucHien;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }

        public void SetNew(ObBenhAn ob)
        {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = ob.MaBA;
            ChanDoanChinh = ob.ChanDoanChinh;
            ChanDoanPhu = ob.ChanDoanPhu;
            KeyCTChiDinh = ob.KeyCTChiDinh;
            BSThucHien = ob.BSThucHien;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;

            //if (TTChung.NgayChiDinh != null && TTChung.NgayChiDinh != MainNTP.MinValue)
            //{
            //    if (MainNTP.ObSinhHieuList == null)
            //    {
            //        MainNTP.ObSinhHieuList = new KeysListObSinhHieu();
            //    }

            //    var sh = MainNTP.ObSinhHieuList.GetOb(MaBN, TTChung.NgayChiDinh);
            //    if (sh != null)
            //    {
            //        Para = sh.TTChung.Para;
            //    }
            //}
        }

        public string TenBSThucHien { get {
            if (NTPValidate.IsEmpty(BSThucHien)) return "";
            ObDMNhanSu ns = MainNTP.ObDMNhanSuList.Get(BSThucHien);
            return ns != null ? ns.Ten : BSThucHien;
        } }
    }

    [Serializable]
    public class ClsTTBenhAn
    {
        public string MaMau { get; set; }
        public string NoiDungMau { get; set; }
        public string LoiDan { get; set; }
        public bool DaKham { get; set; }
        public DateTime NgayChiDinh { get; set; }

        public string TuoiThai2 { get; set; }
        public decimal iTuoiThai2 { get; set; }
        public string sDonViTuoiThai2 { get; set; }
        public DateTime NgayDuSanh2 { get; set; }
    }
}

