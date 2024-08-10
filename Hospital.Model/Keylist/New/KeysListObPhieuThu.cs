using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObPhieuThu : ObservableCollection<ObPhieuThu>
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

        public bool AddOb(ObPhieuThu ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuThu.Insert(ob) != 0;
            ObRecord rc = new ObRecord("", eTableName.PhieuThu.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObPhieuThu ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuThu.Update(ob) != 0;
            ObRecord rc = new ObRecord("", eTableName.PhieuThu.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool DeleteOb(ObPhieuThu ob) {
            return NTPObPhieuThu.Delete(ob) != 0;
        }
        public ObPhieuThu GetOb(double ma)
        {
            return NTPObPhieuThu.GetObWF_PK(ma);
        }
        public bool UpdateOb(ObPhieuThu ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObPhieuThu.Update(ob, trangThai) != 0;
            ObRecord rc = new ObRecord("", eTableName.PhieuThu.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

    }
}
