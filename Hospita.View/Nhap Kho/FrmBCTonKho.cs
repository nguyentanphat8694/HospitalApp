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
    public partial class FrmBCTonKho : DevExpress.XtraEditors.XtraForm
    {
        public FrmBCTonKho()
        {
            InitializeComponent();

            this.Icon = MainNTP.NTPICON;

            InitDisplay();
            LayDuLieu();
        }

        double IDPhieu = 0;

        List<ObCTNhapKho> listCTNhapKho = new List<ObCTNhapKho>();

        void InitDisplay()
        {
            int nam = 2016;
            for (int i = nam; i < (MainNTP._Ngay.Year + 1); i++)
            {
                cbNam.Properties.Items.Add(i.ToString());
            }

            cbNam.Text = MainNTP._Ngay.Year.ToString();
            cbThang.SelectedIndex = MainNTP._Ngay.Month - 1;
        }

        void LayDuLieu()
        {
            listCTNhapKho.Clear();

            int thang = MainNTP.ParseInt(cbThang.Text);
            int nam = MainNTP.ParseInt(cbNam.Text);

            DateTime tuNgay = new DateTime(nam, thang, 01);
            DateTime denNgay = tuNgay.AddMonths(1).AddDays(-1);

            //ObNhapKho phieuNhap = NTPObNhapKho.GetObDieuChinhKho(tuNgay, denNgay, etrangthai.Điều_chỉnh.ToString());
            //if (phieuNhap != null)
            //{
            //    IDPhieu = phieuNhap.Ma;

            //    KeysListObCTNhapKho keys = NTPObCTNhapKho.GetListOb(IDPhieu);
            //    ObDMDichVu dm = null;
            //    if (keys != null)
            //    {
            //        foreach (var item in keys)
            //        {
            //            dm = MainNTP.ObDMDichVuList.GetOb(item.MaDV);
            //            if (dm == null)
            //            {
            //                continue;
            //            }

            //            item.Ten = dm.Ten;

            //            listCTNhapKho.Add(item);
            //        }
            //    }
            //}
            //else
            //{
                IDPhieu = 0;
                KeysListObDMDichVu listDichVu = NTPObDMDichVu.GetListOb();
                ObCTNhapKho ct = null;
                List<ObDichVuTon> list = NTPObSLTon.GetListTonByThang(thang);
                ObDichVuTon obTon;
                if (listDichVu != null)
                {
                    foreach (var item in listDichVu)
                    {
                        if (!item.TTChung.HHThuocKho)
                        {
                            continue;
                        }

                        obTon = list.Find(o => o.Ma == item.Ma);

                        ct = new ObCTNhapKho();
                        ct.MaDV = item.Ma;
                        ct.Ten = item.Ten;
                        ct.TTChung.SLTon = obTon == null ? 0 : obTon.SLTon;
                        ct.TTChung.SLNhap = obTon == null ? 0 : obTon.SLNhap;
                        ct.TTChung.SLXuat = obTon == null ? 0 : obTon.SLXuat;
                        ct.SL = ct.TTChung.SLTon;
                        ct.TrangThai = etrangthai.Điều_chỉnh.ToString();
                        ct.Ngay = MainNTP._Ngay;
                        listCTNhapKho.Add(ct);
                    }
                }
            //}

            gridDanhmuc.DataSource = listCTNhapKho;
            viewDanhmuc.RefreshData();
        }

        void Save()
        {
            int thang = MainNTP.ParseInt(cbThang.Text);
            int nam = MainNTP.ParseInt(cbNam.Text);

            ObNhapKho phieu = null;// IDPhieu > 0 ? MainNTP.obNhapKhoList.GetOb(IDPhieu) : null;
            if (phieu == null)
            {
                phieu = new ObNhapKho();
                phieu.Ma = MainNTP.obNhapKhoList.GetID();
                phieu.Ngay = new DateTime(nam, thang, 01);
                phieu.NguoiNhap = MainNTP.User.TTChung.MaNS;
                phieu.TrangThai = etrangthai.Điều_chỉnh.ToString();

                MainNTP.obNhapKhoList.AddOb(phieu);

                IDPhieu = phieu.Ma;
            }
            else
            {
                phieu.Ngay = new DateTime(nam, thang, MainNTP._Ngay.Day);
                phieu.NguoiNhap = MainNTP.User.TTChung.MaNS;

                MainNTP.obNhapKhoList.UpdateOb(phieu);
            }

            foreach (var item in listCTNhapKho)
            {
                //if (item.Ma > 0)
                //{
                //    MainNTP.obCTNhapKhoList.UpdateOb(item);
                //}
                //else
                //{
                if (item.TTChung.SLTon >= 0)
                {
                    var sl = item.SL - item.TTChung.SLTon;
                    if (sl == 0)
                    {
                        continue;
                    }

                    item.SL = sl;
                }
                else
                {
                    var sl = (item.TTChung.SLTon * -1) + item.SL;
                    if (sl == 0)
                    {
                        continue;
                    }

                    item.SL = sl;
                }

                item.Ma = MainNTP.obCTNhapKhoList.GetID();
                item.KeyPhieuNhap = IDPhieu;
                
                MainNTP.obCTNhapKhoList.AddOb(item);
                //}
            }

            //viewDanhmuc.RefreshData();

            MessageBox.Show("Lưu thành công");
            LayDuLieu();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btLuuBenhAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmBCTonKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MainNTP.ObDichVuTonList.GetListTonByThang(MainNTP._Ngay.Month);
            }
            catch
            {

            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void btnTraVe0_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn trả tất cả thuốc về tồn 0?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int thang = MainNTP.ParseInt(cbThang.Text);
            int nam = MainNTP.ParseInt(cbNam.Text);

            ObNhapKho phieu = null;// IDPhieu > 0 ? MainNTP.obNhapKhoList.GetOb(IDPhieu) : null;
            if (phieu == null)
            {
                phieu = new ObNhapKho();
                phieu.Ma = MainNTP.obNhapKhoList.GetID();
                phieu.Ngay = new DateTime(nam, thang, 01);
                phieu.NguoiNhap = MainNTP.User.TTChung.MaNS;
                phieu.TrangThai = etrangthai.Điều_chỉnh.ToString();

                MainNTP.obNhapKhoList.AddOb(phieu);

                IDPhieu = phieu.Ma;
            }
            else
            {
                phieu.Ngay = new DateTime(nam, thang, MainNTP._Ngay.Day);
                phieu.NguoiNhap = MainNTP.User.TTChung.MaNS;

                MainNTP.obNhapKhoList.UpdateOb(phieu);
            }

            foreach (var item in listCTNhapKho)
            {
                //if (item.Ma > 0)
                //{
                //    MainNTP.obCTNhapKhoList.UpdateOb(item);
                //}
                //else
                //{
                item.SL = 0;
                if (item.TTChung.SLTon >= 0)
                {
                    var sl = item.SL - item.TTChung.SLTon;
                    if (sl == 0)
                    {
                        continue;
                    }

                    item.SL = sl;
                }
                else
                {
                    var sl = (item.TTChung.SLTon * -1) + item.SL;
                    if (sl == 0)
                    {
                        continue;
                    }

                    item.SL = sl;
                }

                item.Ma = MainNTP.obCTNhapKhoList.GetID();
                item.KeyPhieuNhap = IDPhieu;

                MainNTP.obCTNhapKhoList.AddOb(item);
                //}
            }

            //viewDanhmuc.RefreshData();

            MessageBox.Show("Lưu thành công");
            LayDuLieu();
        }
    }
}