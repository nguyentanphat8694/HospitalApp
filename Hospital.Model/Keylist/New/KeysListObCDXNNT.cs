using Hospital.App.Dba;
using Hospital.App.Object;
using System.Collections.ObjectModel;

namespace Hospital.App.Keylist.New
{
    public class KeysListObCDXNNT : ObservableCollection<ObXNNT>
    {
        public bool AddOb(ObXNNT ob)
        {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObXNNT.Insert(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObXNNT ob)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObXNNT.Update(ob) > 0;
            return va;
        }

        public bool UpdateOb(ObXNNT ob, etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObXNNT.Update(ob, trangThai) > 0;
            return va;
        }
        public bool DeleteOb(ObXNNT ob)
        {
            return NTPObXNNT.Delete(ob) != 0;
        }
        public ObXNNT GetOb(double ma)
        {
            return NTPObXNNT.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObXNNT.GetNextID();
        }
    }
}
