using Mic.Repository.Consts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mic.Repository
{
    public abstract class BaseRepository<TEntity> : BaseRepository, IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        protected BaseRepository(DbContext dbContext) : base(dbContext) { }
        protected abstract TEntity CreateEntity(IDataReader reader);

        public IEnumerable<TEntity> SelectAll()
        {
            string query = string.Format(Queries.SelectAll, TableName);
            return OnExecute(query).Select(CreateEntity);
        }
        public TEntity FirstOrDefault(int id)
        {
            string query = string.Format(Queries.SelectOne, TableName, PrimaryKey, id);
            return OnExecute(query).Select(CreateEntity).FirstOrDefault();
        }
        public int Insert(TEntity entity)
        {
            var nameBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in entity.GetType().GetProperties().Where(p => p.Name != PrimaryKey))
            {
                nameBuilder.Append(prop.Name).Append(",");
                valueBuilder.Append("@").Append(prop.Name).Append(",");

                var sqlP = new SqlParameter(prop.Name, prop.PropertyType);
                object value = prop.GetValue(entity);
                if (value == null)
                    value = DBNull.Value;
                sqlP.Value = value;
                parameters.Add(sqlP);
            }
            string nameText = nameBuilder.ToString().TrimEnd(',');
            string valueText = valueBuilder.ToString().TrimEnd(',');
            return OnExecuteScalar(nameText,valueText,parameters);
        }
        public void Delete(int id)
        {
                string query = string.Format(Queries.Delete, TableName, id);
                OnExecuteNonQuery(query);
        }
        public IEnumerable<IDataReader> SelectOne(int id) //
        {
            string query = string.Format(Queries.SelectOne, TableName, id);
            return OnExecute(query);
        }

        public int Update(TEntity entity, int id)
        {
            string query = string.Format(Queries.Update, TableName, name, surname, id);
            OnExecuteScalar();
            return 1;
        }
    }
}