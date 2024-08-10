using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObPhieuXetNghiem : ObservableCollection<ObPhieuXetNghiem>
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
        public bool AddOb(ObPhieuXetNghiem ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuXetNghiem.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.PhieuXetNghiem.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObPhieuXetNghiem ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObPhieuXetNghiem.Update(ob) > 0;

            ObRecord rc = new ObRecord("", eTableName.PhieuXetNghiem.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool UpdateOb(ObPhieuXetNghiem ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObPhieuXetNghiem.Update(ob,trangThai) > 0;
            ObRecord rc = new ObRecord("", eTableName.PhieuXetNghiem.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool DeleteOb(ObPhieuXetNghiem ob) {
            return NTPObPhieuXetNghiem.Delete(ob) != 0;
        }
        public ObPhieuXetNghiem GetOb(double ma) {
            return NTPObPhieuXetNghiem.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObPhieuXetNghiem.GetNextID();
        }
    }
}
