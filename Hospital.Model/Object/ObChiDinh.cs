using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObChiDinh:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }
        public string ChanDoan { get; set; }
        public ClsTTChiDinh TTChung { get; set; }
        public ObChiDinh() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            MaBA = 0;
            ChanDoan = "";
            TTChung = new ClsTTChiDinh();
            
        }
        public void SetNew(ObChiDinh ob) {
            Ma = ob.Ma;
            Ngay = ob.Ngay;
            MaBN = ob.MaBN;
            MaBA = 0;
            ChanDoan = ob.ChanDoan;
            TTChung = ob.TTChung;
            TrangThai = ob.TrangThai;
            CreateBy = ob.CreateBy;
            CreateTime = ob.CreateTime;
            UpdateBy = ob.UpdateBy;
            UpdateTime = ob.UpdateTime;
            DeleteBy = ob.DeleteBy;
            DeleteTime = ob.DeleteTime;
        }

        public List<ObCTChiDinh> DSDichVu
        {
            get
            {
                return MainNTP.ObCTChiDinhList.GetListOb(Ma, (int)eLoaiHH.Dịch_vụ).ToList();
            }
        }

        public double TongChiPhi
        {
            get
            {
                return DSDichVu.Sum(o => o.ThanhTien);
            }
        }
    }
    [Serializable]
    public class ClsTTChiDinh
    {
        public ClsTTChiDinh() {
        }
    }
}
