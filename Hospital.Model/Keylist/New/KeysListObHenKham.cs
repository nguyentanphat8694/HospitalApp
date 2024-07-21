using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObHenKham : ObservableCollection<ObHenKham>
    {
        public bool AddOb(ObHenKham ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObHenKham.Insert(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObHenKham ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObHenKham.Update( ob) > 0;
            return va;
        }
        public bool DeleteOb(ObHenKham ob) {
            return NTPObHenKham.Delete(ob) > 0;
        }
        public ObHenKham GetOb(double ma)
        {
            return NTPObHenKham.GetObWF_PK(ma);
        }

        public ObHenKham GetOb(string maBN,DateTime ngay)
        {
            return NTPObHenKham.GetObWF_PK(maBN, ngay);
        }

        public double GetID() {
            return NTPObHenKham.GetNextID();
        }
    }
}
