using System;

namespace Hospital.App
{
    [Serializable]
    public class ObTKBenhNhan : ObStatus
    {
        public Guid? ID { get; set; }
        public string MaBN { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiThu { get; set; }
        public string QuayThu { get; set; }
        public double ThanhTien { get; set; }
        public double KeyPT { get; set; }
        public ObTKBenhNhan()
        {
            ID = Guid.Empty;
        }
    }
}
