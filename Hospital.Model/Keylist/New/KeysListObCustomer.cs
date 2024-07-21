using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObCustomer:ObservableCollection<ObCustomer>
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
        public bool AddOb(ObCustomer ob) {

            bool va= NTPObCustomer.Insert(ob) > 0;
            if (!this.Any(o =>o != null && o.Ma == ob.Ma))
            {
                this.Add(ob);
            }
            return va;
        }
        public bool UpdateOb(ObCustomer ob) {
            bool va = NTPObCustomer.Update(ob.Ma, ob) > 0;

            ObCustomer bn = this.FirstOrDefault(o => o!= null && o.Ma == ob.Ma);
            if (bn != null)
            {
                bn.Ten = ob.Ten;
                bn.Namsinh = ob.Namsinh;
                bn.Thangsinh = ob.Thangsinh;
                bn.Ngaysinh = ob.Ngaysinh;
                bn.Gioitinh = ob.Gioitinh;
                bn.Diachi = ob.Diachi;
                bn.TTBenhnhan.MaTinh = ob.TTBenhnhan.MaTinh;
                bn.TTBenhnhan.MaQuan = ob.TTBenhnhan.MaQuan;
                bn.Dienthoai = ob.Dienthoai;
                bn.Email = ob.Email;
                bn.DiaChiFull = MainNTP.GetDiaChi(bn.TTBenhnhan.MaTinh, bn.TTBenhnhan.MaQuan, bn.Diachi);
                bn.TTBenhnhan.TongTamUng = ob.TTBenhnhan.TongTamUng;
                bn.TTBenhnhan.KhachHangNo = ob.TTBenhnhan.KhachHangNo;
            }

            ObRecord rc = new ObRecord("", eTableName.Customer.ToString(), ob.Ma.ToString(), (int)ActionRec.Update, ob);
            MainNTP.ObRecordList.AddOb(rc);
            _ChangeDB(rc);
            return va;
        }

        public bool DeleteOb(ObCustomer ob) {
            return NTPObCustomer.Delete(ob) > 0;
        }

        public ObCustomer GetOb(string ma) {
            return NTPObCustomer.GetObWF_PK(ma);
        }

        public ObCustomer Get(string ma)
        {
            if (this == null) return null;
            ObCustomer ob = this.ToList().Find(o =>o!=null && o.Ma == ma);
            if (ob == null) {
                ob = GetOb(ma);
                this.Add(ob);
            }
            return ob;
        }

        public ObCustomer GetKey(string ma)
        {
            if (this == null) return null;
            return this.ToList().Find(o => o != null && o.Ma == ma);
        }

        public string GetID() {
            return NTPObCustomer.GetNextID();
        }
    }
}
