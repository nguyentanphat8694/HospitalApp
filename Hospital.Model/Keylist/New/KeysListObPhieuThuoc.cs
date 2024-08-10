using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObPhieuThuoc : ObservableCollection<ObPhieuThuoc>
    {
        public static bool var_Update = false;
        public bool AddOb(ObPhieuThuoc ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuThuoc.Insert(ob) != 0;
            return va;
        }
        public bool UpdateOb(ObPhieuThuoc ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuThuoc.Update(ob) != 0;
            return va;
        }
        public bool DeleteOb(ObPhieuThuoc ob) {
            return NTPObPhieuThuoc.Delete(ob) != 0;
        }
        public ObPhieuThuoc GetOb(double ma)
        {
            return NTPObPhieuThuoc.GetObWF_PK(ma);
        }

        public double GetID()
        {
            return NTPObPhieuThuoc.GetNextID();
        }
    }
}
