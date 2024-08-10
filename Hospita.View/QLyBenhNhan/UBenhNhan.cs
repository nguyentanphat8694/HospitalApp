using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class UBenhNhan : DevExpress.XtraEditors.XtraUserControl
    {
        public UBenhNhan()
        {
            InitializeComponent();
            doInit();
        }
        void doInit()
        {
            gridDanhsach.DataSource = MainNTP.ObCustomerList;
            viewDanhsach.RefreshData();

            tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        void ShowBenhAn()
        {
            if (obCur == null)
            {
                return;
            }
        }

        private void teTim_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (tabMain.SelectedTabPage == pageBenhNhan)
            {
                if (teTim.Text.Trim() != "")
                    sql += "([Ma] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [Namsinh] like '%" + teTim.Text + "%'OR [Gioitinh] like '%" + teTim.Text + "%' OR [Dienthoai] like '%" + teTim.Text + "%'OR [Diachi] like '%" + teTim.Text + "%')";

                if (cheNo.Checked)
                {
                    if (sql != "")
                    {
                        sql += " AND ";
                    }

                    sql += "[TTBenhnhan.KhachHangNo] > 0";
                }

                if (sql != "")
                    viewDanhsach.ActiveFilterString = sql;
                else viewDanhsach.ClearColumnsFilter();
            }
            else {
                if (teTim.Text.Trim() != "")
                    sql += "([MaBN] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [Namsinh] like '%" + teTim.Text + "%'OR [Gioitinh] like '%" + teTim.Text + "%')";

                if (cheNo.Checked)
                {
                    if (sql != "")
                    {
                        sql += " AND ";
                    }

                    sql += "[TTBenhnhan.KhachHangNo] > 0";
                }

                if (sql != "")
                    viewSA.ActiveFilterString = sql;
                else viewSA.ClearColumnsFilter();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            obCur = null;
        }
        public ObCustomer obCur = null;
        private void viewDanhsach_DoubleClick(object sender, EventArgs e)
        {
            obCur = (ObCustomer)viewDanhsach.GetFocusedRow();
            ShowNhatKy();
            //ShowBenhAn();
        }

        XtraForm frm = null;
        private void ShowNhatKy()
        {
            if (obCur == null)
            {
                return;
            }

            frm = new XtraForm();
            frm.Text = "Nhật ký khám bệnh";
            frm.WindowState = FormWindowState.Maximized;

            UNhatKy uNhatKy = new UNhatKy();
            uNhatKy.btThoat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            uNhatKy.btThoat.ItemClick += btThoat_ItemClick;
            uNhatKy.Dock = DockStyle.Fill;
            uNhatKy.SetLichSuKham(obCur.Ma);

            frm.Controls.Add(uNhatKy);
            frm.ShowDialog(this);
        }

        void btThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }

        }

        private void btTim_Click(object sender, EventArgs e)
        {
            if (teChanDoan.Text.Trim() == "")
            {
                tabMain.SelectedTabPage = pageBenhNhan;
            }
            else {
                tabMain.SelectedTabPage = pageSA;
                List<SA020110> listCDHA = new List<SA020110>();
                KeysListObCDHA keys = NTPObCDHA.GetListOb_ChanDoan(teChanDoan.Text.Trim());
                if (keys != null)
                {
                    foreach (var oo in keys)
                    {
                        SA020110 dk = new SA020110();
                        dk.SetNew(oo);
                        listCDHA.Add(dk);
                    }
                }
                gridSA.DataSource = listCDHA;
                viewSA.RefreshData();
            }
        }

        private void viewSA_DoubleClick(object sender, EventArgs e)
        {
            SA020110 cls = (SA020110)viewSA.GetFocusedRow();
            if (cls == null)
                return;

            obCur = MainNTP.ObCustomerList.GetOb(cls.MaBN);
            ShowNhatKy();
        }

        private void teChanDoan_EditValueChanged(object sender, EventArgs e)
        {
            if (teChanDoan.Text.Trim() == "" && tabMain.SelectedTabPage != pageBenhNhan)
            {
                tabMain.SelectedTabPage = pageBenhNhan;
            }
            else if (tabMain.SelectedTabPage != pageSA)
            {
                tabMain.SelectedTabPage = pageSA;
            }
        }

        private void thayĐổiThôngTinBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObCustomer cls = (ObCustomer)viewDanhsach.GetFocusedRow();
            if (cls == null) return;
            ObCustomer bn = MainNTP.ObCustomerList.GetOb(cls.Ma);
            if (bn == null) return;
            BN020100 frm = new BN020100();
            frm.SetBenhNhan(bn);
            frm.ShowDialog(this);
            viewDanhsach.RefreshData();
        }

        private void thayĐổiThôngTinBệnhNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SA020110 cls = (SA020110)viewSA.GetFocusedRow();
            if (cls == null) return;
            ObCustomer bn = MainNTP.ObCustomerList.GetOb(cls.MaBN);
            if (bn == null) return;
            BN020100 frm = new BN020100();
            frm.SetBenhNhan(bn);
            frm.ShowDialog(this);
            viewSA.RefreshData();
        }

        private void cheNo_CheckedChanged(object sender, EventArgs e)
        {
            teTim_EditValueChanged(null, null);
        }

        private void btChuyenNO_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainNTP.ObCustomerList.Count; i++)
            {
                ObCustomer ob = MainNTP.ObCustomerList[i];

                if (ob.TTBenhnhan.KhachHangNo != 0)
                {
                    ob.TTBenhnhan.KhachHangNo = 0;
                    MainNTP.ObCustomerList.UpdateOb(ob);
                }

            }
            MessageBox.Show("Đã cập nhật thành 0");
        }

        private void mnCapNhatNo_Click(object sender, EventArgs e)
        {
            ObCustomer ob = (ObCustomer)viewDanhsach.GetFocusedRow();
            if (ob == null)
            {
                return;
            }

            FrmCapNhatNo frm = new FrmCapNhatNo();
            frm.SetData(ob);
            frm.ShowDialog();
        }

        private void cậpNhậtNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObCustomer ob = (ObCustomer)viewSA.GetFocusedRow();
            if (ob == null)
            {
                return;
            }

            FrmCapNhatNo frm = new FrmCapNhatNo();
            frm.SetData(ob);
            frm.ShowDialog();
        }
    }
}