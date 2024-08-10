using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Hospital.App
{
    public partial class FrmMainDangKy : DevExpress.XtraEditors.XtraForm
    {
        public FrmMainDangKy()
        {
            InitializeComponent();
            this.Icon = MainNTP.NTPICON;

            LoadData();

            if (MainNTP.User.TTChung.MaNS != null)
            {
                ObDMNhanSu ns = MainNTP.ObDMNhanSuList.GetOb(MainNTP.User.TTChung.MaNS);
                if (ns != null)
                    this.Text += " - " + ns.Ten;
            }

            _uDangKyBenhAn = new UDangKy();
            _uDangKyBenhAn.Dock = DockStyle.Fill;
            pageKhamBenh.Controls.Add(_uDangKyBenhAn);

            //_uPhieuSA = new UMainSA();
            //_uPhieuSA.Dock = DockStyle.Fill;
            //pageSieuAm.Controls.Add(_uPhieuSA);

            _uLichLV = new ULichLamViec();
            _uLichLV.Dock = DockStyle.Fill;
            pageLichLamViec.Controls.Add(_uLichLV);

            _uTKKhamBenh = new UTKKhamBenh();
            _uTKKhamBenh.Dock = DockStyle.Fill;
            pageThongKe.Controls.Add(_uTKKhamBenh);

            _uNhapKho = new UNhapKho();
            _uNhapKho.Dock = DockStyle.Fill;
            pageNhapKho.Controls.Add(_uNhapKho);

            _uXetNghiem = new UPhieuXetNghiem();
            _uXetNghiem.Dock = DockStyle.Fill;
            pageXetNghiem.Controls.Add(_uXetNghiem);

            _uThuTien = new UMainThuTien();
            _uThuTien.Dock = DockStyle.Fill;
            pageThuTien.Controls.Add(_uThuTien);
        }

        UDangKy _uDangKyBenhAn = null;
        //UMainSA _uPhieuSA = null;
        ULichLamViec _uLichLV = null;
        UTKKhamBenh _uTKKhamBenh = null;
        UNhapKho _uNhapKho = null;
        UPhieuXetNghiem _uXetNghiem = null;
        UMainThuTien _uThuTien = null;

        void LoadData()
        {
            MainNTP.GetData(new List<eTableName>() {
            eTableName.DMNhanSu,
            });

        }

        private void FrmMainBenhAn_Shown(object sender, EventArgs e)
        {
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btLichLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarButtonItem item = (BarButtonItem)e.Item;
            if (item == null)
            {
                return;
            }

            pageKhamBenh.PageVisible = item.Name == btKhamBenh.Name;
            pageSieuAm.PageVisible = item.Name == btSieuAm.Name;
            pageLichLamViec.PageVisible = item.Name == btLichLamViec.Name;
            pageThongKe.PageVisible = item.Name == btThongKe.Name;
            pageNhapKho.PageVisible = item.Name == btNhapKho.Name;
            pageXetNghiem.PageVisible = item.Name == btXetNghiem.Name;
            pageThuTien.PageVisible = item.Name == btThuTien.Name;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            _uDangKyBenhAn.Save();
        }

        private void btBaoCaoTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBCTonKho frm = new FrmBCTonKho();
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_DMThuoc frm = new Frm_DMThuoc();
            frm.Show();
        }
    }
}