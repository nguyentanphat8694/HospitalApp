using System;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObSinhHieu : ObservableCollection<ObSinhHieu>
    {
        public static bool var_Update = false;
        public bool AddOb(ObSinhHieu ob) {
            bool va= NTPObSinhHieu.Insert(ob) != 0;
            return va;
        }
        public bool UpdateOb(ObSinhHieu ob) {
            bool va= NTPObSinhHieu.Update( ob) != 0;
            return va;
        }
        public bool DeleteOb(ObSinhHieu ob) {
            return NTPObSinhHieu.Delete(ob) != 0;
        }
        public ObSinhHieu GetOb(double ma)
        {
            return NTPObSinhHieu.GetObWF_PK(ma);
        }

        public ObSinhHieu GetOb(string maBN,DateTime ngay)
        {
            return NTPObSinhHieu.GetObWF_PK(maBN, ngay);
        }

        public double GetID() {
            return NTPObSinhHieu.GetNextID();
        }
    }
}
