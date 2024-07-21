using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMKho:ObservableCollection<ObDMKho>
    {
        public bool AddOb(ObDMKho ob)
        {
            this.Add(ob);
            return NTPObDMKho.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMKho ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMKho.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMKho ob)
        {
            return NTPObDMKho.Delete(ob) > 0;
        }
        public ObDMKho GetOb(string ma)
        {
            return NTPObDMKho.GetObWF_Kho(ma);
        }
        public ObDMKho Get(string ma)
        {
            ObDMKho dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
