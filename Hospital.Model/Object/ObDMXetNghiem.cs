using System;

namespace Hospital.App
{
    [Serializable]
    public class ObDMXetNghiem
    {
        public ActionRec _Action { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MaDV { get; set; }
        public Cls_TTDMXetNghiem TTChung { get; set; }
        public ObDMXetNghiem() {
            _Action = ActionRec.None;
            Ma = "";
            Ten = "";
            MaDV = "";
            TTChung = new Cls_TTDMXetNghiem();
        }
        public ObDMXetNghiem(ObDMXetNghiem ob) {
            _Action = ob._Action;
            Ma = ob.Ma;
            Ten = ob.Ten;
            MaDV = ob.MaDV;
            TTChung = ob.TTChung;
        }
    }
    [Serializable]
    public class Cls_TTDMXetNghiem
    {
        public double NamTren { get; set; }
        public double NamDuoi { get; set; }
        public double NuTren { get; set; }
        public double NuDuoi { get; set; }
        public string ChiSoBatThuong { get; set; }
        public string ChiSoBinhThuong { get; set; }
        public string Nhom { get; set; }
        public Cls_TTDMXetNghiem() {
            NamTren = 0;
            NamDuoi = 0;
            NuTren = 0;
            NuDuoi = 0;
            ChiSoBatThuong = "";
            ChiSoBinhThuong = "";
        }
        public Cls_TTDMXetNghiem(Cls_TTDMXetNghiem cls) {
            NamTren = cls.NamTren;
            NamDuoi = cls.NamDuoi;
            NuTren = cls.NuTren;
            NuDuoi = cls.NuDuoi;
            ChiSoBatThuong = cls.ChiSoBatThuong;
            ChiSoBinhThuong = cls.ChiSoBinhThuong;
        }
    }
}
