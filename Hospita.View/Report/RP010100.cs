using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Hospital.App
{
    public partial class RP010100 : DevExpress.XtraEditors.XtraForm
    {
        public RP010100()
        {
            InitializeComponent();
            DoInit();
        }

        DevExpress.XtraReports.UI.XtraReport R = new DevExpress.XtraReports.UI.XtraReport();
        List<ObDesign> lstSrc = new List<ObDesign>();
        public List<e_REPORTNTP> listRP
        {
            get
            {
                List<e_REPORTNTP> lt = new List<e_REPORTNTP>();
                int idx = 0; while (true) { try { e_REPORTNTP ts = (e_REPORTNTP)idx; if (ts.ToString() == idx.ToString()) break; lt.Add((e_REPORTNTP)idx++); } catch { break; } }
                return lt;
            }
        }
        List<Cls_ReportNTP> lstMain = new List<Cls_ReportNTP>();
        void DoInit()
        {
            List<e_REPORTNTP> lst = listRP;
            foreach (e_REPORTNTP temp in lst)
            {
                Cls_ReportNTP cls = new Cls_ReportNTP();
                cls.TenReport = temp.ToString();
                lstMain.Add(cls);
            }
            gridDS.DataSource = lstMain;
            viewDS.RefreshData();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ObDesign obCur = null;
        private void btSave_Click(object sender, EventArgs e)
        {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            if (obCur == null) return;
            MemoryStream fStream = new MemoryStream();
            R.SuspendLayout();
            R.ResumeLayout();
            R.SaveLayout(fStream);
            byte[] data = null;
            if (fStream != null)
            {
                data = fStream.ToArray();              
            }
            if (fStream != null) { fStream.Close(); fStream.Dispose(); }
            if (data == null) return;
            bool sc = false;
            if (obCur.OBJ == null)
            {
                obCur.OBJ = data;
                sc=MainNTP.ObDesignList.AddOb(obCur);
            }
            else
            {
                obCur.OBJ = data;
                sc=MainNTP.ObDesignList.UpdateOb(obCur.Ma, obCur);
            }
            if (sc) MessageBox.Show("REPORT: "+obCur.Ma+"\nĐã được lưu vào CSDL");
        }
        RP020100 r = null;
        private void viewDESIGN_Click(object sender, EventArgs e)
        {
            
            
        }
        void Set_FOCUS(Cls_ReportNTP cls) {
            r = new RP020100();
            
            switch(cls.TenReport)
            {
                case "Phieu_chi_dinh":
                case "Phieu_thuoc":
                case "Giay_Vao_Vien":
                case "Benh_An":
                    {
                        r.SetData(cls.TenReport.ToString(), new List<BA020110>() { });
                        this.SetReport(cls.TenReport, new List<BA020110>());
                        break;
                    }
                case "Phieu_Thu":
                    {
                        r.SetData(cls.TenReport.ToString(), new List<TT020110>() { });
                        this.SetReport(cls.TenReport, new List<TT020110>());
                        break;
                    }
                case "Sieu_Am_2_Anh":
                case "Sieu_Am_4_Anh":
                case "Sieu_Am_3_Anh":
                case "Sieu_Am_0_Anh":
                case "Sieu_Am":
                    {
                        r.SetData(cls.TenReport.ToString(), new List<SA020110>() { });
                        this.SetReport(cls.TenReport, new List<SA020110>());
                        break;
                    }
                case "Xet_Nghiem":
                    {
                        r.SetData(cls.TenReport.ToString(), new List<XN020110>() { });
                        this.SetReport(cls.TenReport, new List<XN020110>());
                        break;
                    }
                case "BC_KhamBenh_BenhNhan":
                    {
                        var obj = new List<ClsReportCommon<ClsTKKhamBenh>>() { };
                        r.SetData(cls.TenReport.ToString(), obj);
                        this.SetReport(cls.TenReport, obj);
                        break;
                    }
                case "BC_KhamBenh_BacSi":
                case "BC_KhamBenh_DichVu":
                    {
                        var obj = new List<ClsReportCommon<ClsTKDichVu>>() { };
                        r.SetData(cls.TenReport.ToString(), obj);
                        this.SetReport(cls.TenReport, obj);
                        break;
                    }
                default: { break; }
                    
            }
            
        }
        Cls_ReportNTP Get_FOCUS
        {
            get
            {
                for (int i = 0; i < viewDS.RowCount; i++)
                {
                    Cls_ReportNTP c2 = (Cls_ReportNTP)viewDS.GetRow(i);
                    if (c2 != null && c2.CHON)
                    {
                        return c2;
                    }
                }
                return null;
            }
        }
        public void SetReport(string ma, object obSrc)
        {
            this.Text = ma;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            ObDesign ob = MainNTP.ObDesignList.GetOb(ma);
            if (ob == null)
            {
                ob = new ObDesign();
                ob._Action = ActionRec.Insert;
                ob.Ma = ma;
                ob.OBJ = null;
            }
            obCur = ob;
            if (ob.OBJ != null)
            {
                MemoryStream stream = new MemoryStream((byte[])ob.OBJ);
                if (stream != null)
                {
                    R.LoadLayout(stream);
                }
                if (stream != null) { stream.Close(); stream.Dispose(); }
                R.DataSource = obSrc;
                pnlDESIGN.OpenReport(R);
            }
            else
            {
                R = r;
                R.DataSource = obSrc;
                pnlDESIGN.OpenReport(R);
            }
        }

        private void RP010100_Load(object sender, EventArgs e)
        {

        }

        private void viewBENHNHAN_Click(object sender, EventArgs e)
        {
            //if (viewDS.FocusedColumn == colCHON)
            //{
                
            //}
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btSave_Click(null, null);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btExit_Click(null, null);
        }

        private void viewDS_DoubleClick(object sender, EventArgs e)
        {
            Cls_ReportNTP cls = (Cls_ReportNTP)viewDS.GetFocusedRow();
            if (cls == null) return;
            Set_FOCUS(cls);
        }
    }
}