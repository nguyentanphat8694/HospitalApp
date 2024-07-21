using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ClsDichVu:ObCTChiDinh
    {
        public string Ten { get; set; }
        public string HamLuong { get; set; }
        public string DuongDung { get; set; }
        public string HoatChat { get; set; }
        public string TenNhom
        {
            get
            {
                if (MaDV == "") return "";
                ObDMDichVu dv = MainNTP.ObDMDichVuList.Get(MaDV);
                if (dv == null) return "";
                ObDMNhomDichVu dm = MainNTP.ObDMNhomDichVuList.Get(dv.TTChung.Nhom);
                return dm == null ? "" : dm.Ten;
            }
            set { }
        }
        public string MaPK { get; set; }
        public bool TinhTon { get; set; }
        public double SLTon { get {
            double slton = KeysListObSLTon.GetSLTon(MaDV);
            return (!TinhTon) ? 0 : slton;
        } }
        public ClsDichVu() {
            Ten = "";
            MaPK = "";
        }

        public bool HoanThanh {
            get {
                return KeyThucHien > 0;
            }
        }
        public bool DaThu
        {
            get
            {
                return KeyPT > 0;
            }
        }
        
    }
}
