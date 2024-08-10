using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObDMNhomXetNghiem:ObservableCollection<ObDMNhomXetNghiem>
    {
        public bool AddOb(ObDMNhomXetNghiem ob)
        {
            return NTPObDMNhomXetNghiem.Insert(ob) > 0;
        }
        public bool UpdateOb(string ma, ObDMNhomXetNghiem ob)
        {
            return NTPObDMNhomXetNghiem.Update(ma, ob) > 0;
        }
        public bool DeleteOb(ObDMNhomXetNghiem ob)
        {
            return NTPObDMNhomXetNghiem.Delete(ob) > 0;
        }
        public ObDMNhomXetNghiem GetOb(string ma)
        {
            return NTPObDMNhomXetNghiem.GetObWF_PK(ma);
        }

        public ObDMNhomXetNghiem Get(string ma) {
            ObDMNhomXetNghiem dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }
    }
}
