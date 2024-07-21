using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObPhieuThuoc:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }
        public string ChanDoan { get; set; }
        public int Loai { get; set; }
        public ClsTTPhieuThuoc TTChung { get; set; }
        public List<ObCTChiDinh> DSDichVu
        {
            get
            {
                return MainNTP.ObCTChiDinhList.GetListOb(Ma, (int)eLoaiHH.Thuốc).ToList();
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
    public class ClsTTPhieuThuoc { }
}
