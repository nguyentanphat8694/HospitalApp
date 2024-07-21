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
    public class NTPObNhapKho
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_NhapKho");
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
            sqlCommand.CommandText = "SELECT Ma FROM tb_NhapKho WHERE(Ma = @K_Ma)";
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
        public static ObNhapKho GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_NhapKho WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObNhapKho result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObNhapKho();
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
                        Ob.GhiChu = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(10);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTNhapKho();
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.NguoiNhap = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.Kho = sqlDataReader.GetString(12);
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static int Insert(ObNhapKho ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsTTNhapKho _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_NhapKho (Ma, Ngay, GhiChu,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime, TTChung,NguoiNhap,Kho) VALUES(@Ma, @Ngay, @GhiChu,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime, @TTChung,@NguoiNhap,@Kho)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "GhiChu"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.GhiChu; sqlCommand.Parameters.Add(sqlParameter);
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

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NguoiNhap"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.NguoiNhap; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Kho"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Kho; sqlCommand.Parameters.Add(sqlParameter);

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
        public static int Update(ObNhapKho ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_NhapKho SET Ngay=@Ngay, GhiChu=@GhiChu,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime, TTChung=@TTChung,NguoiNhap=@NguoiNhap,Kho=@Kho WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "GhiChu"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.GhiChu; sqlCommand.Parameters.Add(sqlParameter);
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

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NguoiNhap"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.NguoiNhap; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Kho"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Kho; sqlCommand.Parameters.Add(sqlParameter);

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
        public static int Update(ObNhapKho ob, etrangthai trangThai)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_NhapKho SET TrangThai=@TrangThai WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TrangThai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = trangThai.ToString(); sqlCommand.Parameters.Add(sqlParameter);

            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }
        public static int Delete(ObNhapKho ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_NhapKho WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObNhapKho GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_NhapKho";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObNhapKho list = new KeysListObNhapKho();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObNhapKho();
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
                        Ob.GhiChu = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(10);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTNhapKho();
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.NguoiNhap = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.Kho = sqlDataReader.GetString(12);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObNhapKho GetListOb(DateTime TuNgay,DateTime DenNgay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_NhapKho WHERE (Ngay>=@Tungay AND Ngay<=@Denngay)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "Tungay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = TuNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Denngay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = DenNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObNhapKho list = new KeysListObNhapKho();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObNhapKho();
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
                        Ob.GhiChu = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(10);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTNhapKho();
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.NguoiNhap = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.Kho = sqlDataReader.GetString(12);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }

        public static ObNhapKho GetObDieuChinhKho(DateTime TuNgay, DateTime DenNgay, string trangThai)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_NhapKho WHERE (Ngay>=@Tungay AND Ngay<=@Denngay and TrangThai=@TrangThai) Order By Ngay DESC";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "Tungay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = TuNgay.Date; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Denngay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = DenNgay.Date; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "TrangThai"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = trangThai; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);

            ObNhapKho Ob = null;

            if (null == sqlDataReader)
            {
                 
            }
            else
            {
                
                while (sqlDataReader.Read())
                {
                    Ob = new ObNhapKho();
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
                        Ob.GhiChu = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(10);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTNhapKho();
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.NguoiNhap = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.Kho = sqlDataReader.GetString(12);
                    }

                    break;
                }
                sqlDataReader.Close();
            }

            return Ob;
        }
    }
}
