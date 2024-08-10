using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObPhacDo : ObservableCollection<ObPhacDo>
    {
        public bool AddOb(ObPhacDo ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhacDo.Insert(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObPhacDo ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhacDo.Update(ob) > 0;
            return va;
        }

        public bool DeleteOb(ObPhacDo ob) {
            return NTPObPhacDo.Delete(ob) > 0;
        }
        public ObPhacDo GetOb(double ma) {
            return NTPObPhacDo.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObPhacDo.GetNextID();
        }
    }
}
