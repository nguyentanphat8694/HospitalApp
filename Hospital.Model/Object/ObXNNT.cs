using System;

namespace Hospital.App.Object
{
    [Serializable]
    public class ObXNNT:ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public double MaBA { get; set; }
        public string ChanDoan { get; set; }
        public double KeyCTChiDinh { get; set; }
        public string BSThucHien { get; set; }
        public string MaMau { get; set; }
        public string NoiDungMau { get; set; }
        public string KetLuan { get; set; }
    }
}
