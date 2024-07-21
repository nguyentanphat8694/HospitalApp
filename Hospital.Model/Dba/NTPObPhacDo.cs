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
    public class NTPObPhacDo
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_PhacDo");
            double Ma = 0;
            if (null != sqlDataReader)
                while (sqlDataReader.Read())
                {
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ma = sqlDataReader.GetDouble(0);
                        break;
                    }
                }
            sqlDataReader.Close();
            return Ma + 1;
        }
        public static bool TestExistPK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT Ma FROM tb_PhacDo WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
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
        public static ObPhacDo GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_PhacDo WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObPhacDo result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObPhacDo Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObPhacDo();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.Ten = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.Loai = sqlDataReader.GetInt32(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(11);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTPhacDo)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTPhacDo();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTPhacDo();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTPhacDo();
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static int Insert(ObPhacDo ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsTTPhacDo _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_PhacDo (Ma, Ngay, Ten, Loai,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime, TTChung) VALUES(@Ma, @Ngay, @Ten, @Loai ,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime, @TTChung)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TrangThai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.TrangThai; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CreateBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.CreateBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CreateTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.CreateTime; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateTime; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DeleteBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.DeleteBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DeleteTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DeleteTime; sqlCommand.Parameters.Add(sqlParameter);


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
        public static int Update(ObPhacDo ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_PhacDo SET Ngay=@Ngay,Ten=@Ten,Loai=@Loai,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime, TTChung=@TTChung WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TrangThai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.TrangThai; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CreateBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.CreateBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "CreateTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.CreateTime; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateTime; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DeleteBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.DeleteBy; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DeleteTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DeleteTime; sqlCommand.Parameters.Add(sqlParameter);


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
        
        public static int Delete(ObPhacDo ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_PhacDo WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObPhacDo GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_PhacDo";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObPhacDo list = new KeysListObPhacDo();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObPhacDo Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObPhacDo();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.Ten = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.Loai = sqlDataReader.GetInt32(3);
                    }

                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(11);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTPhacDo)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTPhacDo();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTPhacDo();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTPhacDo();
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
