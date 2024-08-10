using System;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hospital.App
{
    public class NTPObCustomer
    {
            public static string GetNextID2()
            {
                //string Ma = MainNTP.GetServerDate().ToString("yyyyMMddHHmmssfff");
                
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("SELECT Ma FROM tb_Customer WHERE (DTimesNew = (Select Max(DTimesNew) From tb_Customer))");
                string Ma = "BN-00000000";
                if (null == sqlDataReader)
                {
                    //return Ma;
                }
                else
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            Ma = sqlDataReader.GetString(0);
                            break;
                        }
                    }
                    sqlDataReader.Dispose();
                }
                if (Ma != "")
                {
                    string[] mang = Ma.Split(new string[] { "-" }, StringSplitOptions.None);
                    string kq="";
                    if (mang != null && mang.Length>1)
                    {
                        double so = double.Parse(mang[1]) + 1;
                        int x = mang[1].Trim().Length;//8
                        int y = so.ToString().Length;//1
                        int z = x - y;
                        string kq2 = "";
                        for (int i = 0; i < z; i++)
                        {
                            kq2 += "0";
                        }
                        Ma = mang[0] + "-" + kq2 + so;
                    }
                    
                }
                
                return Ma;
            }

            public static string GetNextID()
            {
                //return GetNextID2();
                
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(STT) From tb_Customer");
                double Ma = 0;
                if (null != sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            Ma = sqlDataReader.GetInt32(0);
                            break;
                        }
                    }
                }
                sqlDataReader.Close();

                double so = Ma + 1;
                int x = NTPUserSetting.DoDaiSTTMaBN;
                int y = so.ToString().Length;//1
                int z = x - y;
                string kq2 = "";
                for (int i = 0; i < z; i++)
                {
                    kq2 += "0";
                }
                string rs = kq2 + so;

                return MainNTP._Ngay.ToString("ddMMyy" + rs);
                 
            }
            public static int GetMaxSTT(DateTime ngay)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT Max(STT) FROM tb_Customer WHERE (Ngay >= @Ngay AND Ngay < @Ngay2)";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "Ngay";
                sqlParameter.SqlDbType = SqlDbType.DateTime;
                sqlParameter.Value = ngay.Date;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "Ngay2";
                sqlParameter.SqlDbType = SqlDbType.DateTime;
                sqlParameter.Value = ngay.AddDays(1.0).Date;
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                int result;
                if (null == sqlDataReader)
                {
                    result = 1;
                }
                else
                {
                    int num = 0;
                    while (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            num = sqlDataReader.GetInt32(0);
                        }
                    }
                    sqlDataReader.Close();
                    result = num + 1;
                }
                return result;
            }
            public static bool TestExistPK(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT Ma FROM tb_Customer WHERE(Ma = @K_Ma)";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "K_Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Value = K_Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                bool result;
                if (null == sqlDataReader)
                {
                    result = false;
                }
                else
                {
                    bool hasRows = sqlDataReader.HasRows;
                    sqlDataReader.Close();
                    result = hasRows;
                }
                return result;
            }
            public static ObCustomer GetObWF_PK(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_Customer WHERE(Ma = @K_Ma)";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "K_Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Value = K_Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                ObCustomer result;
                if (null == sqlDataReader)
                {
                    result = null;
                }
                else
                {
                    ObCustomer Ob = null;
                    while (sqlDataReader.Read())
                    {
                        Ob = new ObCustomer();
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            Ob.Ma = sqlDataReader.GetString(0);
                        }
                        if (!sqlDataReader.IsDBNull(1))
                        {
                            Ob.Ten = sqlDataReader.GetString(1);
                        }
                        if (!sqlDataReader.IsDBNull(2))
                        {
                            Ob.Ngaysinh = sqlDataReader.GetInt32(2);
                        }
                        if (!sqlDataReader.IsDBNull(3))
                        {
                            Ob.Thangsinh = sqlDataReader.GetInt32(3);
                        }
                        if (!sqlDataReader.IsDBNull(4))
                        {
                            Ob.Namsinh = sqlDataReader.GetInt32(4);
                        }
                        if (!sqlDataReader.IsDBNull(5))
                        {
                            Ob.Gioitinh = sqlDataReader.GetInt32(5);
                        }
                        if (!sqlDataReader.IsDBNull(6))
                        {
                            Ob.Diachi = sqlDataReader.GetString(6);
                        }
                        if (!sqlDataReader.IsDBNull(7))
                        {
                            Ob.Dienthoai = sqlDataReader.GetString(7);
                        }
                        if (!sqlDataReader.IsDBNull(8))
                        {
                            Ob.CMND = sqlDataReader.GetString(8);
                        }
                        if (!sqlDataReader.IsDBNull(9))
                        {
                            Ob.Email = sqlDataReader.GetString(9);
                        }
                        if (!sqlDataReader.IsDBNull(10))
                        {
                            Ob.STT = sqlDataReader.GetInt32(10);
                        }
                        if (!sqlDataReader.IsDBNull(11))
                        {
                            Ob.Ngay = sqlDataReader.GetDateTime(11);
                        }
                        if (!sqlDataReader.IsDBNull(12))
                        {
                            Ob.DTimesNew = sqlDataReader.GetDateTime(12);
                        }
                        if (!sqlDataReader.IsDBNull(13))
                        {
                            byte[] array = (byte[])sqlDataReader.GetValue(13);
                            if (array.Length > 1)
                            {
                                try
                                {
                                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                                    MemoryStream serializationStream = new MemoryStream(array);
                                    Ob.TTBenhnhan = (Cls_TTCustomer)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    Ob.TTBenhnhan = new Cls_TTCustomer();
                                }
                            }
                            else
                            {
                                Ob.TTBenhnhan = new Cls_TTCustomer();
                            }
                        }
                        else
                        {
                            Ob.TTBenhnhan = new Cls_TTCustomer();
                        }
                    }
                    sqlDataReader.Close();
                    result = Ob;
                }
                return result;
            }
            public static int Insert(ObCustomer ob)
            {
                //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
                //int _STT;
                //DateTime _Ngay, _DTimesNew;
                //Cls_TTCustomer _TTBenhnhan;

                if (ob.Ma.Length > 6)
                {
                    try
                    {
                        ob.STT = MainNTP.ParseInt(ob.Ma.Substring(6));
                    }
                    catch
                    {

                    }
                }

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " INSERT INTO tb_Customer (Ma, Ten, Ngaysinh, Thangsinh, Namsinh, Gioitinh, Diachi, Dienthoai, CMND,Email,STT,Ngay,DTimesNew,TTBenhnhan) VALUES(@Ma, @Ten, @Ngaysinh, @Thangsinh, @Namsinh, @Gioitinh, @Diachi, @Dienthoai, @CMND,@Email,@STT,@Ngay,getdate(),@TTBenhnhan)";
                
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100;
                sqlParameter.Value = ob.Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter();sqlParameter.ParameterName = "Ten";sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500;sqlParameter.Value = ob.Ten;sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngaysinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ngaysinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Thangsinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Thangsinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Namsinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Namsinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Gioitinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Gioitinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Diachi"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Diachi; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Dienthoai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Dienthoai; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CMND"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.CMND; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Email"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Email; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "STT"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 100; sqlParameter.Value = ob.STT; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TTBenhnhan"; sqlParameter.SqlDbType = SqlDbType.Image;
                
                int num = -1;
                if (null != ob.TTBenhnhan)
                {
                    try
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, ob.TTBenhnhan);
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
            public static int Update(string maBN, ObCustomer ob)
            {
                //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
                //int _STT;
                //DateTime _Ngay, _DTimesNew;
                //Cls_TTCustomer _TTBenhnhan;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " UPDATE tb_Customer SET Ten=@Ten,Ngaysinh=@Ngaysinh,Thangsinh=@Thangsinh,Namsinh=@Namsinh,Gioitinh=@Gioitinh,Diachi=@Diachi,Dienthoai=@Dienthoai,CMND=@CMND,Email=@Email,STT=@STT,Ngay=@Ngay,TTBenhnhan=@TTBenhnhan WHERE (Ma=@MaBNDK)";
                SqlParameter sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ma"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ma; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBNDK"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = maBN; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngaysinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ngaysinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Thangsinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Thangsinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Namsinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Namsinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Gioitinh"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Gioitinh; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Diachi"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Diachi; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Dienthoai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Dienthoai; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CMND"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.CMND; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Email"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Email; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "STT"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 100; sqlParameter.Value = ob.STT; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TTBenhnhan"; sqlParameter.SqlDbType = SqlDbType.Image;
                int num = -1;
                if (null != ob.TTBenhnhan)
                {
                    try
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, ob.TTBenhnhan);
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
            public static int Delete(ObCustomer ob)
            {
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandText = "DELETE FROM tb_Customer WHERE(Ma=@Ma)";
                SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
                sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
                return DBStatic.SqlExcuteNonQuery(sqlcommand);
            }
            public static KeysListObCustomer GetListOb()
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_Customer";
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                KeysListObCustomer list = new KeysListObCustomer();
                if (null == sqlDataReader)
                {
                    list = null;
                }
                else
                {
                    ObCustomer ob = null;
                    while (sqlDataReader.Read())
                    {
                        ob = new ObCustomer();
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            ob.Ma = sqlDataReader.GetString(0);
                        }
                        if (!sqlDataReader.IsDBNull(1))
                        {
                            ob.Ten = sqlDataReader.GetString(1);
                        }
                        if (!sqlDataReader.IsDBNull(2))
                        {
                            ob.Ngaysinh = sqlDataReader.GetInt32(2);
                        }
                        if (!sqlDataReader.IsDBNull(3))
                        {
                            ob.Thangsinh = sqlDataReader.GetInt32(3);
                        }
                        if (!sqlDataReader.IsDBNull(4))
                        {
                            ob.Namsinh = sqlDataReader.GetInt32(4);
                        }
                        if (!sqlDataReader.IsDBNull(5))
                        {
                            ob.Gioitinh = sqlDataReader.GetInt32(5);
                        }
                        if (!sqlDataReader.IsDBNull(6))
                        {
                            ob.Diachi = sqlDataReader.GetString(6);
                        }
                        if (!sqlDataReader.IsDBNull(7))
                        {
                            ob.Dienthoai = sqlDataReader.GetString(7);
                        }
                        if (!sqlDataReader.IsDBNull(8))
                        {
                            ob.CMND = sqlDataReader.GetString(8);
                        }
                        if (!sqlDataReader.IsDBNull(9))
                        {
                            ob.Email = sqlDataReader.GetString(9);
                        }
                        if (!sqlDataReader.IsDBNull(10))
                        {
                            ob.STT = sqlDataReader.GetInt32(10);
                        }
                        if (!sqlDataReader.IsDBNull(11))
                        {
                            ob.Ngay = sqlDataReader.GetDateTime(11);
                        }
                        if (!sqlDataReader.IsDBNull(12))
                        {
                            ob.DTimesNew = sqlDataReader.GetDateTime(12);
                        }
                        if (!sqlDataReader.IsDBNull(13))
                        {
                            byte[] array = (byte[])sqlDataReader.GetValue(13);
                            if (array.Length > 1)
                            {
                                try
                                {
                                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                                    MemoryStream serializationStream = new MemoryStream(array);
                                    ob.TTBenhnhan = (Cls_TTCustomer)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    ob.TTBenhnhan = new Cls_TTCustomer();
                                }
                            }
                            else
                            {
                                ob.TTBenhnhan = new Cls_TTCustomer();
                            }
                        }
                        else
                        {
                            ob.TTBenhnhan = new Cls_TTCustomer();
                        }
                        ob.TTBenhnhan.MaBN = ob.Ma;
                        list.Add(ob);
                    }
                    sqlDataReader.Close();
                }
                return list;
            }
 
    }
}
