using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMPK:ObservableCollection<ObDMPK>
    {
        public bool AddOb(ObDMPK ob)
        {
            this.Add(ob);
            return NTPObDMPK.Insert(ob) > 0;
        }

        public bool UpdateOb(string ma, ObDMPK ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMPK.Update(ma, ob) > 0;
        }

        public bool DeleteOb(ObDMPK ob)
        {
            return NTPObDMPK.Delete(ob) > 0;
        }

        public ObDMPK GetOb(string ma)
        {
            return NTPObDMPK.GetObWF_PK(ma);
        }

        public ObDMPK Get(string ma)
        {
            ObDMPK dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
