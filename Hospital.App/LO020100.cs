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
    public partial class LO020100 : DevExpress.XtraEditors.XtraForm
    {
        public LO020100()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;
        }
        List<NTP_ITEM> listHETHONG = new List<NTP_ITEM>();
        List<NTP_ITEM> listDANHMUC = new List<NTP_ITEM>();
        List<NTP_ITEM> listKHAMBENH = new List<NTP_ITEM>();
        List<NTP_ITEM> listBAOCAO = new List<NTP_ITEM>();
        List<NTP_ITEM> listTIENICH = new List<NTP_ITEM>();
        int idx = 0;
        private void LO020100_Load(object sender, EventArgs e)
        {
            listHETHONG.Add(new NTP_ITEM("NGƯỜI DÙNG", "Frm_DMUser", 1));
            listHETHONG.Add(new NTP_ITEM("CASE CẤU HÌNH", "Frm_DMTSo", 1));
            listHETHONG.Add(new NTP_ITEM("THOÁT", "THOAT", 10));

            listDANHMUC.Add(new NTP_ITEM("NHÂN SỰ", "Frm_DMNhanSu", 1));
            listDANHMUC.Add(new NTP_ITEM("PHÒNG KHÁM", "Frm_DMPK", 1));
            listDANHMUC.Add(new NTP_ITEM("LOẠI KHÁM", "Frm_DMLK", 1));
            listDANHMUC.Add(new NTP_ITEM("DỊCH VỤ", "Frm_DMDichVu", 1));
            listDANHMUC.Add(new NTP_ITEM("NHÓM DỊCH VỤ", "Frm_DMNhomDichVu", 1));
            listDANHMUC.Add(new NTP_ITEM("ICD", "Frm_DMICD", 1));
            listDANHMUC.Add(new NTP_ITEM("ĐƠN VỊ", "Frm_DMDonVi", 1));
            listDANHMUC.Add(new NTP_ITEM("KHO", "Frm_DMKho", 1));
            listDANHMUC.Add(new NTP_ITEM("MẪU NỘI DUNG", "Frm_DMMau", 1));

            listKHAMBENH.Add(new NTP_ITEM("ĐĂNG KÝ THÔNG TIN", "DK010100", 1));
            //
            
            //
            listTIENICH.Add(new NTP_ITEM("REPORT DESIGN", "RP010100", 1));


            //

            foreach (var ob in listHETHONG)
                pnlHETHONG.Items.Add(ob,ob.IMG);
            foreach (var ob in listDANHMUC)
                pnlDANHMUC.Items.Add(ob, ob.IMG);
            foreach (var ob in listKHAMBENH)
                pnlKHAMBENH.Items.Add(ob, ob.IMG);
            foreach (var ob in listBAOCAO)
                pnlBAOCAO.Items.Add(ob, ob.IMG);
            foreach (var ob in listTIENICH)
                pnlTIENICH.Items.Add(ob, ob.IMG);
        }

        void CASEIT(NTP_ITEM item)
        {
            switch (item.CASE)
            {
                case "THOAT": { this.Close(); break; }
                case "Frm_DMUser": { Frm_DMUser frm = new Frm_DMUser(); frm.Show(this); break; }
                case "Frm_DMTSo": { Frm_DMTSo frm = new Frm_DMTSo(); frm.Show(this); break; }
                case "Frm_DMNhanSu": { Frm_DMNhanSu frm = new Frm_DMNhanSu(); frm.Show(this); break; }
                case "Frm_DMPK": { Frm_DMPK frm = new Frm_DMPK(); frm.Show(this); break; }
                case "Frm_DMLK": { Frm_DMLK frm = new Frm_DMLK(); frm.Show(this); break; }
                case "Frm_DMDichVu": { Frm_DMDichVu frm = new Frm_DMDichVu(); frm.Show(this); break; }
                case "Frm_DMNhomDichVu": { Frm_DMNhomDichVu frm = new Frm_DMNhomDichVu(); frm.Show(this); break; }
                case "Frm_DMICD": { Frm_DMICD frm = new Frm_DMICD(); frm.Show(this); break; }
                case "Frm_DMDonVi": { Frm_DMDonVi frm = new Frm_DMDonVi(); frm.Show(this); break; }
                //case "DK010100": { DK010100 frm = new DK010100(); frm.Show(this); break; }
                case "RP010100": { RP010100 frm = new RP010100(); frm.Show(this); break; }
                case "Frm_DMKho": { Frm_DMKho frm = new Frm_DMKho(); frm.Show(this); break; }
                case "Frm_DMMau": { Frm_DMMau frm = new Frm_DMMau(); frm.Show(this); break; }
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void pnlHETHONG_DoubleClick(object sender, EventArgs e)
        {
            if (pnlHETHONG.SelectedIndex < 0 || pnlHETHONG.SelectedIndex >= pnlHETHONG.Items.Count) return;
            NTP_ITEM item = (NTP_ITEM)pnlHETHONG.Items[pnlHETHONG.SelectedIndex].Value;
            if (item == null) return;
            idx = 0;
            CASEIT(item);
        }
        

        private void pnlDANHMUC_DoubleClick(object sender, EventArgs e)
        {
            if (pnlDANHMUC.SelectedIndex < 0 || pnlDANHMUC.SelectedIndex >= pnlDANHMUC.Items.Count) return;
            NTP_ITEM item = (NTP_ITEM)pnlDANHMUC.Items[pnlDANHMUC.SelectedIndex].Value;
            if (item == null) return;
            idx = 1;
            CASEIT(item);
        }

        private void pnlKHAMBENH_DoubleClick(object sender, EventArgs e)
        {
            if (pnlKHAMBENH.SelectedIndex < 0 || pnlKHAMBENH.SelectedIndex >= pnlKHAMBENH.Items.Count) return;
            NTP_ITEM item = (NTP_ITEM)pnlKHAMBENH.Items[pnlKHAMBENH.SelectedIndex].Value;
            if (item == null) return;
            idx = 2;
            CASEIT(item);
        }

        private void pnlBAOCAO_DoubleClick(object sender, EventArgs e)
        {
            if (pnlBAOCAO.SelectedIndex < 0 || pnlBAOCAO.SelectedIndex >= pnlBAOCAO.Items.Count) return;
            NTP_ITEM item = (NTP_ITEM)pnlBAOCAO.Items[pnlBAOCAO.SelectedIndex].Value;
            if (item == null) return;
            idx = 3;
            CASEIT(item);
        }

        private void pnlTIENICH_DoubleClick(object sender, EventArgs e)
        {
            if (pnlTIENICH.SelectedIndex < 0 || pnlTIENICH.SelectedIndex >= pnlTIENICH.Items.Count) return;
            NTP_ITEM item = (NTP_ITEM)pnlTIENICH.Items[pnlTIENICH.SelectedIndex].Value;
            if (item == null) return;
            idx = 4;
            CASEIT(item);
        }

        void CheckFOCUS() {
            if (idx != 0) pnlHETHONG.SelectedIndex = -1;
        }
    }
    public class NTP_ITEM
    {
        private string _NAME = "";
        private string _CASE = "";
        private int _IMG = -1;

        public NTP_ITEM() { }
        public NTP_ITEM(string name, string caseitem, int img)
        {
            _NAME = name;
            _CASE = caseitem;
            _IMG = img;
        }
        public string NAME { get { return _NAME; } set { _NAME = value; } }
        public string CASE { get { return _CASE; } set { _CASE = value; } }
        public int IMG { get { return _IMG; } set { _IMG = value; } }
        public override string ToString()
        {
            return _NAME;
        }
    }
}