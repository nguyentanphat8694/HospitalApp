using System;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObTKBenhNhan : ObservableCollection<ObTKBenhNhan>
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
        public bool AddOb(ObTKBenhNhan ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObTKBenhNhan.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.TKBenhNhan.ToString(), ob.ID.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObTKBenhNhan ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObTKBenhNhan.Update(ob) > 0;

            ObRecord rc = new ObRecord("", eTableName.TKBenhNhan.ToString(), ob.ID.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public ObTKBenhNhan GetOb(Guid ID)
        {
            return NTPObTKBenhNhan.GetObWF_PK(ID);
        }
    }
}
