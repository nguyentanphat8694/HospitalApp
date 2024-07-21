using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObCTNhapKho : ObservableCollection<ObCTNhapKho>
    {
        public static bool var_Update = false;
        public bool AddOb(ObCTNhapKho ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCTNhapKho.Insert(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObCTNhapKho ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCTNhapKho.Update(ob) > 0;
            return va;
        }
        public bool UpdateOb(ObCTNhapKho ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObCTNhapKho.Update(ob,trangThai) > 0;
            return va;
        }
        public bool DeleteOb(ObCTNhapKho ob) {
            return NTPObCTNhapKho.Delete(ob) != 0;
        }
        public ObCTNhapKho GetOb(double ma)
        {
            return NTPObCTNhapKho.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObCTNhapKho.GetNextID();
        }
    }
}
