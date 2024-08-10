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
    public class NTPObDMKho
    {
            public static bool TestExistKho(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT Ma FROM tb_DMKho WHERE(Ma = @K_Ma)";
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
            public static ObDMKho GetObWF_Kho(string K_Ma)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_DMKho WHERE(Ma = @K_Ma)";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "K_Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Value = K_Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                ObDMKho result;
                if (null == sqlDataReader)
                {
                    result = null;
                }
                else
                {
                    ObDMKho ObKho = null;
                    while (sqlDataReader.Read())
                    {
                        ObKho = new ObDMKho();
                        if (!sqlDataReader.IsDBNull(0))
                        {
                            ObKho.Ma = sqlDataReader.GetString(0);
                        }
                        if (!sqlDataReader.IsDBNull(1))
                        {
                            ObKho.Ten = sqlDataReader.GetString(1);
                        }
                        if (!sqlDataReader.IsDBNull(2))
                        {
                            ObKho.Loai = sqlDataReader.GetInt32(2);
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
                                    ObKho.TTChung = (Cls_TTDMKho)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    ObKho.TTChung = new Cls_TTDMKho();
                                }
                            }
                            else
                            {
                                ObKho.TTChung = new Cls_TTDMKho();
                            }
                        }
                        else
                        {
                            ObKho.TTChung = new Cls_TTDMKho();
                        }
                    }
                    sqlDataReader.Close();
                    result = ObKho;
                }
                return result;
            }
            public static int Insert(ObDMKho ob)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " INSERT INTO tb_DMKho (Ma, Ten,Loai,TTChung) VALUES(@Ma, @Ten,@Loai,@TTChung)";

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "Ma";
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100;
                sqlParameter.Value = ob.Ma;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
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
            public static int Update(string ma, ObDMKho ob)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = " UPDATE tb_DMKho SET Ma=@Ma,Ten=@Ten,Loai=@Loai,TTChung=@TTChung WHERE (Ma=@MaBNDK)";
                SqlParameter sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ma"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 100; sqlParameter.Value = ob.Ma; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "MaBNDK"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = ma; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Ten"; sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Size = 150; sqlParameter.Value = ob.Ten; sqlCommand.Parameters.Add(sqlParameter);
                sqlParameter = new SqlParameter(); sqlParameter.ParameterName = "Loai"; sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Size = 500; sqlParameter.Value = ob.Loai; sqlCommand.Parameters.Add(sqlParameter);
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
            public static int Delete(ObDMKho ob)
            {
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandText = "DELETE FROM tb_DMKho WHERE(Ma=@Ma)";
                SqlParameter sqlparameter = new SqlParameter(); sqlparameter.ParameterName = "Ma"; sqlparameter.SqlDbType = SqlDbType.NVarChar;
                sqlparameter.Size = 100; sqlparameter.Value = ob.Ma; sqlcommand.Parameters.Add(sqlparameter);
                return DBStatic.SqlExcuteNonQuery(sqlcommand);
            }
            public static KeysListObDMKho GetListOb()
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM tb_DMKho";
                SqlDataReader sqlDataReader = DBStatic.SqlExcuteQuery(sqlCommand);
                KeysListObDMKho list = new KeysListObDMKho();
                if (null == sqlDataReader)
                {
                    list = null;
                }
                else
                {
                    ObDMKho Obtb_Customer = null;
                    while (sqlDataReader.Read())
                    {
                        Obtb_Customer = new ObDMKho();
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
                            Obtb_Customer.Loai = sqlDataReader.GetInt32(2);
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
                                    Obtb_Customer.TTChung = (Cls_TTDMKho)binaryFormatter.Deserialize(serializationStream);
                                }
                                catch
                                {
                                    Obtb_Customer.TTChung = new Cls_TTDMKho();
                                }
                            }
                            else
                            {
                                Obtb_Customer.TTChung = new Cls_TTDMKho();
                            }
                        }
                        else
                        {
                            Obtb_Customer.TTChung = new Cls_TTDMKho();
                        }
                        list.Add(Obtb_Customer);
                    }
                    sqlDataReader.Close();
                }
                return list;
            }
        
    }
}