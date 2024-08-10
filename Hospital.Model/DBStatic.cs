
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Hospital.App
{
    public static class DBStatic
	{
		public static SqlConnection m_SqlConn = new SqlConnection();
		private static SqlCommand m_SqlComm = new SqlCommand();
		public static string STATUS = "SQL";
		public static SqlConnection m_SqlConn_Event = new SqlConnection();
		public static ConnectionState ConnStateSql
		{
			get
			{
				return DBStatic.m_SqlConn.State;
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
                flag3 = DBStatic.ConnectDBSql(chuoiketnoi);
				result = flag3;
			}
            if (!result) { MessageBox.Show("Không thể kết nối CSDL."); }
			return result;
		}
		public static bool DisConnectDB()
		{
			bool flag3 = false;
			flag3 = DBStatic.DisconnectDBSql();
			return flag3;
		}
		public static bool ConnectDBSql(string strConn)
		{
			bool result;
			while (true)
			{
				try
				{
					if (DBStatic.m_SqlConn.State == ConnectionState.Closed)
					{
						DBStatic.m_SqlConn.ConnectionString = strConn;
						DBStatic.m_SqlConn.Open();
						DBStatic.m_SqlComm.Connection = DBStatic.m_SqlConn;
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
				DBStatic.m_SqlConn.Close();
				DBStatic.m_SqlConn.Dispose();
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
			DBStatic.m_SqlComm.CommandText = sql;
			int result;
			try
			{
				DBStatic.m_SqlComm.ExecuteNonQuery();
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
			comm.Connection = DBStatic.m_SqlConn;
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
			DBStatic.m_SqlComm.CommandText = sql;
			SqlDataReader result;
			try
			{
				result = DBStatic.m_SqlComm.ExecuteReader();
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
			comm.Connection = DBStatic.m_SqlConn;
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
				if (DBStatic.m_SqlConn_Event.State != ConnectionState.Open)
				{
					DBStatic.m_SqlConn_Event.ConnectionString = newConnString;
					DBStatic.m_SqlConn_Event.Open();
					comm.Connection = DBStatic.m_SqlConn_Event;
				}
				else
				{
					comm.Connection = DBStatic.m_SqlConn_Event;
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
