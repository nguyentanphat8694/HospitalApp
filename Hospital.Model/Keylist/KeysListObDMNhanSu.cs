using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMNhanSu:ObservableCollection<ObDMNhanSu>
    {
        public bool AddOb(ObDMNhanSu ob)
        {
            this.Add(ob);
            return NTPObDMNhanSu.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMNhanSu ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMNhanSu.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMNhanSu ob)
        {
            return NTPObDMNhanSu.Delete(ob) > 0;
        }
        public ObDMNhanSu GetOb(string ma)
        {
            return NTPObDMNhanSu.GetObWF_PK(ma);
        }

        public ObDMNhanSu Get(string ma)
        {
            ObDMNhanSu dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
