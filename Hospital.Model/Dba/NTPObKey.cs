using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.App
{
    public class NTPObKey
    {
        public static int Insert(ObKey ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_Key (IP, Ngay,TTChung) VALUES(@IP, @Ngay, @TTChung)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "IP";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.IP;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TTChung"; sqlParameter.SqlDbType = SqlDbType.Image;

            int num = -1;
            if (null != ob.TTChung)
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    MemoryStream memoryStream = new MemoryStream();
                    binaryFormatter.Serialize(memoryStream, ob.TTChung);
                    sqlParameter.Size = (int)memoryStream.Length;
                    sqlParameter.Value = memoryStream.ToArray();
                    num = 0;
                }
                catch
                {
                    num = -1;
                }
            }
            if (num == -1)
            {
                sqlParameter.Size = 1;
                sqlParameter.Value = new byte[]
					{
						1
					};
            }
            sqlCommand.Parameters.Add(sqlParameter);
            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }

        public static ObKey GetObWF_PK(string IP)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_Key WHERE(IP = @IP)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "IP";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = IP;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObKey result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObKey Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObKey();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.IP = sqlDataReader.GetString(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(2);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTKey)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTKey();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTKey();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTKey();
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
    }
}
