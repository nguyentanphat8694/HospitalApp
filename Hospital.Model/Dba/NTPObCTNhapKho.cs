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
    public class NTPObCTNhapKho
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_CTNhapKho");
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
            sqlCommand.CommandText = "SELECT Ma FROM tb_CTNhapKho WHERE(Ma = @K_Ma)";
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
        public static ObCTNhapKho GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTNhapKho WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObCTNhapKho result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObCTNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTNhapKho();
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
                        Ob.MaDV = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.SL = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.DGNhap = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.DGBan = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.Kho = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.Solo = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KeyPhieuNhap = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(16);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCTNhapKho();
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static int Insert(ObCTNhapKho ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsTTCTNhapKho _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_CTNhapKho (Ma,Ngay, MaDV, SL, DGNhap, DGBan, Kho, Solo, KeyPhieuNhap,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime, TTChung) VALUES(@Ma,@Ngay, @MaDV, @SL, @DGNhap, @DGBan, @Kho, @Solo, @KeyPhieuNhap,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime, @TTChung)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SL"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.SL; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DGNhap"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DGNhap; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DGBan"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DGBan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Kho"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Kho; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Solo"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Solo; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyPhieuNhap"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyPhieuNhap; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Update(ObCTNhapKho ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CTNhapKho SET Ma=@Ma,Ngay=@Ngay, MaDV=@MaDV, SL=@SL, DGNhap=@DGNhap, DGBan=@DGBan, Kho=@Kho, Solo=@Solo, KeyPhieuNhap=@KeyPhieuNhap,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime, TTChung=@TTChung WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SL"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.SL; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DGNhap"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DGNhap; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DGBan"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DGBan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Kho"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Kho; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Solo"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Solo; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyPhieuNhap"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyPhieuNhap; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Update(ObCTNhapKho ob, etrangthai trangThai)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CTNhapKho SET TrangThai=@TrangThai WHERE (Ma=@Ma)";
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
        public static int Delete(ObCTNhapKho ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_CTNhapKho WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObCTNhapKho GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTNhapKho";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTNhapKho list = new KeysListObCTNhapKho();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTNhapKho();
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
                        Ob.MaDV = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.SL = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.DGNhap = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.DGBan = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.Kho = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.Solo = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KeyPhieuNhap = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(16);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCTNhapKho();
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCTNhapKho GetListOb(double maPN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTNhapKho Where KeyPhieuNhap=@KeyPhieuNhap";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "KeyPhieuNhap"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = maPN;
            sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTNhapKho list = new KeysListObCTNhapKho();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTNhapKho Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTNhapKho();
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
                        Ob.MaDV = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.SL = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.DGNhap = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.DGBan = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.Kho = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.Solo = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KeyPhieuNhap = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(16);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCTNhapKho)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCTNhapKho();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCTNhapKho();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCTNhapKho();
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
