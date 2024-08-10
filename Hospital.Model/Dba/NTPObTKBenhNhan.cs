using System;
using System.Data;
using System.Data.SqlClient;

namespace Hospital.App
{
    public class NTPObTKBenhNhan
    {
        public static int Insert(ObTKBenhNhan ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_TKBenhNhan (ID, MaBN, Ngay, NguoiThu, QuayThu, ThanhTien,TrangThai,CreateBy,CreateTime,UpdateBy,UpdateTime,DeleteBy,DeleteTime) VALUES(@ID, @MaBN, @Ngay, @NguoiThu, @QuayThu, @ThanhTien,@TrangThai,@CreateBy,@CreateTime,@UpdateBy,@UpdateTime,@DeleteBy,@DeleteTime)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "ID"; sqlParameter.SqlDbType = SqlDbType.UniqueIdentifier;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ID; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBN"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.MaBN; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ngay"; sqlParameter.SqlDbType = SqlDbType.DateTime;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ngay; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "NguoiThu"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.NguoiThu; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "QuayThu"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.QuayThu; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ThanhTien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.ThanhTien; sqlCommand.Parameters.Add(sqlParameter);

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
            sqlParameter.Size = 500; sqlParameter.Value = ob.DeleteTime; sqlCommand.Parameters.Add(sqlParameter);

            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }

        public static int Update(ObTKBenhNhan ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_TKBenhNhan SET ThanhTien=@ThanhTien,TrangThai=@TrangThai,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,KeyPT=@KeyPT WHERE ID=@ID";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "ID"; sqlParameter.SqlDbType = SqlDbType.UniqueIdentifier;
            sqlParameter.Size = 100; sqlParameter.Value = ob.ID; sqlCommand.Parameters.Add(sqlParameter);

            
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "ThanhTien"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.ThanhTien; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "TrangThai"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.TrangThai; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateBy"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateBy; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "UpdateTime"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.UpdateTime; sqlCommand.Parameters.Add(sqlParameter);

            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "KeyPT"; sqlParameter.SqlDbType = SqlDbType.Float;
            sqlParameter.Size = 500; sqlParameter.Value = ob.KeyPT; sqlCommand.Parameters.Add(sqlParameter);

            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }

        public static ObTKBenhNhan GetObWF_PK(Guid ID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_TKBenhNhan WHERE(ID = @ID)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "ID";
            sqlParameter.SqlDbType = SqlDbType.UniqueIdentifier;
            sqlParameter.Value = ID;
            sqlCommand.Parameters.Add(sqlParameter);

            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObTKBenhNhan result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObTKBenhNhan Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObTKBenhNhan();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.ID = Guid.Parse(sqlDataReader.GetString(0));
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaBN = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.NguoiThu = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.QuayThu = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.ThanhTien = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(13);
                    }
                }
                sqlDataReader.Close();
                result = Ob;
            }
            return result;
        }

        public static KeysListObTKBenhNhan GetListOb(String maBN)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_TKBenhNhan Where MaBN=@MaBN";
            SqlParameter sqlparameter = new SqlParameter();
            sqlparameter.ParameterName = "MaBN"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Value = maBN; sqlCommand.Parameters.Add(sqlparameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObTKBenhNhan list = new KeysListObTKBenhNhan();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObTKBenhNhan Ob = null;
                while (sqlDataReader.Read())
                {
                    Ob = new ObTKBenhNhan();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Ob.ID = sqlDataReader.GetSqlGuid(0).Value;
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Ob.MaBN = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Ob.Ngay = sqlDataReader.GetDateTime(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        Ob.NguoiThu = sqlDataReader.GetString(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        Ob.QuayThu = sqlDataReader.GetString(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        Ob.ThanhTien = sqlDataReader.GetDouble(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        Ob.TrangThai = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        Ob.KeyPT = sqlDataReader.GetDouble(13);
                    }

                    list.Add(Ob);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
