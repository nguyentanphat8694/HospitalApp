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
    public class NTPObHenKham
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_HenKham");
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
            sqlCommand.CommandText = "SELECT Ma FROM tb_HenKham WHERE(Ma = @K_Ma)";
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
        public static ObHenKham GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObHenKham result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                }
                
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static ObHenKham GetObWF_MaBA(double MaBA)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE(MaBA = @MaBA)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaBA";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = MaBA;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObHenKham result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                }
                
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static ObHenKham GetObWF_PK(string maBN,DateTime ngay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE(MaBN = @MaBN AND Ngay=@Ngay)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaBN";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = maBN;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ngay";
            sqlParameter.SqlDbType = SqlDbType.Date;
            sqlParameter.Value = ngay;
            sqlCommand.Parameters.Add(sqlParameter);


            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObHenKham result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                }
                if (!sqlDataReader.IsDBNull(4))
                {
                    Ob.MaBA = sqlDataReader.GetDouble(4);
                }
                if (!sqlDataReader.IsDBNull(5))
                {
                    Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                }
                if (!sqlDataReader.IsDBNull(6))
                {
                    Ob.TrangThai = sqlDataReader.GetString(6);
                }
                if (!sqlDataReader.IsDBNull(7))
                {
                    Ob.CreateBy = sqlDataReader.GetString(7);
                }
                if (!sqlDataReader.IsDBNull(8))
                {
                    Ob.CreateTime = sqlDataReader.GetString(8);
                }
                if (!sqlDataReader.IsDBNull(9))
                {
                    Ob.UpdateBy = sqlDataReader.GetString(9);
                }
                if (!sqlDataReader.IsDBNull(10))
                {
                    Ob.UpdateTime = sqlDataReader.GetString(10);
                }
                if (!sqlDataReader.IsDBNull(11))
                {
                    Ob.DeleteBy = sqlDataReader.GetString(11);
                }
                if (!sqlDataReader.IsDBNull(12))
                {
                    Ob.DeleteTime = sqlDataReader.GetString(12);
                }
                if (!sqlDataReader.IsDBNull(13))
                {
                    Ob.ChanDoan = sqlDataReader.GetString(13);
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static int Insert(ObHenKham ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsTTHenKham _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_HenKham (Ma, Ngay, MaBN, TTChung,MaBA,NgayDenKham,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime,ChanDoan) VALUES(@Ma, @Ngay, @MaBN, @TTChung,@MaBA,@NgayDenKham,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime,@ChanDoan)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBN"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBN; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBA"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBA; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NgayDenKham"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 100; sqlParameter.Value = ob.NgayDenKham; sqlCommand.Parameters.Add(sqlParameter);
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ChanDoan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ChanDoan; sqlCommand.Parameters.Add(sqlParameter);

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
        public static int Update(ObHenKham ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_HenKham SET Ngay=@Ngay, MaBN=@MaBN, TTChung=@TTChung,MaBA=@MaBA,NgayDenKham=@NgayDenKham,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime,ChanDoan=@ChanDoan WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBN"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBN; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBA"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBA; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NgayDenKham"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 100; sqlParameter.Value = ob.NgayDenKham; sqlCommand.Parameters.Add(sqlParameter);
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ChanDoan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ChanDoan; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Delete(ObHenKham ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_HenKham WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObHenKham GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObHenKham list = new KeysListObHenKham();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObHenKham GetListOb(DateTime TuNgay,DateTime DenNgay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE (NgayDenKham>=@Tungay AND NgayDenKham<=@Denngay)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "Tungay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = TuNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Denngay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = DenNgay.Date; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObHenKham list = new KeysListObHenKham();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObHenKham GetListOb(string chanDoan)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE (ChanDoan LIKE N'%" + chanDoan + "%')";
            SqlParameter sqlparameter = new SqlParameter();
            //sqlparameter.ParameterName = "ChanDoan"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            //sqlparameter.Value = chanDoan; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObHenKham list = new KeysListObHenKham();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }

        public static KeysListObHenKham GetListObByMaBN(string maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE (MaBN like N'" + maBN + "')";
            SqlParameter sqlparameter = new SqlParameter();
            //sqlparameter.ParameterName = "ChanDoan"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            //sqlparameter.Value = chanDoan; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObHenKham list = new KeysListObHenKham();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }

        public static KeysListObHenKham GetListObByNgayDenKham(DateTime ngay, string bacSi)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_HenKham WHERE (NgayDenKham >=@NgayDenKham AND NgayDenKham <= @NgayDenKham AND BacSi=@BacSi)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "NgayDenKham"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = ngay.Date; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "BacSi"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Size = 100; sqlparameter.Value = bacSi; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObHenKham list = new KeysListObHenKham();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObHenKham Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObHenKham();
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
                        Ob.MaBN = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(3);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTHenKham)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTHenKham();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTHenKham();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTHenKham();
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.MaBA = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.NgayDenKham = sqlDataReader.GetDateTime(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(13);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
