using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObDichVuTon
    {
        public string Ma { get; set; }
        public double SLTon { get; set; }
        public double SLNhap { get; set; }
        public double SLXuat { get; set; }

        public ObDichVuTon()
        {
            Ma = "";
            SLTon = 0;
            SLNhap = 0;
            SLXuat = 0;
        }
    }
}
