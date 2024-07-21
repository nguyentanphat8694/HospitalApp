using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObHenKham:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }
        
        public DateTime NgayDenKham { get; set; }
        
        public ClsTTHenKham TTChung { get; set; }
        public string ChanDoan { get; set; }
        public ObHenKham() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            MaBA = 0;
            NgayDenKham = MainNTP.MinValue;
            TTChung = new ClsTTHenKham();
            TrangThai = "";
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
            ChanDoan = "";
        }

        public void SetNew(ObHenKham ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = ob.MaBA;
            NgayDenKham = ob.NgayDenKham;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
            ChanDoan = ob.ChanDoan;
        }
    }
    [Serializable]
    public class ClsTTHenKham {
        public string SoNgay { get; set; }
        public string NoiDung { get; set; }
        public DateTime GioHK { get; set; }
        public int nNgay { get; set; }
        public string IDCTChiDinh { get; set; }
    }
}
