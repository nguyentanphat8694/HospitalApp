using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class UMauBA : DevExpress.XtraEditors.XtraUserControl
    {
        public UMauBA()
        {
            InitializeComponent();
            InitDisplay();
        }

        void InitDisplay() {
            DBStatic.ConnectDB(DadaConnect.connect_string);
            List<eTableName> listT = new List<eTableName> { 
                eTableName.DMMau
            };

            MainNTP.GetData(listT);

            lkMAU.Properties.DataSource = MainNTP.ObDMMauList;
        }

        private void lkMAU_EditValueChanged(object sender, EventArgs e)
        {
            if (lkMAU.EditValue == null) return;
            ObDMMau ob = MainNTP.ObDMMauList.Get(lkMAU.EditValue.ToString());
            if (ob == null) return;
            rtxtNOIDUNG.RtfText = ob.TTChung.NoiDung;
        }

        public void SetNoiDung(string maMau,string noiDung) {
            lkMAU.EditValue = maMau;
            rtxtNOIDUNG.RtfText = noiDung;
        }

        private void lkMAU_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                lkMAU.Properties.ReadOnly = false;
            }
        }
    }
}
