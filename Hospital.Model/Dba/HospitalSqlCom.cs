using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hospital.App
{
    public class HospitalSqlCom
    {
        public List<HospitalParam> HospitalParams { get; set; }
        public string TableName { get; set; }
        public HospitalSqlCom(List<HospitalParam> SqlParameters, string tablename)
        {
            HospitalParams = SqlParameters;
            TableName = tablename;
        }
        public HospitalSqlCom()
        {
        }
        public void GetField(object obj,List<string> listWhere) {
            HospitalParams = new List<HospitalParam>();
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var fi in fields) {
                HospitalParam param = new HospitalParam();
                param.Name = fi.ToString();
                param.value = fi.GetValue(obj);
                if (listWhere != null && listWhere.Count > 0 && listWhere.Any(o => o.Trim() == fi.Name))
                    param.isWhere = true;
                if (fi.FieldType == typeof(int))
                    param.DbType = SqlDbType.Int;
                else if (fi.FieldType == typeof(string))
                    param.DbType = SqlDbType.NVarChar;
                else if (fi.FieldType == typeof(double))
                    param.DbType = SqlDbType.Float;
                else param.DbType = SqlDbType.Image;
                HospitalParams.Add(param);
            }
        }
        public int Insert()
        {
            SqlCommand sqlCommand = new SqlCommand();
            string sql = " INSERT INTO " + TableName + " (";
            string columnName = "";
            string columnValue = "";

            foreach (HospitalParam param in HospitalParams)
            {
                if (columnName.Trim() != "")
                    columnName += ",";
                columnName += param.Name;
                if (columnValue.Trim() != "")
                    columnValue += ",";
                columnValue += "@" + param.Name;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = param.Name;
                sqlParameter.SqlDbType = param.DbType;

                if (param.DbType == SqlDbType.Image)
                {
                    int num = -1;
                    if (null != param.value)
                    {
                        try
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            MemoryStream memoryStream = new MemoryStream();
                            binaryFormatter.Serialize(memoryStream, param.value);
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
                }
                else sqlParameter.Value = param.value;

                sqlCommand.Parameters.Add(sqlParameter);
            }

            sql += columnName + ") VALUES(" + columnValue + ")";
            sqlCommand.CommandText = sql;
            //tb_Customer (Ma, Ten, Ngaysinh, Thangsinh, Namsinh, Gioitinh, Diachi, Dienthoai, CMND,Email,STT,Ngay,DTimesNew,TTBenhnhan) VALUES(@Ma, @Ten, @Ngaysinh, @Thangsinh, @Namsinh, @Gioitinh, @Diachi, @Dienthoai, @CMND,@Email,@STT,@Ngay,getdate(),@TTBenhnhan)";
            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }
        public int Update()
        {
            SqlCommand sqlCommand = new SqlCommand();
            string sql = " UPDATE " + TableName + " SET ";
            string columnName = "";
            string Where = "";

            foreach (HospitalParam param in HospitalParams)
            {
                if (param.isWhere)
                {
                    if (Where.Trim() != "")
                        Where += ",";
                    Where += param.Name + "=@" + param.Name;
                }
                else {
                    if (columnName.Trim() != "")
                        columnName += ",";
                    columnName += param.Name + "=@" + param.Name;
                }
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = param.Name;
                sqlParameter.SqlDbType = param.DbType;

                if (param.DbType == SqlDbType.Image)
                {
                    int num = -1;
                    if (null != param.value)
                    {
                        try
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            MemoryStream memoryStream = new MemoryStream();
                            binaryFormatter.Serialize(memoryStream, param.value);
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
                }
                else sqlParameter.Value = param.value;

                sqlCommand.Parameters.Add(sqlParameter);
            }

            sql += columnName + ") WHERE (" + Where + ")";
            sqlCommand.CommandText = sql;
            return DBStatic.SqlExcuteNonQuery(sqlCommand);
        }
    }

    public class HospitalParam {
        public string Name { get; set; }
        public SqlDbType DbType { get; set; }
        public object value { get; set; }
        public bool isWhere { get; set; }
    }
}
