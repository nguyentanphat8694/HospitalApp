using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMNgheNghiep:ObservableCollection<ObDMNgheNghiep>
    {
        public bool AddOb(ObDMNgheNghiep ob)
        {
            this.Add(ob);
            return NTPObDMNgheNghiep.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMNgheNghiep ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMNgheNghiep.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMNgheNghiep ob)
        {
            return NTPObDMNgheNghiep.Delete(ob) > 0;
        }
        public ObDMNgheNghiep GetOb(string ma)
        {
            return NTPObDMNgheNghiep.GetObWF_PK(ma);
        }
        public ObDMNgheNghiep Get(string ma)
        {
            ObDMNgheNghiep dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

    }
}
