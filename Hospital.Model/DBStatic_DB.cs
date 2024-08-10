
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Hospital.App
{
    public static class DBStatic_DB
	{
		public static SqlConnection m_SqlConn = new SqlConnection();
		private static SqlCommand m_SqlComm = new SqlCommand();
		public static string STATUS = "SQL";
		public static SqlConnection m_SqlConn_Event = new SqlConnection();
		public static ConnectionState ConnStateSql
		{
			get
			{
				return DBStatic_DB.m_SqlConn.State;
			}
		}
		public static bool ConnectDB(string chuoiketnoi)
		{
			bool result;
            if (chuoiketnoi.Trim()=="")
			{
				result = false;
			}
			else
			{
				bool flag3 = false;
                flag3 = DBStatic_DB.ConnectDBSql(chuoiketnoi);
				result = flag3;
			}
            if (!result) { MessageBox.Show("Không thể kết nối CSDL. Bạn chưa đăng ký kết nối."); }
			return result;
		}
		public static bool DisConnectDB()
		{
			bool flag3 = false;
			flag3 = DBStatic_DB.DisconnectDBSql();
			return flag3;
		}
		public static bool ConnectDBSql(string strConn)
		{
			bool result;
			while (true)
			{
				try
				{
					if (DBStatic_DB.m_SqlConn.State == ConnectionState.Closed)
					{
						DBStatic_DB.m_SqlConn.ConnectionString = strConn;
						DBStatic_DB.m_SqlConn.Open();
						DBStatic_DB.m_SqlComm.Connection = DBStatic_DB.m_SqlConn;
					}
					result = true;
					break;
				}
				catch (Exception ex)
				{
					if (MessageBox.Show("Không thể kết nối với cơ sở dữ liệu. \n Detail : \n" + ex.Message + "\n Bạn có muốn thử lại (Retry)!?", "Thông báo lỗi", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}
		public static bool DisconnectDBSql()
		{
			bool result;
			try
			{
				DBStatic_DB.m_SqlConn.Close();
				DBStatic_DB.m_SqlConn.Dispose();
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
			DBStatic_DB.m_SqlComm.CommandText = sql;
			int result;
			try
			{
				DBStatic_DB.m_SqlComm.ExecuteNonQuery();
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
			comm.Connection = DBStatic_DB.m_SqlConn;
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
			DBStatic_DB.m_SqlComm.CommandText = sql;
			SqlDataReader result;
			try
			{
				result = DBStatic_DB.m_SqlComm.ExecuteReader();
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
			comm.Connection = DBStatic_DB.m_SqlConn;
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
				if (DBStatic_DB.m_SqlConn_Event.State != ConnectionState.Open)
				{
					DBStatic_DB.m_SqlConn_Event.ConnectionString = newConnString;
					DBStatic_DB.m_SqlConn_Event.Open();
					comm.Connection = DBStatic_DB.m_SqlConn_Event;
				}
				else
				{
					comm.Connection = DBStatic_DB.m_SqlConn_Event;
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
}
