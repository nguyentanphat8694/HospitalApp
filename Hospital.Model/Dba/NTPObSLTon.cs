using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hospital.App
{
    public class NTPObSLTon
    {
        public static double GetSLTon(string maDV) {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM vw_SLTon WHERE(MaDV = @MaDV)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaDV";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = maDV;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            double result = 0;
            if (null == sqlDataReader)
            {
                result = 0;
            }
            else
            {
                while (sqlDataReader.Read())
                {
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        result = sqlDataReader.GetDouble(1);
                    }
                    break;
                }
                sqlDataReader.Close();
            }
            return result;
        }

        public static List<ObDichVuTon> GetListTonByThang(int thang)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_TinhTonKho");
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;

            List<ObDichVuTon> list = new List<ObDichVuTon>();
            ObDichVuTon ob = null;

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);

            if (null == sqlDataReader)
            {

            }
            else
            {
                while (sqlDataReader.Read())
                {

                    ob = new ObDichVuTon();

                    if (!sqlDataReader.IsDBNull(0))
                    {
                        ob.Ma = sqlDataReader.GetString(0);
                    }

                    if (!sqlDataReader.IsDBNull(1))
                    {
                        ob.SLTon = sqlDataReader.GetDouble(1);
                    }

                    try
                    {
                        if (!sqlDataReader.IsDBNull(2))
                        {
                            ob.SLNhap = sqlDataReader.GetDouble(2);
                        }
                    }
                    catch { }

                    try
                    {
                        if (!sqlDataReader.IsDBNull(3))
                        {
                            ob.SLXuat = sqlDataReader.GetDouble(3);
                        }
                    }
                    catch { }
                    list.Add(ob);


                }
                sqlDataReader.Close();
            }

            return list;
        }
    }
}
