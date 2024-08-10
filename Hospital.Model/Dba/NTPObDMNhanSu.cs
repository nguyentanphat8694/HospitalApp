﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hospital.App
{
    public class NTPObDMNhanSu
    {
            public static bool TestExistPK(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT Ma FROM tb_DMNhanSu WHERE(Ma = @K_Ma)";
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
            public static ObDMNhanSu GetObWF_PK(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_DMNhanSu WHERE(Ma = @K_Ma)";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "K_Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Value = K_Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                ObDMNhanSu result;
                if (null == sqlDataReader)
                {
                    result = null;
                }
                else
                {
                    ObDMNhanSu ObICD = null;
                    while (sqlDataReader.Read())
                    {
                        ObICD = new ObDMNhanSu();
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
                            ObICD.Loai = (eLoaiNS)sqlDataReader.GetInt32(2);
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
                                    ObICD.TTChung = (Cls_TTDMNhanSu)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    ObICD.TTChung = new Cls_TTDMNhanSu();
                                }
                            }
                            else
                            {
                                ObICD.TTChung = new Cls_TTDMNhanSu();
                            }
                        }
                        else
                        {
                            ObICD.TTChung = new Cls_TTDMNhanSu();
                        }
                    }
                    sqlDataReader.Close();
                    result = ObICD;
                }
                return result;
            }
            public static int Insert(ObDMNhanSu ob)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " INSERT INTO tb_DMNhanSu (Ma, Ten,Loai,TTChung) VALUES(@Ma, @Ten,@Loai,@TTChung)";

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100;
                sqlParameter.Value = ob.Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 500; sqlParameter.Value = (int)ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
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
            public static int Update(string ma, ObDMNhanSu ob)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " UPDATE tb_DMNhanSu SET Ma=@Ma,Ten=@Ten,Loai=@Loai,TTChung=@TTChung WHERE (Ma=@MaBNDK)";
                SqlParameter sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ma"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ma; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBNDK"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = ma; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 500; sqlParameter.Value = (int)ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
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
            public static int Delete(ObDMNhanSu ob)
            {
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandText = "DELETE FROM tb_DMNhanSu WHERE(Ma=@Ma)";
                SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
                sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
                return DBStatic.SqlExcuteNonQuery(sqlcommand);
            }
            public static KeysListObDMNhanSu GetListOb()
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_DMNhanSu";
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                KeysListObDMNhanSu list = new KeysListObDMNhanSu();
                if (null == sqlDataReader)
                {
                    list = null;
                }
                else
                {
                    ObDMNhanSu Obtb_Customer = null;
                    while (sqlDataReader.Read())
                    {
                        Obtb_Customer = new ObDMNhanSu();
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
                            Obtb_Customer.Loai = (eLoaiNS)sqlDataReader.GetInt32(2);
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
                                    Obtb_Customer.TTChung = (Cls_TTDMNhanSu)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    Obtb_Customer.TTChung = new Cls_TTDMNhanSu();
                                }
                            }
                            else
                            {
                                Obtb_Customer.TTChung = new Cls_TTDMNhanSu();
                            }
                        }
                        else
                        {
                            Obtb_Customer.TTChung = new Cls_TTDMNhanSu();
                        }
                        list.Add(Obtb_Customer);
                    }
                    sqlDataReader.Close();
                }
                return list;
            }
        
    }
}