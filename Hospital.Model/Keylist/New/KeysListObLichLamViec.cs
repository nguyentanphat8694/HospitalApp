using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObLichLamViec:ObservableCollection<ObLichLamViec>
    {
        public bool AddOb(ObLichLamViec ob)
        {
            return NTPObLichLamViec.Insert(ob) > 0;
        }
        public bool UpdateOb(ObLichLamViec ob)
        {
            return NTPObLichLamViec.Update(ob) >0;
        }
        public bool DeleteOb(ObLichLamViec ob)
        {
            return NTPObLichLamViec.Delete(ob) > 0;
        }
        public ObLichLamViec GetOb(string maNS, DateTime ngay)
        {
            return NTPObLichLamViec.GetObWF_PK(maNS, ngay);
        }

        public ObLichLamViec Get(string maNS,DateTime ngay)
        {
            ObLichLamViec dm = this.FirstOrDefault(o => o.MaNS == maNS && o.Ngay==ngay);
            return dm;
        }
    }
}
