using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMTSo:ObservableCollection<ObDMTSo>
    {
        public bool AddOb(ObDMTSo ob)
        {
            this.Add(ob);
            return NTPObDMTSo.Insert(ob) > 0;
        }

        public bool UpdateOb(string ma, ObDMTSo ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMTSo.Update(ma, ob) > 0;
        }

        public bool DeleteOb(ObDMTSo ob)
        {
            return NTPObDMTSo.Delete(ob) > 0;
        }

        public ObDMTSo GetOb(string ma)
        {
            return NTPObDMTSo.GetObWF_PK(ma);
        }

        public ObDMTSo Get(string ma) {
            ObDMTSo dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
