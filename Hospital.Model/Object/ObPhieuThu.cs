using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObPhieuThu : ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiThu { get; set; }
        public string QuayThu { get; set; }
        public string MaBN { get; set; }
        public double GiamTong { get; set; }
        public ClsTTPhieuThu TTChung { get; set; }

        public ObPhieuThu() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            NguoiThu = "";
            QuayThu = "";
            MaBN = "";
            GiamTong = 0;
            TTChung = new ClsTTPhieuThu();
            
        }

        public void SetNew(ObPhieuThu ob)
        {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            NguoiThu = ob.NguoiThu;
            QuayThu = ob.QuayThu;
            MaBN = ob.MaBN;
            GiamTong = ob.GiamTong;
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
    public class ClsTTPhieuThu {
        public double ThanhToan { get; set; }
        public double KHTra { get; set; }
    }
}
