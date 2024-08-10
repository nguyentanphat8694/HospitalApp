using System;
using System.Collections.Generic;

namespace Hospital.App
{
    public class Main_Text
    {
        public static string GetText(List<string> array, string textSource)
        {
            string kq = "";
            int cnt = 0;
            for (int i = 0; i < array.Count; i++)
            {
                string sl = array[i];
                string st = sl.Trim();
                if (!(st == ""))
                {
                    if (!sl.Contains(":"))
                    {
                        st = sl.Trim() + ":";
                    }
                    string fm = "";
                    string kt = GetTextBenhAn(st, textSource, out fm);
                    if (!(kt == ""))
                    {
                        if (kq != "")
                        {
                            kq += fm;
                        }
                        if (kt.Trim() != "")
                        {
                            kq = kq + ((cnt++ == 0) ? "" : (st + " ")) + kt;
                        }
                    }
                }
            }
            if (kq == "")
            {
                kq = GetTextBenhAn("Bản thân", textSource);
            }
            return kq;

        }

        public static string GetTextBenhAn(string text, string textSource, out string sFm)
        {
            List<string[]> lsTD = LaydongmauBAWFormat(textSource);
            sFm = "";
            string kq = "";
            bool fl = false;
            string result;
            using (List<string[]>.Enumerator enumerator = lsTD.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string[] str = enumerator.Current;
                    int idx2C = str[0].IndexOf(":");
                    if (idx2C > 0)
                    {
                        if (fl)
                        {
                            result = kq;
                            return result;
                        }
                        string sc = str[0].Substring(0, idx2C);
                        if (ReplaceNoidung(sc).ToLower().Trim() == ReplaceNoidung(text).ToLower().Trim())
                        {
                            sFm = str[1];
                            kq = ((str[0].Length > idx2C + 1) ? str[0].Substring(idx2C + 1) : "");
                            fl = true;
                        }
                    }
                    else if (fl)
                    {
                        kq = kq + Environment.NewLine + str[0];
                    }
                }
            }
            result = kq;
            return result;
        }

        public static string GetTextBenhAn(string text, string textSource)
        {
            List<string> lsTD = LaydongmauBA(textSource);
            string result;
            using (List<string>.Enumerator enumerator = lsTD.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string str = enumerator.Current;
                    int idx2C = str.IndexOf(":");
                    if (idx2C > 0)
                    {
                        string sc = str.Substring(0, idx2C);
                        if (ReplaceNoidung(sc).ToLower().Trim() == ReplaceNoidung(text).ToLower().Trim())
                        {
                            result = ((str.Length > idx2C + 1) ? str.Substring(idx2C + 1) : "");
                            return result;
                        }
                    }
                }
            }
            result = "";
            return result;
        }

        public static List<string> LaydongmauBA(string strNoidung)
        {
            List<string> lst = new List<string>();
            List<string> lT = new List<string>(strNoidung.Split(new char[]
	{
		'\n'
	}));
            using (List<string>.Enumerator enumerator = lT.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string str = enumerator.Current;
                    if (str.Contains(";"))
                    {
                        lst.AddRange(str.Split(new char[]
				{
					';'
				}));
                    }
                    else
                    {
                        lst.Add(str);
                    }
                }
            }
            return lst;
        }

        public static string ReplaceNoidung(string sTmp)
        {
            sTmp = sTmp.Replace("-", "");
            sTmp = sTmp.Replace("+", "");
            sTmp = sTmp.Replace("1", "");
            sTmp = sTmp.Replace("2", "");
            sTmp = sTmp.Replace("3", "");
            sTmp = sTmp.Replace("4", "");
            sTmp = sTmp.Replace("5", "");
            sTmp = sTmp.Replace("6", "");
            sTmp = sTmp.Replace("7", "");
            sTmp = sTmp.Replace("8", "");
            sTmp = sTmp.Replace("9", "");
            sTmp = sTmp.Replace(".", "");
            sTmp = sTmp.Replace(";", "");
            sTmp = sTmp.Replace(":", "");
            sTmp = sTmp.Replace("I", "");
            sTmp = sTmp.Replace("II", "");
            sTmp = sTmp.Replace("III", "");
            sTmp = sTmp.Replace("IV", "");
            sTmp = sTmp.Replace("V", "");
            sTmp = sTmp.Replace("VI", "");
            return sTmp.Trim();
        }

        public static List<string[]> LaydongmauBAWFormat(string strNoidung)
        {
            List<string[]> lst = new List<string[]>();
            List<string> lT = new List<string>(strNoidung.Split(new char[]
	{
		'\n'
	}));
            using (List<string>.Enumerator enumerator = lT.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string str = enumerator.Current;
                    if (str.Contains(";"))
                    {
                        string[] st = str.Split(new char[]
				{
					';'
				});
                        int cnt = 0;
                        string[] array = st;
                        for (int i = 0; i < array.Length; i++)
                        {
                            string s = array[i];
                            lst.Add(new string[]
					{
						s,
						(cnt++ == 0) ? "\n" : ";"
					});
                        }
                    }
                    else
                    {
                        lst.Add(new string[]
				{
					str,
					"\n"
				});
                    }
                }
            }
            return lst;
        }


    }

    public class Main_View
    {
        public static RP020100 GetReportSieuAm(ObCDHA obCur)
        {
            if (MainNTP.ObDMMauList == null)
            {
                MainNTP.ObDMMauList = new KeysListObDMMau();
            }

            SA020110 cls = new SA020110();
            ObCDHA obIn = new ObCDHA(obCur);
            
            List<ObImage> listImg = obCur.TTChung.Images.FindAll(o => o.In);
            obIn.TTChung.Images = new List<ObImage>();
            if (listImg != null)
            {
                foreach (var item in listImg)
                {
                    obIn.TTChung.Images.Add(item);
                }
            }
            int n = obIn.TTChung.Images.Count;
            cls.SetNew(obIn);

            ObDMMau mau = MainNTP.ObDMMauList.GetOb(obIn.TTChung.MaMau);
            if (mau != null)
            {
                cls.TenVungKhaoSat = mau.Ten;
            }

            var bn = cls.MaBenhNhan;

            RP020100 rp = new RP020100();
            string rp_name = n == 0 ? e_REPORTNTP.Sieu_Am_0_Anh.ToString() :
                n == 2 ? e_REPORTNTP.Sieu_Am_2_Anh.ToString() :
                n == 3 ? e_REPORTNTP.Sieu_Am_3_Anh.ToString() :
                n == 4 ? e_REPORTNTP.Sieu_Am_4_Anh.ToString() :
                e_REPORTNTP.Sieu_Am.ToString();
            rp.SetData(rp_name, new List<SA020110>() { cls });

            return rp;
        }

        public static RP020100 GetReportBenhAn(ObBenhAn data)
        {
            RP020100 rp = new RP020100();
            string rp_name = e_REPORTNTP.Benh_An.ToString();
            BA020110 cls = new BA020110();
            cls.SetNew(data);
            var maBN = cls.MaBenhNhan;
            rp.SetData(rp_name, new List<BA020110>() { cls });

            return rp;
        }

        public static RP020100 GetReportXetNghiem(ObPhieuXetNghiem data)
        {
            RP020100 rp = new RP020100();
            string rp_name = e_REPORTNTP.Xet_Nghiem.ToString();
            XN020110 cls = new XN020110();
            cls.SetNew(data);
            var maBN = cls.MaBenhNhan;
            rp.SetData(rp_name, new List<XN020110>() { cls });

            return rp;
        }
    }
}
