using System.Collections.Generic;

namespace Hospital.App
{
    public class ClsTKDichVu
    {
        public int STT { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public double SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien {
            get {
                return SoLuong * DonGia;
            }
        }
        public string BacSi { get; set; }
        public string TenBacSi { get; set; }
        public List<ClsTKDichVu> DSDichVu { get; set; }
    }
}
