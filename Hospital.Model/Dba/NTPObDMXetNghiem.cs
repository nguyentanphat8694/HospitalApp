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
    public class NTPObDMXetNghiem
    {
        public static ObDMXetNghiem GetObWF_PK(string K_Ma)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_DMXetNghiem WHERE(Ma = @K_Ma)";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "K_Ma";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Value = K_Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            ObDMXetNghiem result;
            if (null == sqlDataReader)
            {
                result = null;
            }
            else
            {
                ObDMXetNghiem ObICD = null;
                while (sqlDataReader.Read())
                {
                    ObICD = new ObDMXetNghiem();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        ObICD.Ma = sqlDataReader.GetString(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        ObICD.Ten = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        ObICD.MaDV = sqlDataReader.GetString(2);
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
                                ObICD.TTChung = (Cls_TTDMXetNghiem)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                ObICD.TTChung = new Cls_TTDMXetNghiem();
                            }
                        }
                        else
                        {
                            ObICD.TTChung = new Cls_TTDMXetNghiem();
                        }
                    }
                    else
                    {
                        ObICD.TTChung = new Cls_TTDMXetNghiem();
                    }
                }
                sqlDataReader.Close();
                result = ObICD;
            }
            return result;
        }
        public static int Insert(ObDMXetNghiem ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " INSERT INTO tb_DMXetNghiem (Ma, Ten,MaDV,TTChung) VALUES(@Ma, @Ten,@MaDV,@TTChung)";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "Ma";
            sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100;
            sqlParameter.Value = ob.Ma;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Update(string ma, ObDMXetNghiem ob)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " UPDATE tb_DMXetNghiem SET Ten=@Ten, MaDV=@MaDV, TTChung=@TTChung WHERE (Ma=@Ma)";
            SqlParameter sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ma"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 100; sqlParameter.Value = ob.Ma; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 150; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
            sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaDV"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameter.Size = 500; sqlParameter.Value = ob.MaDV; sqlCommand.Parameters.Add(sqlParameter);
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
        public static int Delete(ObDMXetNghiem ob)
        {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = "DELETE FROM tb_DMXetNghiem WHERE(Ma=@Ma)";
            SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
            sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
            return DBStatic.SqlExcuteNonQuery(sqlcommand);
        }
        public static KeysListObDMXetNghiem GetListOb()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM tb_DMXetNghiem";
            SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
            KeysListObDMXetNghiem list = new KeysListObDMXetNghiem();
            if (null == sqlDataReader)
            {
                list = null;
            }
            else
            {
                ObDMXetNghiem Obtb_Customer = null;
                while (sqlDataReader.Read())
                {
                    Obtb_Customer = new ObDMXetNghiem();
                    if (!sqlDataReader.IsDBNull(0))
                    {
                        Obtb_Customer.Ma = sqlDataReader.GetString(0);
                    }
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        Obtb_Customer.Ten = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        Obtb_Customer.MaDV = sqlDataReader.GetString(2);
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
                                Obtb_Customer.TTChung = (Cls_TTDMXetNghiem)binaryFormatter.Deserialize(serializationStream);
                            }
                            catch
                            {
                                Obtb_Customer.TTChung = new Cls_TTDMXetNghiem();
                            }
                        }
                        else
                        {
                            Obtb_Customer.TTChung = new Cls_TTDMXetNghiem();
                        }
                    }
                    else
                    {
                        Obtb_Customer.TTChung = new Cls_TTDMXetNghiem();
                    }
                    list.Add(Obtb_Customer);
                }
                sqlDataReader.Close();
            }
            return list;
        }
    }
}
