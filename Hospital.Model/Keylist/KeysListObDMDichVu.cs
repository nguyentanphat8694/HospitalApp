using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMDichVu:ObservableCollection<ObDMDichVu>
    {
        public bool AddOb(ObDMDichVu ob)
        {
            this.Add(ob);
            return NTPObDMDichVu.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMDichVu ob)
        {
            return NTPObDMDichVu.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMDichVu ob)
        {
            return NTPObDMDichVu.Delete(ob) > 0;
        }
        public ObDMDichVu GetOb(string ma)
        {
            return NTPObDMDichVu.GetObWF_PK(ma);
        }

        public ObDMDichVu Get(string ma) {
            ObDMDichVu dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
