using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMTinh:ObservableCollection<ObDMTinh>
    {
        public bool AddOb(ObDMTinh ob)
        {
            this.Add(ob);
            return NTPObDMTinh.Insert(ob) > 0;
        }

        public bool UpdateOb(string ma, ObDMTinh ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }

            return NTPObDMTinh.Update(ma, ob) > 0;
        }

        public bool DeleteOb(ObDMTinh ob)
        {
            return NTPObDMTinh.Delete(ob) > 0;
        }

        public ObDMTinh GetOb(string ma)
        {
            return NTPObDMTinh.GetObWF_PK(ma);
        }

        public ObDMTinh Get(string ma)
        {
            ObDMTinh dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

    }
}
