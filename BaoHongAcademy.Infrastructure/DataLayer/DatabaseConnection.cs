using BaoHongAcademy.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace BaoHongAcademy.Infrastructure.DataLayer
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string connectionStr = "Data Source=DESKTOP-R7RA7TV; Initial Catalog=BaoHongAcademyDevelopment; Integrated Security=SSPI; TrustServerCertificate=True";
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;

        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public IEnumerable<T> GetData<T>(string procedureName, IDictionary<string, object> parameters = null) where T : class
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procedureName;

            foreach (var param in parameters)
            {
                sqlCommand.Parameters.Add(new SqlParameter($"@{param.Key}", param.Value));
            }

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

        public IEnumerable<T> GetDataRawSql<T>(string sql, IDictionary<string, object> parameters = null) where T : class
        {
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;

            foreach (var param in parameters)
            {
                sqlCommand.Parameters.Add(new SqlParameter($"@{param.Key}", param.Value));
            }

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
        public void MapEntityAndParameter<T>(List<SqlParameter> sqlParameters, T entity) where T : BaseEntity
        {
            if (entity is null) return;

            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(entity, BindingFlags.Public | BindingFlags.Instance, null, null, CultureInfo.InvariantCulture);
                sqlParameters.Add(new SqlParameter($"@in_{property.Name}", value ?? DBNull.Value));
            }
        }

        public int InsertIntoDB<T>(string storeName, T entity) where T : BaseEntity
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storeName;

            var sqlParameters = new List<SqlParameter>();
            MapEntityAndParameter<T>(sqlParameters, entity);
            sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

            var result = sqlCommand.ExecuteNonQuery();
            return result;
        }

        public void Dispose()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Dispose();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
