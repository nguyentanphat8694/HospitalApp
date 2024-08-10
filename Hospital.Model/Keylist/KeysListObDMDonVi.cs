using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMDonVi:ObservableCollection<ObDMDonVi>
    {
        public bool AddOb(ObDMDonVi ob)
        {
            this.Add(ob);
            return NTPObDMDonVi.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMDonVi ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMDonVi.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMDonVi ob)
        {
            return NTPObDMDonVi.Delete(ob) > 0;
        }
        public ObDMDonVi GetOb(string ma)
        {
            return NTPObDMDonVi.GetObWF_PK(ma);
        }
        public ObDMDonVi Get(string ma)
        {
            ObDMDonVi dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

    }
}
