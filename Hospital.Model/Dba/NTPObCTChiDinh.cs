using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hospital.App
{
    public class NTPObCTChiDinh
    {
        public static double GetNextID()
        {
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery("Select Max(Ma) From tb_CTChiDinh");
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
            sqlCommand.CommandText = "SELECT Ma FROM tb_CTChiDinh WHERE(Ma = @K_Ma)";
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
        public static bool TestExistPK(DateTime ngay, string MaPK, string MaBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT Ma FROM tb_CTChiDinh WHERE(Ngay=@Ngay AND MaPK=@MaPK AND MaBN=@MaBN)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ngay";
            sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Value = ngay;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaBN";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = MaBN;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaBK";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = MaPK;
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
        public static ObCTChiDinh GetObWF_PK(double K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObCTChiDinh result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        public static ObCTChiDinh GetObWF_PK(DateTime ngay, string MaPK, string MaBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE(Ngay=@Ngay AND MaPK=@MaPK AND MaBN=@MaBN AND TrangThai <> @TrangThai)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ngay";
            sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Value = ngay;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaBN";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = MaBN;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "MaPK";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = MaPK;
            sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "TrangThai";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = etrangthai.Đã_hủy.ToString();
            sqlCommand.Parameters.Add(sqlParameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObCTChiDinh result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }
        
        public static int Insert(ObCTChiDinh ob)
        {
            //string _MaBN, _TenBN, _Ngaysinh, _Thangsinh, _Namsinh, _Gioitinh, _Diachi, _Dienthoai, _CMND, _Doituong;
            //int _STT;
            //DateTime _Ngay, _DTimesNew;
            //ClsCTChiDinh _TTChung;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_CTChiDinh (Ma,MaDV, KeyThucHien, BSCreate, KeyCreate, KeyPT, SL, DG,SLBan,SoGiam,ThanhTien,LoaiHangHoa,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime,TTChung,Ngay,MaPK,MaBN,LoaiPhieuTH) VALUES(@Ma,@MaDV, @KeyThucHien, @BSCreate, @KeyCreate, @KeyPT, @SL, @DG,@SLBan,@SoGiam,@ThanhTien,@LoaiHangHoa,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime, @TTChung,@Ngay,@MaPK,@MaBN,@LoaiPhieuTH)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyThucHien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyThucHien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "BSCreate"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.BSCreate; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyCreate"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyCreate; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyPT"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyPT; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SL"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.SL; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DG"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DG; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SLBan"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.SLBan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SoGiam"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.SoGiam; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ThanhTien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ThanhTien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "LoaiHangHoa"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 100; sqlParameter.Value = ob.LoaiHangHoa; sqlCommand.Parameters.Add(sqlParameter);
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaPK"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaPK; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBN"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBN; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "LoaiPhieuTH"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 500; sqlParameter.Value = ob.LoaiPhieuTH; sqlCommand.Parameters.Add(sqlParameter);


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
        public static int Update(ObCTChiDinh ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CTChiDinh SET MaDV=@MaDV, KeyThucHien=@KeyThucHien, BSCreate=@BSCreate, KeyCreate=@KeyCreate, KeyPT=@KeyPT, SL=@SL, DG=@DG,SLBan=@SLBan,SoGiam=@SoGiam,ThanhTien=@ThanhTien,LoaiHangHoa=@LoaiHangHoa,TrangThai=@TrangThai,CreateBy=@CreateBy,CreateTime=@CreateTime,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,DeleteBy=@DeleteBy,DeleteTime=@DeleteTime, TTChung=@TTChung,Ngay=@Ngay,MaPK=@MaPK,MaBN=@MaBN,LoaiPhieuTH=@LoaiPhieuTH WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyThucHien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyThucHien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "BSCreate"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.BSCreate; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyCreate"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyCreate; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyPT"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.KeyPT; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SL"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.SL; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "DG"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.DG; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SLBan"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.SLBan; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "SoGiam"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.SoGiam; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ThanhTien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ThanhTien; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "LoaiHangHoa"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 100; sqlParameter.Value = ob.LoaiHangHoa; sqlCommand.Parameters.Add(sqlParameter);
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
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.Date;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaPK"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaPK; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBN"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.MaBN; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "LoaiPhieuTH"; sqlParameter.SqlDbType = SqlDbType.Int;
            sqlParameter.Size = 500; sqlParameter.Value = ob.LoaiPhieuTH; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Update(ObCTChiDinh ob, etrangthai trangThai)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_CTChiDinh SET TrangThai=@TrangThai WHERE (Ma=@Ma)";
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
        public static int Delete(ObCTChiDinh ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_CTChiDinh WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.Int;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObCTChiDinh GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTChiDinh list = new KeysListObCTChiDinh();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCTChiDinh GetListOb(DateTime tuNgay,DateTime denNgay)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE (Ngay>=@Tungay AND Ngay<=@Denngay AND TrangThai <> @TrangThai)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "Tungay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = tuNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Denngay"; sqlparameter.SqlDbType = SqlDbType.DateTime;
            sqlparameter.Value = denNgay.Date; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "TrangThai"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value =etrangthai.Đã_hủy.ToString(); sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTChiDinh list = new KeysListObCTChiDinh();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCTChiDinh GetListOb(double KeyCreate,int loaiHH)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE (KeyCreate=@KeyCreate And LoaiHangHoa=@LoaiHangHoa AND TrangThai <> @TrangThai)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "KeyCreate"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Value = KeyCreate; sqlCommand.Parameters.Add(sqlparameter);
            sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "LoaiHangHoa"; sqlparameter.SqlDbType = SqlDbType.Int;
            sqlparameter.Value = loaiHH; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "TrangThai"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = etrangthai.Đã_hủy.ToString(); sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTChiDinh list = new KeysListObCTChiDinh();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static List<ObCTChiDinh> GetListOb_KeyCreate(double KeyCreate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE (KeyCreate=@KeyCreate AND TrangThai <> @TrangThai)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "KeyCreate"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Value = KeyCreate; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "TrangThai"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = etrangthai.Đã_hủy.ToString(); sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            List<ObCTChiDinh> list = new List<ObCTChiDinh>();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCTChiDinh GetListOb_KeyPT(double keyPT)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE (KeyPT=@KeyPT AND TrangThai <> @TrangThai)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "KeyPT"; sqlparameter.SqlDbType = SqlDbType.Float;
            sqlparameter.Value = keyPT; sqlCommand.Parameters.Add(sqlparameter);

            sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "TrangThai"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = etrangthai.Đã_hủy.ToString(); sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTChiDinh list = new KeysListObCTChiDinh();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
        public static KeysListObCTChiDinh GetListOb(string maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_CTChiDinh WHERE (MaBN=@MaBN)";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObCTChiDinh list = new KeysListObCTChiDinh();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObCTChiDinh Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObCTChiDinh();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.Ma = sqlDataReader.GetDouble(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaDV = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.KeyThucHien = sqlDataReader.GetDouble(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.BSCreate = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.KeyCreate = sqlDataReader.GetDouble(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.SL = sqlDataReader.GetDouble(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        Ob.DG = sqlDataReader.GetDouble(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        Ob.SLBan = sqlDataReader.GetDouble(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        Ob.SoGiam = sqlDataReader.GetDouble(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        //Ob.ThanhTien = sqlDataReader.GetDouble(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        Ob.LoaiHangHoa = sqlDataReader.GetInt32(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.CreateBy = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        Ob.CreateTime = sqlDataReader.GetString(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        Ob.UpdateBy = sqlDataReader.GetString(15);
                    }
                    if (!sqlDataReader.IsDBNull(16))
                    {
                        Ob.UpdateTime = sqlDataReader.GetString(16);
                    }
                    if (!sqlDataReader.IsDBNull(17))
                    {
                        Ob.DeleteBy = sqlDataReader.GetString(17);
                    }
                    if (!sqlDataReader.IsDBNull(18))
                    {
                        Ob.DeleteTime = sqlDataReader.GetString(18);
                    }
                    if (!sqlDataReader.IsDBNull(19))
                    {
                        byte[] array = (byte[])sqlDataReader.GetValue(19);
                        if (array.Length > 1)
                        {
                            try
                            {
                                BinaryFormatter binaryFormatter = new BinaryFormatter();
                                MemoryStream serializationStream = new MemoryStream(array);
                                Ob.TTChung = (ClsCTChiDinh)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Ob.TTChung = new ClsCTChiDinh();
                            }
                        }
                        else
                        {
                            Ob.TTChung = new ClsCTChiDinh();
                        }
                    }
                    else
                    {
                        Ob.TTChung = new ClsCTChiDinh();
                    }
                    if (!sqlDataReader.IsDBNull(20))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(20);
                    }
                    if (!sqlDataReader.IsDBNull(21))
                    {
                        Ob.MaPK = sqlDataReader.GetString(21);
                    }
                    if (!sqlDataReader.IsDBNull(22))
                    {
                        Ob.MaBN = sqlDataReader.GetString(22);
                    }
                    if (!sqlDataReader.IsDBNull(23))
                    {
                        Ob.LoaiPhieuTH = sqlDataReader.GetInt32(23);
                    }
                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
