using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BaoHongAcademy.Infrastructure.DataLayer
{
    public class DatabaseConnection : IDisposable
    {
        private readonly string connectionStr = "Data Source=DESKTOP-R7RA7TV; Initial Catalog=BaoHongAcademyDevelopment; Integrated Security=SSPI; TrustServerCertificate=True";
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;

        public DatabaseConnection()
        {
            sqlConnection = new SqlConnection(connectionStr);
            sqlConnection.Open();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public void SetCommandType(SqlCommand command, CommandType commandType)
        {
            command.CommandType = commandType;
        }

        public IEnumerable<T> GetData<T>(string procedureName)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procedureName;
            using var sqlDataReader = sqlCommand.ExecuteReader();

            var result = new List<T>();
            while(sqlDataReader.Read())
            {
                var item = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal(property.Name)))
                    {
                        var dataDB = sqlDataReader[property.Name];
                        var value = (dynamic)null;
                        Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        if (convertTo.IsEnum)
                        {
                            value = Enum.ToObject(convertTo, dataDB);
                        }
                        else
                        {
                            value = Convert.ChangeType(dataDB, convertTo);
                        }
                        property.SetValue(item, value, null);
                    }
                }
                result.Add(item);
            }

            return result;
        }

        public IEnumerable<T> GetDataRawSql<T>(string sql, object[] parameters)
        {
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;

            sqlCommand.Parameters.Add(new SqlParameter("@in_Author", "Hung"));

            using var sqlDataReader = sqlCommand.ExecuteReader();

            var result = new List<T>();
            while (sqlDataReader.Read())
            {
                var item = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal(property.Name)))
                    {
                        var dataDB = sqlDataReader[property.Name];
                        var value = (dynamic)null;
                        Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        if (convertTo.IsEnum)
                        {
                            value = Enum.ToObject(convertTo, dataDB);
                        }
                        else
                        {
                            value = Convert.ChangeType(dataDB, convertTo);
                        }
                        property.SetValue(item, value, null);
                    }
                }
                result.Add(item);
            }

            return result;
        }

        public void MapObjectAndParameter()
        {

        }

        public void Dispose()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Dispose();
        }
    }
}
