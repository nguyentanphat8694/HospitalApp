using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Hospital.App
{
    public partial class RP020100 : DevExpress.XtraReports.UI.XtraReport
    {
        public RP020100()
        {
            InitializeComponent();
        }
        public void SetData(string ten, object dtSource)
        {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            ObDesign ob = MainNTP.ObDesignList.GetOb(ten);

            if (ob != null && ob.OBJ != null)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream((byte[])ob.OBJ);
                if (stream != null)
                {
                    this.LoadLayout(stream);
                }
                if (stream != null) { stream.Close(); stream.Dispose(); }

            }

            this.DataSource = dtSource;
        }

        public void SetControl(Control ctrl, object dtSource)
        {
            DevExpress.XtraReports.UI.WinControlContainer winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            winControlContainer1.WinControl = ctrl;
            this.DataSource = dtSource;
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            winControlContainer1});
        }
    }
}
