using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObSinhHieu : ObStatus
    {
        public double Ma { get; set; }
        public DateTime Ngay { get; set; }
        public string MaBN { get; set; }
        public ClsTTSinhHieu TTChung { get; set; }
        public ObSinhHieu() {
            Ma = 0;
            Ngay = MainNTP.MinValue;
            MaBN = "";
            TTChung = new ClsTTSinhHieu();
        }
    }
    [Serializable]
    public class ClsTTSinhHieu {
        public string Mach { get; set; }
        public string NhietDo { get; set; }
        public string ChieuCao { get; set; }
        public string CanNang { get; set; }
        public string HAMax { get; set; }
        public string HAMin { get; set; }
        public string NhipTho { get; set; }
        public string BMI { get; set; }
        public string Para { get; set; }
    }
}
