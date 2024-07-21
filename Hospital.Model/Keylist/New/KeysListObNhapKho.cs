using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObNhapKho : ObservableCollection<ObNhapKho>
    {
        public static bool var_Update = false;
        public bool AddOb(ObNhapKho ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObNhapKho.Insert(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObNhapKho ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObNhapKho.Update( ob) > 0;
            return va;
        }
        public bool UpdateOb(ObNhapKho ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObNhapKho.Update(ob,trangThai) > 0;
            return va;
        }
        public bool DeleteOb(ObNhapKho ob) {
            return NTPObNhapKho.Delete(ob) != 0;
        }
        public ObNhapKho GetOb(double ma)
        {
            return NTPObNhapKho.GetObWF_PK(ma);
        }

        public double GetID() {
            return NTPObNhapKho.GetNextID();
        }
    }
}
