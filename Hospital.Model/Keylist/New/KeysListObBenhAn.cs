using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObBenhAn : ObservableCollection<ObBenhAn>
    {
        public static bool var_Update = false;
        public delegate void DBChanged(ObRecord _obRecord);
        public event DBChanged ChangeDB;
        protected virtual void _ChangeDB(ObRecord _obRecord)
        {
            if (ChangeDB != null)
            {
                ChangeDB(_obRecord);
            }
        }
        //public static bool var_Update = false;
        public bool AddOb(ObBenhAn ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObBenhAn.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.BenhAn.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObBenhAn ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObBenhAn.Update(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.BenhAn.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool UpdateOb(ObBenhAn ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObBenhAn.Update(ob, trangThai) > 0;
            ObRecord rc = new ObRecord("", eTableName.BenhAn.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool DeleteOb(ObBenhAn ob) {
            return NTPObBenhAn.Delete(ob) > 0;
        }
        public ObBenhAn GetOb(double ma) {
            return NTPObBenhAn.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObBenhAn.GetNextID();
        }
    }
}
