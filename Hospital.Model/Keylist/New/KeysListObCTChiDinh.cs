using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObCTChiDinh : ObservableCollection<ObCTChiDinh>
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
        public bool AddOb(ObCTChiDinh ob) {
            ob.CreateBy = MainNTP.User.UserName;
            ob.CreateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCTChiDinh.Insert(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.CTChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Insert, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }
        public bool UpdateOb(ObCTChiDinh ob) {
            ob.UpdateBy = MainNTP.User.UserName;
            ob.UpdateTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va= NTPObCTChiDinh.Update(ob) > 0;
            ObRecord rc = new ObRecord("", eTableName.CTChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool DeleteOb(ObCTChiDinh ob, etrangthai trangThai)
        {
            ob.TrangThai = etrangthai.Đã_hủy.ToString();
            ob.DeleteBy = MainNTP.User.UserName;
            ob.DeleteTime = MainNTP.GetServerDate().ToString(MainNTP.dateFormat);
            bool va = NTPObCTChiDinh.Update(ob, trangThai) > 0;
            ObRecord rc = new ObRecord("", eTableName.CTChiDinh.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool DeleteOb(ObCTChiDinh ob) {
            return NTPObCTChiDinh.Delete(ob) > 0;
        }
        public ObCTChiDinh GetOb(double ma)
        {
            return NTPObCTChiDinh.GetObWF_PK(ma);
        }

        public ObCTChiDinh Get(double ma) {
            ObCTChiDinh ob = this.FirstOrDefault(o=>o.Ma==ma);
            if (ob == null)
                ob = GetOb(ma);
            return ob;
        }
        public double GetID() {
            return NTPObCTChiDinh.GetNextID();
        }
        public KeysListObCTChiDinh GetListOb()
        {
            return NTPObCTChiDinh.GetListOb();
        }

        public KeysListObCTChiDinh GetListOb(DateTime tuNgay,DateTime denNgay)
        {
            return NTPObCTChiDinh.GetListOb(tuNgay, denNgay);
        }

        public KeysListObCTChiDinh GetListOb(double keyCreate,int loaiHH)
        {
            return NTPObCTChiDinh.GetListOb(keyCreate,loaiHH);
        }

    }
}
