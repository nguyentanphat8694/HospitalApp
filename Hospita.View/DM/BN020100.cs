using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Hospital.App
{
    public partial class BN020100 : DevExpress.XtraEditors.XtraForm
    {
        public BN020100()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            LoadData();
            InitDisplay();
        }

        void LoadData()
        {
            List<eTableName> listTable = new List<eTableName>();
            listTable.Add(eTableName.Customer);
            listTable.Add(eTableName.DMTinh);
            listTable.Add(eTableName.DMQuan);

            MainNTP.GetData(listTable);
        }

        void InitDisplay()
        {
            MainNTP.ObDMTinhList.Add(new ObDMTinh() { Ma = "", Ten = "" });
            MainNTP.ObDMQuanList.Add(new ObDMQuan() { Ma = "", Ten = "", MaTinh = "" });
            lkTinhThanh.Properties.DataSource = MainNTP.ObDMTinhList;
            lkQuanHuyen.Properties.DataSource = MainNTP.ObDMQuanList;
        }

        public void SetBenhNhan(ObCustomer ob) {
            obCurBenhNhan = ob;
            BenhNhan = obCurBenhNhan;
        }
        ObCustomer obCurBenhNhan = null;
        ObCustomer BenhNhan
        {
            get
            {
                ObCustomer ob = obCurBenhNhan == null ? new ObCustomer() : new ObCustomer(obCurBenhNhan);
                ob.Ten = teHoTen.Text;
                ob.Gioitinh = cbPhai.Text.ToLower() == "nam" ? 0 : 1;
                ob.Ngaysinh = MainNTP.ParseInt(cbNgay.Text);
                ob.Thangsinh = MainNTP.ParseInt(cbThang.Text);
                ob.Namsinh = MainNTP.ParseInt(teNam.Text);
                ob.Dienthoai = teDienThoai.Text;
                ob.Diachi = teDiaChi.Text;
                ob.CMND = teCMND.Text;
                ob.Email = teEmail.Text;
                ob.TTBenhnhan.MaTinh = lkTinhThanh.EditValue == null ? "" : lkTinhThanh.EditValue.ToString();
                ob.TTBenhnhan.MaQuan = lkQuanHuyen.EditValue == null ? "" : lkQuanHuyen.EditValue.ToString();
                return ob;
            }
            set
            {
                teMa.Text = value.Ma;
                teHoTen.Text = value.Ten;
                cbPhai.SelectedIndex = value.Gioitinh;
                cbNgay.Text = value.Ngaysinh.ToString("00");
                cbThang.Text = value.Thangsinh.ToString("00");
                teNam.Text = value.Namsinh.ToString();
                teDienThoai.Text = value.Dienthoai;
                teDiaChi.Text = value.Diachi;
                teCMND.Text = value.CMND;
                teEmail.Text = value.Email;
                lkTinhThanh.EditValue = value.TTBenhnhan.MaTinh;
                lkQuanHuyen.EditValue = value.TTBenhnhan.MaQuan;
            }
        }
        bool SaveBenhNhan()
        {
            ObCustomer ob = BenhNhan;
            if (obCurBenhNhan == null)
            {
                ob.Ngay = MainNTP._Ngay.Date;
                ob.Ma = NTPObCustomer.GetNextID();
                if (MainNTP.ObCustomerList.AddOb(ob))
                {
                    obCurBenhNhan = ob;
                    return true;
                }
            }
            else
            {
                if (MainNTP.ObCustomerList.UpdateOb(ob))
                {
                    obCurBenhNhan = ob;
                    return true;
                }
            }

            return false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (SaveBenhNhan())
            {
                KeysListObCustomer.var_Update = true;
                MessageBox.Show("Lưu thành công!");
                this.Close();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lkTinhThanh_EditValueChanged(object sender, EventArgs e)
        {
            lkQuanHuyen.EditValue = null;
            if (lkTinhThanh.EditValue != null)
            {
                lkQuanHuyen.Properties.DataSource = MainNTP.ObDMQuanList.ToList().FindAll(o => o.MaTinh == lkTinhThanh.EditValue.ToString());
            }
        }
    }
}