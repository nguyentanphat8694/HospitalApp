using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.App
{
    public static class MeKong_DBStatic
    {
        public static SqlConnection m_SqlConn = new SqlConnection();
        
        private static SqlCommand m_SqlComm = new SqlCommand();
        
        public static string STATUS = "SQL";
        
        public static SqlConnection m_SqlConn_Event = new SqlConnection();
        
        public static ConnectionState ConnStateSql
        {
            get
            {
                return MeKong_DBStatic.m_SqlConn.State;
            }
        }
        
        public static bool ConnectDB(string chuoiketnoi)
        {
            bool result;
            if (chuoiketnoi.Trim() == "")
            {
                result = false;
            }
            else
            {
                bool flag3 = false;
                flag3 = MeKong_DBStatic.ConnectDBSql(chuoiketnoi);
                result = flag3;
            }

            return result;
        }
        
        public static bool DisConnectDB()
        {
            bool flag3 = false;
            flag3 = MeKong_DBStatic.DisconnectDBSql();
            return flag3;
        }
        
        public static bool ConnectDBSql(string strConn)
        {
            bool result;
            while (true)
            {
                try
                {
                    if (MeKong_DBStatic.m_SqlConn.State == ConnectionState.Closed)
                    {
                        MeKong_DBStatic.m_SqlConn.ConnectionString = strConn;
                        MeKong_DBStatic.m_SqlConn.Open();
                        MeKong_DBStatic.m_SqlComm.Connection = MeKong_DBStatic.m_SqlConn;
                    }
                    result = true;
                    break;
                }
                catch (Exception ex)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        
        public static bool DisconnectDBSql()
        {
            bool result;
            try
            {
                MeKong_DBStatic.m_SqlConn.Close();
                MeKong_DBStatic.m_SqlConn.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            return result;
        }
        
        public static int SqlExcuteNonQuery(string sql)
        {
            MeKong_DBStatic.m_SqlComm.CommandText = sql;
            int result;
            try
            {
                MeKong_DBStatic.m_SqlComm.ExecuteNonQuery();
                result = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = -1;
            }
            return result;
        }
        
        public static int SqlExcuteNonQuery(SqlCommand comm)
        {
            comm.Connection = MeKong_DBStatic.m_SqlConn;
            int result;
            try
            {
                result = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = -1;
            }
            return result;
        }
        
        public static SqlDataReader SqlExcuteQuery(string sql)
        {
            MeKong_DBStatic.m_SqlComm.CommandText = sql;
            SqlDataReader result;
            try
            {
                result = MeKong_DBStatic.m_SqlComm.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = null;
            }
            return result;
        }
        
        public static SqlDataReader SqlExcuteQuery(SqlCommand comm)
        {
            comm.Connection = MeKong_DBStatic.m_SqlConn;
            SqlDataReader result;
            try
            {
                result = comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = null;
            }
            return result;
        }
        
        public static SqlDataReader SqlExcuteQuery(SqlCommand comm, string newConnString)
        {
            SqlDataReader result;
            try
            {
                if (MeKong_DBStatic.m_SqlConn_Event.State != ConnectionState.Open)
                {
                    MeKong_DBStatic.m_SqlConn_Event.ConnectionString = newConnString;
                    MeKong_DBStatic.m_SqlConn_Event.Open();
                    comm.Connection = MeKong_DBStatic.m_SqlConn_Event;
                }
                else
                {
                    comm.Connection = MeKong_DBStatic.m_SqlConn_Event;
                }

                SqlDataReader sqlDataReader = comm.ExecuteReader();
                result = sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = null;
            }

            return result;
        }
    }

    public static class MeKongData
    {
        static void GetNgayThangNamSinh(string str, out string ngaySinh, out string thangSinh, out string NamSinh)
        {
            string dd="";
            string mm = "";
            string yyyy = "";

            try
            {
                if (str.Length == 10)
                {
                    dd = str.Substring(0, 2);
                    mm = str.Substring(3, 2);
                    yyyy = str.Substring(6, 4);
                }

                //DateTime dt = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //ngaySinh = dt.Day.ToString();
                //thangSinh = dt.Month.ToString();
                //NamSinh = dt.Year.ToString();
            }
            catch
            {
                
            }
            finally
            {
                ngaySinh = dd;
                thangSinh = mm;
                NamSinh = yyyy;
            }
        }

        static string GetString(SqlDataReader data, int x)
        {
            if (!data.IsDBNull(x))
            {
                return data.GetString(x);
            }

            return "";
        }

        static int GetInt(SqlDataReader data, int x)
        {
            if (!data.IsDBNull(x))
            {
                return data.GetInt32(x);
            }

            return -1;
        }

        static bool GetBoolean(SqlDataReader data, int x)
        {
            if (!data.IsDBNull(x))
            {
                return data.GetBoolean(x);
            }

            return false;
        }

        static double GetDouble(SqlDataReader data, int x)
        {
            if (!data.IsDBNull(x))
            {
                return data.GetDouble(x);
            }

            return 0;
        }

        static DateTime GetDate(SqlDataReader data, int x)
        {
            if (!data.IsDBNull(x))
            {
                return data.GetDateTime(x);
            }

            return new DateTime(1900, 01, 01, 0, 0, 0);
        }

        public class BenhNhan
        {
            public static List<ObCustomer> GetListOb()
            {
                int n = 0;
                SqlCommand sqlCommand = new SqlCommand("pro_T_GetDanhSachBenhNhan");
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = MeKong_DBStatic.SqlExcuteQuery(sqlCommand);

                List<ObCustomer> list = new List<ObCustomer>();

                if (null == sqlDataReader)
                {
                    list = null;
                }
                else
                {
                    while (sqlDataReader.Read())
                    {
                        ObCustomer ob = new ObCustomer();

                        ob.Ma = GetString(sqlDataReader, 0);
                        ob.Ten = GetString(sqlDataReader, 1);
                        DateTime ngaySinh = GetDate(sqlDataReader, 2);

                        ob.Ngaysinh = ngaySinh.Day;
                        ob.Thangsinh = ngaySinh.Month;
                        ob.Namsinh = ngaySinh.Year;

                        ob.Gioitinh = GetInt(sqlDataReader, 3);
                        ob.Dienthoai = GetString(sqlDataReader, 4);

                        ob.Diachi = GetString(sqlDataReader, 5);
                        ob.TTBenhnhan.MaQuan = GetInt(sqlDataReader, 6).ToString();
                        
                        ob.TTBenhnhan.NgheNghiep = GetString(sqlDataReader, 7);
                        //ob.TTBenhnhan.TienSu = sqlDataReader.GetTextReader(8).ToString();// GetString(sqlDataReader, 8);
                        ob.Ngay = DateTime.Now.Date;

                        list.Add(ob);
                    }

                    sqlDataReader.Close();
                }

                return list;
            }
        }

        public static bool ClearDanhMuc()
        {
            SqlCommand sqlCommand = new SqlCommand("sp_ClearDanhMucBeforeTransaction");
            sqlCommand.CommandType = CommandType.StoredProcedure;

            return DBStatic.SqlExcuteNonQuery(sqlCommand) > 0;
        }
    }

}
