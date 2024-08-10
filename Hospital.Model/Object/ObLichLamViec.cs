using System;

namespace Hospital.App
{
    [Serializable]
    public class ObLichLamViec
    {
        public string MaNS { get; set; }
        public DateTime Ngay { get; set; }
        public ClsTTLichLamViec TTChung { get; set; }

        public ObLichLamViec() {
            MaNS = "";
            Ngay = MainNTP.MinValue;
            TTChung = new ClsTTLichLamViec();
        }
    }

    [Serializable]
    public class ClsTTLichLamViec {
        public bool Nghi { get; set; }
        public ClsTTLichLamViec() {
            Nghi = false;
        }
    }
}
