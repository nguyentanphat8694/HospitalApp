using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    [Serializable]
    public class ObKey
    {
        public string IP { get; set; }
        public DateTime Ngay { get; set; }
        public ClsTTKey TTChung { get; set; }
        public ObKey() {
            IP = "";
            Ngay = DateTime.MinValue;
            TTChung = new ClsTTKey();
        }
        public ObKey(ObKey ob)
        {
            IP = ob.IP;
            Ngay = ob.Ngay;
        }
    }
    [Serializable]
    public class ClsTTKey {
        public string PassWord { get; set; }
        public ClsTTKey() {
            PassWord = "";
        }
        public ClsTTKey(ClsTTKey cls) {
            PassWord = cls.PassWord;
        }
    }
}
