using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObCDHA : ObservableCollection<ObCDHA>
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
        public bool AddOb(ObCDHA ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCDHA.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.CDHA.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObCDHA ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCDHA.Update(ob) > 0;

            ObRecord rc = new ObRecord("", eTableName.CDHA.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool UpdateOb(ObCDHA ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObCDHA.Update(ob,trangThai) > 0;
            ObRecord rc = new ObRecord("", eTableName.CDHA.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool DeleteOb(ObCDHA ob) {
            return NTPObCDHA.Delete(ob) != 0;
        }
        public ObCDHA GetOb(double ma) {
            return NTPObCDHA.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObCDHA.GetNextID();
        }
    }
}
