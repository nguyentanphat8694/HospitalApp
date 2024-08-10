using System;

namespace Hospital.App
{
    [Serializable]
    public class ObCTXetNghiem
    {
        public string MaXN { get; set; }
        public string MaDV { get; set; }
        public double KeyCTChiDinh { get; set; }
        public string MaBN { get; set; }
        public string KetQua { get; set; }
        public bool Valid { get; set; }
        public bool BinhThuong { get; set; }
        public string CSBT { get; set; }
        private string _TenXN = "";
        public string TenXN {
            get {
                ObDMXetNghiem dm = MainNTP.ObDMXetNghiemList.Get(MaXN);
                if (_TenXN == "" || _TenXN == null)
                {
                    _TenXN = dm == null ? "" : dm.Ten;
                }

                return _TenXN;
            }
            set
            {
                _TenXN = value;
            }
        }
        public string SetCSBT(bool Nam)
        {
            ObDMXetNghiem dm = MainNTP.ObDMXetNghiemList.Get(MaXN);
            if (dm == null) return "";
            if (dm.TTChung.ChiSoBinhThuong.Trim() != "")
                return dm.TTChung.ChiSoBinhThuong;
            if (Nam)
                return "(" + dm.TTChung.NamDuoi + "-" + dm.TTChung.NamTren + ")";
            return "(" + dm.TTChung.NuDuoi + "-" + dm.TTChung.NuTren + ")";

        }
        public ObCTXetNghiem() {
            MaXN = "";
            MaDV = "";
            KeyCTChiDinh = 0;
            MaBN = "";
            KetQua = "";
            Valid = false;
            BinhThuong = false;
            CSBT = "";
            TenXN = "";
        }
        public ObCTXetNghiem(ObCTXetNghiem ob)
        {
            MaXN = ob.MaXN;
            MaDV = ob.MaDV;
            KeyCTChiDinh = ob.KeyCTChiDinh;
            MaBN = ob.MaBN;
            KetQua = ob.KetQua;
            Valid = ob.Valid;
            BinhThuong = ob.BinhThuong;
            CSBT = ob.CSBT;
            TenXN = ob.TenXN;
        }
    }
}
