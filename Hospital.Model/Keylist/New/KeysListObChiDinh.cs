using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObChiDinh : ObservableCollection<ObChiDinh>
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
        public bool AddOb(ObChiDinh ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObChiDinh.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.ChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObChiDinh ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObChiDinh.Update(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.ChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool UpdateOb(ObChiDinh ob,etrangthai trangThai)
        {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObChiDinh.Update(ob,trangThai) > 0;
            ObRecord rc = new ObRecord("", eTableName.ChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool DeleteOb(ObChiDinh ob) {
            return NTPObChiDinh.Delete(ob) > 0;
        }
        public ObChiDinh GetOb(double ma) {
            return NTPObChiDinh.GetObWF_PK(ma);
        }
        public double GetID()
        {
            return NTPObChiDinh.GetNextID();
        }

        public KeysListObChiDinh GetListOb(DateTime tungay, DateTime denNgay) {
            return NTPObChiDinh.GetListOb(tungay, denNgay);
        }
    }
}
