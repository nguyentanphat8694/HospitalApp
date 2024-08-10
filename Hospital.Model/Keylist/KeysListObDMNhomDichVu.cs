using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMNhomDichVu:ObservableCollection<ObDMNhomDichVu>
    {
        public bool AddOb(ObDMNhomDichVu ob)
        {
            this.Add(ob);
            return NTPObDMNhomDichVu.Insert(ob) >0;
        }
        public bool UpdateOb(string ma, ObDMNhomDichVu ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMNhomDichVu.Update(ma, ob) >  0;
        }
        public bool DeleteOb(ObDMNhomDichVu ob)
        {
            return NTPObDMNhomDichVu.Delete(ob) > 0;
        }
        public ObDMNhomDichVu GetOb(string ma)
        {
            return NTPObDMNhomDichVu.GetObWF_PK(ma);
        }

        public ObDMNhomDichVu Get(string ma) {
            ObDMNhomDichVu dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
