using System;
using System.Data;
using System.Data.SqlClient;

namespace Mic.Repository
{
    public class DbContext : IDisposable
    {
        private readonly IDbConnection _connection;
        private bool disposed;

        public DbContext(string connectionString)
        {
            _connection = CreateAndOpen(connectionString);
        }

        public IDbConnection CreateAndOpen(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();

            return cmd;
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (_connection != null)
                    _connection.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
