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
    public partial class Frm_DMUser_Nhom : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DMUser_Nhom()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
            DoInit();
        }
        void DoInit() {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            KeysListObDMNhomDichVu keysList = NTPObDMNhomDichVu.GetListOb();
            if (keysList == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("CHON", typeof(bool));
            dt.Columns.Add("MA", typeof(string));
            dt.Columns.Add("TEN", typeof(string));
            
            foreach (var ob in keysList) {
                DataRow row = dt.NewRow();
                row["CHON"] = "false";
                row["MA"] = ob.Ma;
                row["TEN"] = ob.Ten;
                dt.Rows.Add(row);
            }
            gridNHOM.DataSource = dt;
            viewNHOM.RefreshData();
        }
        public ObUser obCur = null;
        public void SetTT(ObUser ob) {
            obCur = ob;
            string[] mang = ob.TTChung.NhomDV.Split(new string[] { ";" }, StringSplitOptions.None);
            if (mang == null) return;
            for (int i = 0; i < viewNHOM.RowCount; i++) {
                DataRowView row = (DataRowView)viewNHOM.GetRow(i);
                if (row == null) continue;
                if (mang.Any(o => o.Trim() == row["MA"].ToString()))
                    row["CHON"] = "true";
            }
            viewNHOM.RefreshData();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            obCur = null;
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (obCur == null) return;
            obCur = MainNTP.ObUserList.GetOb(obCur.UserName);
            if (obCur == null) return;
            string nhom = "";
            for (int i = 0; i < viewNHOM.RowCount; i++)
            {
                DataRowView row = (DataRowView)viewNHOM.GetRow(i);
                if (row == null) continue;
                if (bool.Parse(row["CHON"].ToString()) == true) {
                    if (nhom != "")
                        nhom += ";";
                    nhom += row["MA"].ToString();
                }
            }
            obCur.TTChung.NhomDV = nhom;
            MainNTP.ObUserList.UpdateOb(obCur.UserName, obCur);
            this.Close();
        }
    }
}