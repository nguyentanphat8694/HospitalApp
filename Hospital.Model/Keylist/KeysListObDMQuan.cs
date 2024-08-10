using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMQuan:ObservableCollection<ObDMQuan>
    {
        public bool AddOb(ObDMQuan ob)
        {
            this.Add(ob);
            return NTPObDMQuan.Insert(ob)> 0;
        }

        public bool UpdateOb(string ma, ObDMQuan ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
                oo.MaTinh = ob.MaTinh;
            }
            return NTPObDMQuan.Update(ma, ob) > 0;
        }

        public bool DeleteOb(ObDMQuan ob)
        {
            return NTPObDMQuan.Delete(ob) >0;
        }

        public ObDMQuan GetOb(string ma)
        {
            return NTPObDMQuan.GetObWF_PK(ma);
        }

        public ObDMQuan Get(string ma)
        {
            ObDMQuan dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

    }
}
