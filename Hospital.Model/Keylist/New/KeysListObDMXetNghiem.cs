using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.App
{
    public class KeysListObDMXetNghiem : ObservableCollection<ObDMXetNghiem>
    {
        public bool AddOb(ObDMXetNghiem ob)
        {
            return NTPObDMXetNghiem.Insert(ob) != 0;
        }
        public bool UpdateOb(string ma, ObDMXetNghiem ob)
        {
            return NTPObDMXetNghiem.Update(ma, ob) != 0;
        }
        public bool DeleteOb(ObDMXetNghiem ob)
        {
            return NTPObDMXetNghiem.Delete(ob) != 0;
        }
        public ObDMXetNghiem GetOb(string ma)
        {
            return NTPObDMXetNghiem.GetObWF_PK(ma);
        }

        public ObDMXetNghiem Get(string ma)
        {
            ObDMXetNghiem dm = this.FirstOrDefault(o => o.Ma == ma);
            if (dm == null)
                return GetOb(ma);
            return dm;
        }

        public List<ObDMXetNghiem> Get_MaDV(string maDV) {
            return this.Where(o => o.MaDV == maDV).ToList();
        }
    }
}
