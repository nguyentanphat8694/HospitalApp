using System.Collections.Generic;
using System.Linq;

namespace Hospital.App
{
    public partial class FrmChuyenDichVu : DevExpress.XtraEditors.XtraForm
    {
        public FrmChuyenDichVu()
        {
            InitializeComponent();

            this.Icon = MainNTP.NTPICON;

            loadData();
        }

        void loadData()
        {
            MainNTP.GetData(new List<eTableName>() { 
            eTableName.DMDichVu,
            });

            List<string> listNhomDV = NTPUserSetting.NhomSA;

            gridDanhmuc.DataSource = MainNTP.ObDMDichVuList.ToList().FindAll(o => listNhomDV.Any(p => p == o.TTChung.Nhom));
            viewDanhmuc.RefreshData();
        }

        double idCTChiDinh = 0;

        public void SetCTChiDinh(double id)
        {
            idCTChiDinh = id;
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (idCTChiDinh <= 0) return;

            ObDMDichVu dm = (ObDMDichVu)viewDanhmuc.GetFocusedRow();
            if (dm == null) return;

            ObCTChiDinh ob = MainNTP.ObCTChiDinhList.GetOb(idCTChiDinh);
            if (ob == null) return;

            ob.MaDV = dm.Ma;
            ob.DG = dm.TTChung.DG;

            MainNTP.ObCTChiDinhList.UpdateOb(ob);

            this.Close();
        }
    }
}