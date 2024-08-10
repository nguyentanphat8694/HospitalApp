using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMICD:ObservableCollection<ObDMICD>
    {
        public bool AddOb(ObDMICD ob)
        {
            this.Add(ob);
            return NTPObDMICD.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMICD ob)
        {
            var oo = this.FirstOrDefault(o => o.Ma == ma);
            if (oo != null)
            {
                oo.Ma = ob.Ma;
                oo.Ten = ob.Ten;
            }
            return NTPObDMICD.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMICD ob)
        {
            return NTPObDMICD.Delete(ob) > 0;
        }
        public ObDMICD GetOb(string ma)
        {
            return NTPObDMICD.GetObWF_ICD(ma);
        }

        public ObDMICD Get(string ma)
        {
            ObDMICD dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
