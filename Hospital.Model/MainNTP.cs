using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Collections;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Hospital.App
{
    public delegate void NTPRefreshData();
    public class MainNTP
    {
        public static string dateFormat = "yyyyMMddHHmmss";
        public static System.Drawing.Icon NTPICON;
        public static string _Time_Static = "";
        public static string IP_ADDRESS = "";
        public static DateTime MinValue = new DateTime(1900, 01, 01, 00, 00, 00);
        public static MainChangeDB ChangeDBItem = new MainChangeDB();
        public static DateTime _MaxTime = MainNTP.GetServerDate();

        public static KeysListObUser ObUserList = new KeysListObUser();
        //public static KeysListObThuoc ObThuocList = new KeysListObThuoc();
        //public static KeysListObPayment ObPaymentList = new KeysListObPayment();
        public static KeysListObChiDinh ObChiDinhList = new KeysListObChiDinh();
        public static KeysListObDMTSo ObDMTSoList = new KeysListObDMTSo();
        public static KeysListObDMPK ObDMPKList = new KeysListObDMPK();
        public static KeysListObDMNhomDichVu ObDMNhomDichVuList = new KeysListObDMNhomDichVu();
        public static KeysListObDMNhanSu ObDMNhanSuList = new KeysListObDMNhanSu();
        public static KeysListObDMMau ObDMMauList = new KeysListObDMMau();
        public static KeysListObDMLK ObDMLKList = new KeysListObDMLK();
        public static KeysListObDMKho ObDMKhoList = new KeysListObDMKho();
        public static KeysListObDMICD ObDMICDList = new KeysListObDMICD();
        public static KeysListObDMDonVi ObDMDonViList = new KeysListObDMDonVi();
        public static KeysListObDMDichVu ObDMDichVuList = new KeysListObDMDichVu();
        public static KeysListObDMDichVu ObDMThuocList = new KeysListObDMDichVu();
        public static KeysListObCustomer ObCustomerList = new KeysListObCustomer();
        //public static KeysListObCTNhap ObCTNhapList = new KeysListObCTNhap();
        //public static KeysListObCDHA ObCDHAList = new KeysListObCDHA();
        //public static KeysListObBenhAn ObBenhAnList = new KeysListObBenhAn();
        //public static KeysListObBCOrder ObBCOrderList = new KeysListObBCOrder();
        public static KeysListObRecord ObRecordList = new KeysListObRecord();
        public static KeysListObDesign ObDesignList = new KeysListObDesign();
        public static KeysListObSinhHieu ObSinhHieuList = new KeysListObSinhHieu();
        public static KeysListObCTChiDinh ObCTChiDinhList = new KeysListObCTChiDinh();
        public static KeysListObCDHA ObCDHAList = new KeysListObCDHA();
        public static KeysListObBenhAn ObBenhAnList = new KeysListObBenhAn();
        public static KeysListObPhieuThu ObPhieuThuList = new KeysListObPhieuThu();
        public static KeysListObPhieuThuoc obPhieuThuocList = new KeysListObPhieuThuoc();
        public static KeysListObImage obImageList = new KeysListObImage();
        public static KeysListObNhapKho obNhapKhoList = new KeysListObNhapKho();
        public static KeysListObCTNhapKho obCTNhapKhoList = new KeysListObCTNhapKho();
        public static KeysListObDMXetNghiem ObDMXetNghiemList = new KeysListObDMXetNghiem();
        public static KeysListObDMNhomXetNghiem ObDMNhomXetNghiemList = new KeysListObDMNhomXetNghiem();
        public static KeysListObPhieuXetNghiem ObPhieuXetNghiemList = new KeysListObPhieuXetNghiem();
        public static KeysListObHenKham ObHenKhamList = new KeysListObHenKham();
        public static KeysListObLichLamViec obLichLamViec = new KeysListObLichLamViec();
        public static KeysListObPhacDo obPhacDoList = new KeysListObPhacDo();
        public static KeysListObDMQuan ObDMQuanList = new KeysListObDMQuan();
        public static KeysListObDMTinh ObDMTinhList = new KeysListObDMTinh();
        public static KeysListObTKBenhNhan ObTKBenhNhanList = new KeysListObTKBenhNhan();
        public static KeysListObDMNgheNghiep ObDMNgheNghiepList = new KeysListObDMNgheNghiep();
        public static KeysListObDichVuTon ObDichVuTonList = new KeysListObDichVuTon();

        public static string LayThu_VN(DayOfWeek day)
        {
            if (day == DayOfWeek.Monday) return "Thứ 2";
            if (day == DayOfWeek.Tuesday) return "Thứ 3";
            if (day == DayOfWeek.Wednesday) return "Thứ 4";
            if (day == DayOfWeek.Thursday) return "Thứ 5";
            if (day == DayOfWeek.Friday) return "Thứ 6";
            if (day == DayOfWeek.Saturday) return "Thứ 7";
            return "Chủ nhật";
        }

        public static int ParseInt(string text)
        {
            try
            {
                if (text.Trim() == "") return 0;
                return int.Parse(text);
            }
            catch
            {
                return 0;
            }
        }

        public static double ParseDouble(string text)
        {
            double rs;
            if (NTPValidate.IsEmpty(text))
            {
                rs = 0.0;
            }
            else
            {
                NumberStyles style = NumberStyles.Any;
                CultureInfo currentCulture = CultureInfo.CurrentCulture;
                double num = 0.0;
                double.TryParse(text, style, currentCulture, out num);
                rs = num;
            }
            return rs;
        }

        public static ObUser User;

        public static DateTime _Ngay = DateTime.Now.Date;

        public static DateTime GetServerDate()
        {
            DateTime rs;
            if (NTPValidate.IsEmpty(DadaConnect.connect_string)) return DateTime.Now;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("SELECT Getdate()");
            DateTime serverTimes = DateTime.Now;
            if (null == sqlDataReader)
            {
                rs = serverTimes;
            }
            else
            {
                if (sqlDataReader.Read())
                {
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        DateTime dateTime = sqlDataReader.GetDateTime(0);
                        sqlDataReader.Close();
                        rs = dateTime;
                        MainNTP._Ngay = rs.Date;
                        return rs;
                    }
                }
                sqlDataReader.Close();
                rs = serverTimes;
            }

            return rs;
        }

        public static List<ePhanquyen> listQuyen
        {
            get
            {
                List<ePhanquyen> lt = new List<ePhanquyen>();
                int idx = 0; while (true) { try { ePhanquyen ts = (ePhanquyen)idx; if (ts.ToString() == idx.ToString()) break; lt.Add((ePhanquyen)idx++); } catch { break; } }
                return lt;
            }
        }

        public static List<eLoaiNS> listLoaiNS
        {
            get
            {
                List<eLoaiNS> lt = new List<eLoaiNS>();
                int idx = 0; while (true) { try { eLoaiNS ts = (eLoaiNS)idx; if (ts.ToString() == idx.ToString()) break; lt.Add((eLoaiNS)idx++); } catch { break; } }
                return lt;
            }
        }

        public static void GetData(List<eTableName> listTable)
        {
            if (listTable.Count <= 0) return;
            DBStatic.ConnectDB(DadaConnect.connect_string);
            //int i = 0;
            //Task[] tasks = new Task[listTable.Count];
            foreach (var item in listTable)
            {
                //tasks[i] = Task.Run(() => {
                if (item == eTableName.DMDichVu && MainNTP.ObDMDichVuList.Count <= 0)
                    MainNTP.ObDMDichVuList = NTPObDMDichVu.GetListOb_DICHVU();
                if (item == eTableName.DMNhomDichVu)
                    MainNTP.ObDMNhomDichVuList = NTPObDMNhomDichVu.GetListOb();
                if (item == eTableName.DMPK && MainNTP.ObDMPKList.Count <= 0)
                    MainNTP.ObDMPKList = NTPObDMPK.GetListOb();
                if (item == eTableName.Customer && MainNTP.ObCustomerList.Count <= 0)
                    MainNTP.ObCustomerList = NTPObCustomer.GetListOb();
                if (item == eTableName.DMNhanSu && MainNTP.ObDMNhanSuList.Count <= 0)
                    MainNTP.ObDMNhanSuList = NTPObDMNhanSu.GetListOb();
                if (item == eTableName.DMDonVi && MainNTP.ObDMDonViList.Count <= 0)
                    MainNTP.ObDMDonViList = NTPObDMDonVi.GetListOb();
                if (item == eTableName.DMThuoc && MainNTP.ObDMThuocList.Count <= 0)
                    MainNTP.ObDMThuocList = NTPObDMDichVu.GetListOb_THUOC();
                if (item == eTableName.DMKho && MainNTP.ObDMKhoList.Count <= 0)
                    MainNTP.ObDMKhoList = NTPObDMKho.GetListOb();
                if (item == eTableName.DMTSo && MainNTP.ObDMTSoList.Count <= 0)
                    MainNTP.ObDMTSoList = NTPObDMTSo.GetListOb();
                if (item == eTableName.DMICD && MainNTP.ObDMICDList.Count <= 0)
                    MainNTP.ObDMICDList = NTPObDMICD.GetListOb();
                if (item == eTableName.DMMau && MainNTP.ObDMMauList.Count <= 0)
                    MainNTP.ObDMMauList = NTPObDMMau.GetListOb();
                if (item == eTableName.User && MainNTP.ObUserList.Count <= 0)
                    MainNTP.ObUserList = NTPObUser.GetListOb();
                if (item == eTableName.DMXetNghiem && MainNTP.ObDMXetNghiemList.Count <= 0)
                    MainNTP.ObDMXetNghiemList = NTPObDMXetNghiem.GetListOb();
                if (item == eTableName.DMNhomXetNghiem && MainNTP.ObDMNhomXetNghiemList.Count <= 0)
                    MainNTP.ObDMNhomXetNghiemList = NTPObDMNhomXetNghiem.GetListOb();
                if (item == eTableName.PhacDo && MainNTP.obPhacDoList.Count <= 0)
                    MainNTP.obPhacDoList = NTPObPhacDo.GetListOb();
                if (item == eTableName.DMQuan && MainNTP.ObDMQuanList.Count <= 0)
                    MainNTP.ObDMQuanList = NTPObDMQuan.GetListOb();
                if (item == eTableName.DMTinh && MainNTP.ObDMTinhList.Count <= 0)
                    MainNTP.ObDMTinhList = NTPObDMTinh.GetListOb();

                if (item == eTableName.DMNgheNghiep && MainNTP.ObDMNgheNghiepList.Count <= 0)
                    MainNTP.ObDMNgheNghiepList = NTPObDMNgheNghiep.GetListOb();
                //});
                //i++;
            }
            //Task.WaitAll(tasks);
        }

        public static string SaveImage(string duongDan, Image img, string loaiPhieu, DateTime ngay)
        {
            string result;
            if (NTPValidate.IsEmpty(duongDan)) return "";
            Image image = (Image)img.Clone();
            if (duongDan != "")
            {
                using (UNCAccessWithCredentials uNCAccessWithCredentials = new UNCAccessWithCredentials())
                {
                    if (true)//uNCAccessWithCredentials.NetUseWithCredentials(duongDan, NTPUserSetting.PathServer_User, NTPUserSetting.PathServer_Domain, NTPUserSetting.PathServer_Password))
                    {
                        string text = string.Concat(new string[]
					{
						duongDan,
						"\\",
						ngay.ToString("yyMMdd"),
						"\\",
						loaiPhieu
					});
                        DirectoryInfo directoryInfo = new DirectoryInfo(text);
                        if (!directoryInfo.Exists)
                        {
                            directoryInfo.Create();
                        }
                        string text2 = text + "\\" + (directoryInfo.GetFiles().Length + 1).ToString() + ".jpg";
                        Bitmap bitmap = new Bitmap(image);
                        image.Dispose();
                        bitmap.Save(text2, ImageFormat.Jpeg);
                        result = text2;
                        return result;
                    }
                }
            }
            else
            {
                string text = string.Concat(new string[]
			{
				duongDan,
				"\\",
				ngay.ToString("yyMMdd"),
				"\\",
				loaiPhieu
			});
                DirectoryInfo directoryInfo = new DirectoryInfo(text);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                string text2 = text + "\\" + (directoryInfo.GetFiles().Length + 1).ToString() + ".jpg";
                Bitmap bitmap = new Bitmap(image);
                image.Dispose();
                bitmap.Save(text2, ImageFormat.Jpeg);
                result = text2;
            }

            return result;
        }

        public static string FindIPAddress(bool localPreference)
        {
            IPAddress iPAddress = FindIPAddress(Dns.GetHostEntry(Dns.GetHostName()), localPreference);
            string result;
            if (iPAddress == null)
            {
                result = "";
            }
            else
            {
                result = iPAddress.ToString();
            }
            return result;
        }

        public static IPAddress FindIPAddress(IPHostEntry host, bool localPreference)
        {
            IPAddress result;
            if (host == null)
            {
                result = null;
            }
            else if (host.AddressList.Length == 1)
            {
                result = host.AddressList[0];
            }
            else
            {
                IPAddress[] addressList = host.AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    IPAddress iPAddress = addressList[i];
                    bool flag = true;
                    if (flag && localPreference)
                    {
                        result = iPAddress;
                        return result;
                    }
                    if (!flag && !localPreference)
                    {
                        result = iPAddress;
                        return result;
                    }
                }
                result = host.AddressList[0];
            }
            return result;
        }

        public static Image ResizeImage(Image img, int per)
        {
            int Width = img.Width * per;
            int Height = img.Height * per;
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics graphic = Graphics.FromImage(bmp);
            //graphic.InterpolationMode = 7;
            graphic.DrawImage(img, 0, 0, Width, Height);
            graphic.Dispose();
            bmp.Dispose();
            img.Dispose();
            return bmp;
        }

        public static Image CompressImage(Image img, int quality)
        {
            Image result;
            try
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
                ImageCodecInfo imageCodec = GetImageCoeInfo("image/jpeg");
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = qualityParam;
                MemoryStream stre = new MemoryStream();
                Bitmap bm = new Bitmap(img);
                bm.Save(stre, imageCodec, parameters);
                Image im = Image.FromStream(stre);
                stre.Close();
                result = new Bitmap(im);
            }
            catch
            {
                result = img;
            }
            return result;
        }

        private static ImageCodecInfo GetImageCoeInfo(string mimeType)
        {
            ImageCodecInfo[] codes = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo result;
            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].MimeType == mimeType)
                {
                    result = codes[i];
                    return result;
                }
            }
            result = null;
            return result;
        }

        public static Point GetRatioImg(Control ctrl, Image img, ref double scaleW, ref double scaleH, ref bool zoomout, Point pos)
        {
            Point unscaled_p = default(Point);
            Point result;
            if (img == null)
            {
                result = unscaled_p;
            }
            else
            {
                int wi = img.Width;
                int hi = img.Height;
                int wc = ctrl.ClientRectangle.Width;
                int hc = ctrl.ClientRectangle.Height;
                zoomout = (wi < wc || hi < hc);
                int wr;
                int hr;
                if (wi > hi)
                {
                    wr = wc;
                    hr = wc * hi / wi;
                }
                else
                {
                    hr = hc;
                    wr = hc * wi / hi;
                }
                scaleW = (double)wr;
                scaleH = (double)hr;
                float imageRatio = (float)wi / (float)hi;
                float containerRatio = (float)wc / (float)hc;
                if (imageRatio >= containerRatio)
                {
                    float scaleFactor = (float)wc / (float)wi;
                    float scaledHeight = (float)hi * scaleFactor;
                    float filler = Math.Abs((float)hc - scaledHeight) / 2f;
                    unscaled_p.X = ((int)((float)pos.X / scaleFactor));
                    unscaled_p.Y = ((int)(((float)pos.Y - filler) / scaleFactor));
                }
                else
                {
                    float scaleFactor = (float)hc / (float)hi;
                    float scaledWidth = (float)wi * scaleFactor;
                    float filler = Math.Abs((float)wc - scaledWidth) / 2f;
                    unscaled_p.X = ((int)(((float)pos.X - filler) / scaleFactor));
                    unscaled_p.Y = ((int)((float)pos.Y / scaleFactor));
                }
                result = unscaled_p;
            }
            return result;
        }

        public static string GetStringFromObject(object ob)
        {
            if (ob == null)
                return "";
            return ob.ToString();
        }

        public static string GetDichVuChiDinh(KeysListObCTChiDinh keysList, double KeyCreate = 0)
        {
            string str = "";
            if (keysList != null)
            {
                foreach (var item in keysList)
                {
                    if (KeyCreate == 0 || item.KeyCreate == KeyCreate)
                    {
                        if (str != "")
                            str += "\n";
                        str += item.TenDV + " (" + item.SL + ")";
                    }
                }
            }

            return str;
        }

        public static void HuyDangKy(ObChiDinh ob)
        {
            if (ob == null) return;

            ObCustomer cls = MainNTP.ObCustomerList.GetOb(ob.MaBN);
            if (cls == null)
                return;

            if (ob.TrangThai == etrangthai.Đã_hủy.ToString())
            {
                MessageBox.Show("Phiếu đang ở trạng thái Đã_hủy");
                return;
            }

            if (ob.TrangThai == etrangthai.Đang_điều_trị.ToString())
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten.ToUpper() + " đang được điều trị. Không thể hủy chỉ định này!");
                return;
            }

            KeysListObCTChiDinh keysCTChiDinh = NTPObCTChiDinh.GetListOb(ob.Ma, (int)eLoaiHH.Dịch_vụ);
            if (keysCTChiDinh != null && keysCTChiDinh.Any(o => o.TrangThai != etrangthai.Đang_chờ.ToString()))
            {
                MessageBox.Show("Bệnh nhân " + cls.Ten.ToUpper() + " đang được điều trị. Không thể hủy chỉ định này!");
                return;
            }

            if (keysCTChiDinh.Any(o => o.KeyPT > 0))
            {
                MessageBox.Show("Dịch vụ đã thu tiền. Không thể hủy chỉ định này!");
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn hủy đăng ký " + cls.Ten.ToUpper() + "?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ob.TrangThai = etrangthai.Đã_hủy.ToString();
            if (MainNTP.ObChiDinhList.UpdateOb(ob, etrangthai.Đã_hủy))
            {
                foreach (var item in keysCTChiDinh)
                {
                    MainNTP.ObCTChiDinhList.DeleteOb(item, etrangthai.Đã_hủy);
                }

                MessageBox.Show("Hủy thành công phiếu chỉ định của bệnh nhân " + cls.Ten.ToUpper());
            }
        }

        public static void LoadDefault()
        {
            MainNTP.GetData(
                new List<eTableName>() {
                    eTableName.DMPK,
                    eTableName.Customer,
                    eTableName.DMTinh,
                    eTableName.DMQuan,
                    eTableName.User,
                    eTableName.DMNhanSu,
                    eTableName.DMDichVu,
                    eTableName.DMNhomDichVu,
                    eTableName.DMKho,
                    eTableName.DMNgheNghiep,
            });
        }

        public static string GetDiaChi(string maTinh, string maQuan, string diaChi)
        {
            if (MainNTP.ObDMTinhList == null)
                MainNTP.ObDMTinhList = new KeysListObDMTinh();
            if (MainNTP.ObDMQuanList == null)
                MainNTP.ObDMQuanList = new KeysListObDMQuan();
            ObDMTinh tinh = maTinh == null || maTinh == "" ? null : MainNTP.ObDMTinhList.GetOb(maTinh);
            ObDMQuan quan = maQuan == null || maQuan == "" ? null : MainNTP.ObDMQuanList.GetOb(maQuan);
            string str = diaChi;
            if (quan != null && quan.Ten != "")
            {
                if (str != "")
                    str += ", ";
                str += quan.Ten;
            }

            if (tinh != null && tinh.Ten != "")
            {
                if (str != "")
                    str += ", ";
                str += tinh.Ten;
            }

            return str;
        }

        public static void XuatExcel(GridView view)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Tên file (*.xls)|*.xls";
            sf.ShowDialog();
            if (sf.FileName != "") {
                view.ExportToXls(sf.FileName);
            }
        }

        public static void XuatExcel(BandedGridView view)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Tên file (*.xls)|*.xls";
            sf.ShowDialog();
            if (sf.FileName != "")
            {
                view.ExportToXls(sf.FileName);
            }
        }

        public static void DangKyHTK(ObHenKham hk)
        {
            if (hk == null || hk.TTChung.IDCTChiDinh == null || hk.TTChung.IDCTChiDinh == "") {
                MessageBox.Show("Không tìm thấy chỉ định để đăng ký");
                return;
            }

            if (hk.TrangThai == etrangthai.Đã_đến.ToString())
            {
                MessageBox.Show("Bệnh nhân đã đăng ký, Không thể đăng ký tiếp!");
                return;
            }

            ObCTChiDinh ct = MainNTP.ObCTChiDinhList.GetOb(MainNTP.ParseDouble(hk.TTChung.IDCTChiDinh));
            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy dịch vụ khám để đăng ký");
                return;
            }

            ObChiDinh cd = MainNTP.ObChiDinhList.GetOb(ct.KeyCreate);
            if (cd == null)
            {
                MessageBox.Show("Không tìm thấy phiếu chỉ định đăng ký");
                return;
            }

            ObCustomer bn = MainNTP.ObCustomerList.GetOb(hk.MaBN);
            if(bn == null)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân để đăng ký");
                return;
            }

            if (MessageBox.Show("Bạn có muốn đăng ký cho bệnh nhân " + bn.Ten + " không?", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            ObChiDinh cdNew = new ObChiDinh();
            cdNew.Ma = MainNTP.ObChiDinhList.GetID();
            cdNew.Ngay = MainNTP._Ngay;
            cdNew.MaBN = cd.MaBN;
            cdNew.TrangThai = etrangthai.Đang_chờ.ToString();

            MainNTP.ObChiDinhList.AddOb(cdNew);

            ObCTChiDinh ctNew = new ObCTChiDinh();
            ctNew.Ma = MainNTP.ObCTChiDinhList.GetID();
            ctNew.Ngay = MainNTP._Ngay;
            ctNew.KeyCreate = cdNew.Ma;
            ctNew.TrangThai = etrangthai.Đang_chờ.ToString();
            ctNew.MaDV = ct.MaDV;
            ctNew.MaPK = ct.MaPK;
            ctNew.SL = 1;
            ctNew.MaBN = ct.MaBN;
            ctNew.LoaiHangHoa = ct.LoaiHangHoa;
            MainNTP.ObCTChiDinhList.AddOb(ctNew);

            hk.TrangThai = etrangthai.Đã_đến.ToString();
            MainNTP.ObHenKhamList.UpdateOb(hk);

            MessageBox.Show("Đăng ký thành công!");
        }

        public static void UpdateCellValueChanging(DevExpress.XtraGrid.Views.Grid.GridView gview)
        {
            if (gview.EditingValueModified)
            {
                int idxCol = gview.FocusedColumn.VisibleIndex + 1;
                if (idxCol == gview.VisibleColumns.Count) idxCol = 0;
                gview.FocusedColumn = gview.VisibleColumns[idxCol];
            }
        }

        public static void TinhNgayDuSanh(string maBN, ref int soTuan, ref int soNgay) {
            KeysListObCDHA keys = NTPObCDHA.GetListOb_MaxNgay(maBN);
            if (keys != null && keys.Count > 0)
            {
                ObCDHA ob = keys[0];
                int tongNgay = (MainNTP._Ngay.Date - ob.Ngay.Date).Days;
                int soT = tongNgay / 7;
                int soN = tongNgay % 7;

                int soT2 = (int)(ob.TTChung.SoTuoiThai * 10) / 10;
                int soN2 = (int)(ob.TTChung.SoTuoiThai * 10) % 10;

                soNgay = soN + soN2;
                int soT3 = soNgay / 7;

                soNgay = soNgay % 7;
                soTuan = soT + soT2 + soT3;
            }
        }

        public static string TinhNgaySADauTien(string maBN)
        {
            string kq = "";

            KeysListObCDHA keys = NTPObCDHA.GetListOb(maBN);
            if (keys != null && keys.Count > 0)
            {

                ObCDHA ob = keys.OrderBy(o => o.Ngay).FirstOrDefault(o => o.TTChung.SAThai);
                if (ob != null)
                {
                    int soT2 = (int)(ob.TTChung.SoTuoiThai * 10) / 10;
                    int soN2 = (int)(ob.TTChung.SoTuoiThai * 10) % 10;

                    kq = "Thai " + soT2 + " tuần " + soN2 + " ngày. Ngày SA: " + ob.Ngay.ToString("dd/MM/yyyy");
                }
            }

            return kq;
        }

        public static string GetThuocByBenhAn(double ma)
        {
            string str = "";
            KeysListObPhieuThuoc keysPT = NTPObPhieuThuoc.GetListOb_MaBA(ma, (int)eLoaiPhieuTH.Kham_Benh);
            KeysListObCTChiDinh keyListObCTThuoc = null;
            ObPhieuThuoc obThuoc = null;
            if (keysPT != null && keysPT.Count > 0)
            {
                obThuoc = keysPT[0];
                keyListObCTThuoc = MainNTP.ObCTChiDinhList.GetListOb(obThuoc.Ma, (int)eLoaiHH.Thuốc);
                if (keyListObCTThuoc != null)
                {
                    foreach (var item in keyListObCTThuoc)
                    {
                        if (str != "")
                            str += "\n";
                        str += item.TenDV + " ("+ item.SL + ")";
                    }
                }
            }

            return str;
        }
    }
}
