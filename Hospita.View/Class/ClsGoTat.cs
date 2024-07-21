using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class ClsGoTat
    {
        public string Ma { get; set; }
        public string Ten { get; set; }

        public ClsGoTat()
        {
        }

        public ClsGoTat(string ma, string ten)
        {
            Ma = ma;
            Ten = ten;
        }
    }
}
