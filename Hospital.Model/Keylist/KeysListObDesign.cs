using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDesign:ObservableCollection<ObDesign>
    {
        public bool AddOb(ObDesign ob)
        {
            return NTPObDesign.Insert(ob) != 0;
        }
        
        public bool UpdateOb(string ma, ObDesign ob)
        {
            return NTPObDesign.Update(ma, ob) != 0;
        }
        
        public bool DeleteOb(ObDesign ob)
        {
            return NTPObDesign.Delete(ob) != 0;
        }
        
        public ObDesign GetOb(string ma)
        {
            return NTPObDesign.GetObWF_PK(ma);
        }

        public ObDesign Get(string ma)
        {
            ObDesign dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
