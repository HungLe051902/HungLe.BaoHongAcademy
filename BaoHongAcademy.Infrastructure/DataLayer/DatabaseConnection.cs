using BaoHongAcademy.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.DataLayer
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private const string connectionStr = "Data Source=DESKTOP-R7RA7TV; Initial Catalog=BaoHongAcademyDevelopment; Integrated Security=SSPI; TrustServerCertificate=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _sqlCommand;
        private SqlTransaction sqlTransaction;

        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DatabaseConnection()
        {
            _sqlConnection = new SqlConnection(connectionStr);
            _sqlConnection.Open();
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }

        public void SetCommandType(SqlCommand command, CommandType commandType)
        {
            command.CommandType = commandType;
        }

        public IEnumerable<T> GetData<T>(string procedureName, IDictionary<string, object> parameters = null) where T : class
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = _sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = procedureName;

                SetParameters(sqlCommand.Parameters, parameters);

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
        }

        public IEnumerable<T> GetDataRawSql<T>(string sql, IDictionary<string, object> parameters = null) where T : class
        {
            _sqlCommand.CommandType = CommandType.Text;
            _sqlCommand.CommandText = sql;

            SetParameters(_sqlCommand.Parameters, parameters);

            using var sqlDataReader = _sqlCommand.ExecuteReader();

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
                sqlParameters.Add(new SqlParameter(ToParameter(property.Name), value ?? DBNull.Value));
            }
        }

        public void Dispose()
        {
            if (_sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
            _sqlConnection.Dispose();
        }

        public int ExcuteCommand(string commandText, bool isSqlRaw = false, IDictionary<string, object> parameters = null)
        {
            try
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = _sqlConnection;
                    if (this.sqlTransaction != null)
                    {
                        command.Transaction = this.sqlTransaction;
                    }
                    command.CommandType = isSqlRaw ? CommandType.Text : CommandType.StoredProcedure;
                    command.CommandText = commandText;

                    SetParameters(command.Parameters, parameters);

                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                RollBack();
                return 0;
            }
        }

        public async Task<int> ExcuteCommandAync(string commandText, bool isSqlRaw = false, IDictionary<string, object> parameters = null)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = _sqlConnection;
                if (this.sqlTransaction != null)
                {
                    command.Transaction = this.sqlTransaction;
                }
                command.CommandType = isSqlRaw ? CommandType.Text : CommandType.StoredProcedure;
                command.CommandText = commandText;

                SetParameters(command.Parameters, parameters);

                return await command.ExecuteNonQueryAsync();
            }
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
            this.sqlTransaction = _sqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            if (this.sqlTransaction != null)
            {
                this.sqlTransaction.Commit();
            }
        }

        public void RollBack()
        {
            if (this.sqlTransaction != null)
            {
                this.sqlTransaction.Rollback();
            }
        }

        #region PRIVATE METHODS
        private string ToParameter(string name)
        {
            return $"@in_{name ?? ""}";
        }

        private void SetParameters(SqlParameterCollection sqlParameter , IDictionary<string, object> parameters = null)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    sqlParameter.Add(new SqlParameter(ToParameter(param.Key), param.Value));
                }
            }
        }
        #endregion
    }
}
