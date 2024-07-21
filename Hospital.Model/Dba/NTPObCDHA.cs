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
    public class NTPObCDHA
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_CDHA");
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
            sqlCommand.CommandText = "SELECT Ma FROM tb_CDHA WHERE(Ma = @K_Ma)";
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
        public static ObCDHA GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObCDHA result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }

                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static int Insert(ObCDHA ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsTTCDHA _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_CDHA (Ma, Ngay, MaBN, MaBA, ChanDoan, KeyCTChiDinh, BSThucHien,KTV1,KTV2,KTV3,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime, TTChung,KetLuan) VALUES(@Ma, @Ngay, @MaBN, @MaBA, @ChanDoan, @KeyCTChiDinh, @BSThucHien,@KTV1,@KTV2,@KTV3,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime, @TTChung, @KetLuan)";

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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ChanDoan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ChanDoan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyCTChiDinh"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.KeyCTChiDinh; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "BSThucHien"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.BSThucHien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV1"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KTV1; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV2"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.KTV2; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV3"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KTV3; sqlCommand.Parameters.Add(sqlParameter);
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

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KetLuan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KetLuan; sqlCommand.Parameters.Add(sqlParameter);


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
        public static int Update(ObCDHA ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CDHA SET Ngay=@Ngay, MaBN=@MaBN, MaBA=@MaBA, ChanDoan=@ChanDoan, KeyCTChiDinh=@KeyCTChiDinh, BSThucHien=@BSThucHien,KTV1=@KTV1,KTV2=@KTV2,KTV3=@KTV3,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime, TTChung=@TTChung,KetLuan=@KetLuan WHERE (Ma=@Ma)";
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ChanDoan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ChanDoan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyCTChiDinh"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.KeyCTChiDinh; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "BSThucHien"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.BSThucHien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV1"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KTV1; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV2"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.KTV2; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KTV3"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KTV3; sqlCommand.Parameters.Add(sqlParameter);
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KetLuan"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KetLuan; sqlCommand.Parameters.Add(sqlParameter);


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
        public static int Update(ObCDHA ob, etrangthai trangThai)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CDHA SET TrangThai=@TrangThai WHERE (Ma=@Ma)";
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
        public static int Delete(ObCDHA ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_CDHA WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObCDHA GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }

                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }

                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCDHA GetListOb(DateTime TuNgay,DateTime DenNgay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA WHERE (Ngay>=@Tungay AND Ngay<=@Denngay)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "Tungay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = TuNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Denngay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = DenNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }


                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCDHA GetListOb(String maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA Where MaBN=@MaBN";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }

                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }

                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCDHA GetListOb_SAThai(String maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA Where MaBN=@MaBN AND MaBA=@MaBA";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBA"; sqlparameter.SqlDbType = SqlDbType.Int;
            sqlparameter.Value = 1; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }


                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCDHA GetListOb_ChanDoan(String chanDoan)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA Where (ChanDoan LIKE N'%" + chanDoan + "%' OR KetLuan LIKE N'%" + chanDoan + "%')";
            //SqlParameter sqlparameter = new SqlParameter();
            //sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            //sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }

                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }

                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCDHA GetListOb_MaxNgay(string maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CDHA WHERE MaBN=@MaBN AND MaBA='1' AND DTimesNew = (SELECT Max(DTimesNew) FROM tb_CDHA where MaBN=@MaBN AND TrangThai <> N'Đã_hủy')";

            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCDHA list = new KeysListObCDHA();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCDHA Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCDHA();
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
                        Ob.MaBA = sqlDataReader.GetDouble(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.ChanDoan = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyCTChiDinh = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.BSThucHien = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.KTV1 = sqlDataReader.GetString(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.KTV2 = sqlDataReader.GetString(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.KTV3 = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(17);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsTTCDHA)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsTTCDHA();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsTTCDHA();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsTTCDHA();
                    }

                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.KetLuan = sqlDataReader.GetString(18);
                    }

                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
