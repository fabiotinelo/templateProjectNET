using System.Data;
using System.Data.Common;
using Npgsql;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Data.SqlClient;

namespace Globant.StandardArchitecture.Infrastructure.Persistence
{
    public enum DatabaseType
    {
        SqlServer,
        PostgreSQL,
        MySQL,
        Oracle
    }

    public class DatabaseHelper : IDisposable
    {
        private readonly DbConnection dbConnection;
        private readonly DbProviderFactory dbProviderFactory;

        public DatabaseHelper(DatabaseType provider, string connectionString)
        {
            dbProviderFactory = GetFactory(provider);
            dbConnection = dbProviderFactory.CreateConnection() ?? throw new InvalidOperationException("Falha ao criar a conexão com o banco de dados.");
            if (dbConnection == null) throw new Exception("Falha ao criar conexão.");
            dbConnection.ConnectionString = connectionString;
        }

        private DbProviderFactory GetFactory(DatabaseType provider)
        {
            return provider switch
            {
                DatabaseType.SqlServer => SqlClientFactory.Instance,
                DatabaseType.PostgreSQL => NpgsqlFactory.Instance,
                DatabaseType.MySQL => MySqlClientFactory.Instance,
                DatabaseType.Oracle => OracleClientFactory.Instance,
                _ => throw new NotSupportedException("Banco de dados não suportado."),
            };
        }

        public void Open() => dbConnection.Open();

        public void Close() => dbConnection.Close();

        public DataTable ExecuteQuery(string query, params DbParameter[] parameters)
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            if (parameters != null) command.Parameters.AddRange(parameters);

            using var adapter = dbProviderFactory.CreateDataAdapter() ?? throw new InvalidOperationException("Falha ao criar o DataAdapter.");
            adapter.SelectCommand = command;

            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int ExecuteNonQuery(string query, params DbParameter[] parameters)
        {
            using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            if (parameters != null) command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbConnection?.Close();
                dbConnection?.Dispose();
            }
        }

        ~DatabaseHelper()
        {
            Dispose(false);
        }

    }
}
