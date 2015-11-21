using Linear.Relational.Core.Contracs;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Linear.Relational.SqlServer
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        public readonly string _connectionString;

        public SqlServerConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Value cannot be null or whitespace!", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public IDbConnection CreateOpened()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;            
        }
    }
}
