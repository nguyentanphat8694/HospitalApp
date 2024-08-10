using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hospital.App
{
    public class NTPObRecord
    {
            public static KeysListObRecord GetMax() {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_Record where TimeMX>@TimeMX AND Time_Static!=@Time_Static";
                SqlParameter sqlparameter = new SqlParameter();
                sqlparameter.ParameterName = "TimeMX"; sqlparameter.SqlDbType = SqlDbType.DateTime;
                sqlparameter.Size = 100; sqlparameter.Value = MainNTP._MaxTime; sqlCommand.Parameters.Add(sqlparameter);
                sqlparameter = new SqlParameter();
                sqlparameter.ParameterName = "Time_Static"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
                sqlparameter.Size = 100; sqlparameter.Value = MainNTP._Time_Static; sqlCommand.Parameters.Add(sqlparameter);
                SqlDataReader sqlDataReader = DBStatic_DB.SqlExcuteQuery(sqlCommand);
                KeysListObRecord list = new KeysListObRecord();
                if (null == sqlDataReader)
                {
                    list = null;
                }
                else
                {
                    ObRecord Obtb_Customer = null;
                    while (sqlDataReader.Read())
                    {
                        Obtb_Customer = new ObRecord();
                        if (!sqlDataReader.IsDBNull(1))
                        {
                            Obtb_Customer.IPAd = sqlDataReader.GetString(1);
                        }
                        if (!sqlDataReader.IsDBNull(2))
                        {
                            Obtb_Customer.NameTBL = sqlDataReader.GetString(2);
                        }
                        if (!sqlDataReader.IsDBNull(3))
                        {
                            Obtb_Customer.TimeMX = sqlDataReader.GetDateTime(3);
                        }
                        if (!sqlDataReader.IsDBNull(4))
                        {
                            Obtb_Customer.IDOB = sqlDataReader.GetString(4);
                        }
                        if (!sqlDataReader.IsDBNull(5))
                        {
                            Obtb_Customer.Action = sqlDataReader.GetInt32(5);
                        }
                        if (!sqlDataReader.IsDBNull(6))
                        {
                            byte[] array = (byte[])sqlDataReader.GetValue(6);
                            if (array.Length > 1)
                            {
                                try
                                {
                                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                                    MemoryStream serializationStream = new MemoryStream(array);
                                    Obtb_Customer.OBUPDATE = (object)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    Obtb_Customer.OBUPDATE = new object();
                                }
                            }
                            else
                            {
                                Obtb_Customer.OBUPDATE = new object();
                            }
                        }
                        else
                        {
                            Obtb_Customer.OBUPDATE = new object();
                        }
                        if (Obtb_Customer.TimeMX > MainNTP._MaxTime)
                            MainNTP._MaxTime = Obtb_Customer.TimeMX;
                        list.Add(Obtb_Customer);
                    }
                    sqlDataReader.Close();
                }
                return list;
            }
            public static void GetMaxStart()
            {
                SqlDataReader sqlDataReader = DBStatic_DB.SqlExcuteQuery("SELECT Max(TimeMX) FROM tb_Record");
                if (null == sqlDataReader)
                {
                    MainNTP._MaxTime = MainNTP._Ngay.Date;
                }
                else
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            MainNTP._MaxTime = sqlDataReader.GetDateTime(0);
                            break;
                        }
                    }
                    sqlDataReader.Dispose();
                }
            }
            public static int Insert(ObRecord ob)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " INSERT INTO tb_Record (IPAd, NameTBL,TimeMX,IDOB,ActionRE,OBUPDATE,Time_Static) VALUES(@IPAd, @NameTBL,getdate(),@IDOB,@ActionRE,@OBUPDATE,@Time_Static)";

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "IPAd"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.IPAd; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NameTBL"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.NameTBL; sqlCommand.Parameters.Add(sqlParameter);
                //sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TimeMX"; sqlParameter.SqlDbType = SqlDbType.DateTime;
                //sqlParameter.Size = 500; sqlParameter.Value = ob.TimeMX; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "IDOB"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.IDOB; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ActionRE"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Action; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Time_Static"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Time_Static; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "OBUPDATE"; sqlParameter.SqlDbType = SqlDbType.Image;
                int num = -1;
                if (null != ob.OBUPDATE)
                {
                    try
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, ob.OBUPDATE);
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
                return DBStatic_DB.SqlExcuteNonQuery(sqlCommand);
            }
        
    }
}
