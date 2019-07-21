using Mic.Repository.Consts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mic.Repository
{
    public abstract class BaseRepository
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract string TableName { get; }
        protected virtual string PrimaryKey => DbNames.Col_Id;
        protected virtual string DestroyDate => DbNames.Col_DestroyDate;
        protected int OnExecuteScalar(string query,IEnumerable<SqlParameter> pars)
        {
            using (var cmd = _dbContext.CreateCommand())
            {
                cmd.CommandText = query;
                foreach (var item in pars)
                {
                    cmd.Parameters.Add(item);
                }
                return (int)cmd.ExecuteScalar();
            }
        }
        protected IEnumerable<IDataReader> OnExecute(string query)
        {
            using (var cmd = _dbContext.CreateCommand())
            {
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                if (reader.FieldCount > 0)
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                }
                if (reader != null)
                {
                    if (!reader.IsClosed)
                        reader.Close();
                }
            }
        }
        protected void OnExecuteNonQuery(string query)
        {
            using (var cmd = _dbContext.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    
}
