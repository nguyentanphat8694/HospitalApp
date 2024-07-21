using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class NTPValidate
    {
        public static bool IsEmpty(string ob)
        {
            if (ob == null || ob.Trim() == "") return true;
            return false;
        }
    }
}
