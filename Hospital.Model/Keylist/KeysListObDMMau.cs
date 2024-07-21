using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMMau:ObservableCollection<ObDMMau>
    {
        public bool AddOb(ObDMMau ob)
        {
            this.Add(ob);
            return NTPObDMMau.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMMau ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMMau.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMMau ob)
        {
            return NTPObDMMau.Delete(ob) > 0;
        }
        public ObDMMau GetOb(string ma)
        {
            return NTPObDMMau.GetObWF_Mau(ma);
        }
        public ObDMMau Get(string ma)
        {
            ObDMMau dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

    }
}
