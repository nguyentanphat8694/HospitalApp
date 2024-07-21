using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObImage : ObservableCollection<ObImage>
    {
        /*
        public static bool var_Update = false;
        public bool AddOb(ObImage ob) {
            bool va= NTPObImage.Insert(ob) != 0;
            return va;
        }
        public bool UpdateOb(ObImage ob) {
            bool va= NTPObImage.Update(ob) != 0;
            return va;
        }
        public bool DeleteOb(ObImage ob) {
            return NTPObImage.Delete(ob) != 0;
        }
        public ObImage GetOb(double ma) {
            return NTPObImage.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObImage.GetNextID();
        }
         * */
    }
}
