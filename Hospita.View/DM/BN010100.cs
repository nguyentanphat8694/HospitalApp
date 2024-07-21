using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class BN010100 : DevExpress.XtraEditors.XtraForm
    {
        public BN010100()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            doInit();
        }
        void doInit()
        {
            KeysListObCustomer keysBN = NTPObCustomer.GetListOb();
            gridDanhsach.DataSource = keysBN;
            viewDanhsach.RefreshData();

            tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        private void teTim_EditValueChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (tabMain.SelectedTabPage == pageBenhNhan)
            {
                if (teTim.Text.Trim() != "")
                    sql += "[Ma] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [Namsinh] like '%" + teTim.Text + "%'OR [Gioitinh] like '%" + teTim.Text + "%' OR [Dienthoai] like '%" + teTim.Text + "%'OR [Diachi] like '%" + teTim.Text + "%'";

                if (sql != "")
                    viewDanhsach.ActiveFilterString = sql;
                else viewDanhsach.ClearColumnsFilter();
            }
            else {
                if (teTim.Text.Trim() != "")
                    sql += "[MaBN] like '%" + teTim.Text + "%' OR [Ten] like '%" + teTim.Text + "%' OR [Namsinh] like '%" + teTim.Text + "%'OR [Gioitinh] like '%" + teTim.Text + "%'";

                if (sql != "")
                    viewSA.ActiveFilterString = sql;
                else viewSA.ClearColumnsFilter();
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            obCur = null;
            this.Close();
        }
        public ObCustomer obCur = null;
        private void viewDanhsach_DoubleClick(object sender, EventArgs e)
        {
            obCur = (ObCustomer)viewDanhsach.GetFocusedRow();
            if (obCur == null) return;
            this.Close();
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
            if (obCur == null) return;
            this.Close();
        }
    }
}