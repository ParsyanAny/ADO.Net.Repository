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
        }  //SELECT * FROM {...}
        public TEntity SelectOne(int id)
        {
            string query = string.Format(Queries.SelectWhereId, TableName, id);
            return OnExecute(query).Select(CreateEntity).FirstOrDefault();
        }  //SELECT * FROM {...} WHERE Id = {...}
        public IEnumerable<TEntity> SelectWhere(string whereQuery)
        {
            string query = string.Format(Queries.SelectAllWhere, TableName, whereQuery);
            return OnExecute(query).Select(CreateEntity);
        } // SELECT * FROM {...} WHERE {...}
        public TEntity SelectOne(string whereQuery)
        {
            string query = string.Format(Queries.SelectWhere, TableName, whereQuery);
            return OnExecute(query).Select(CreateEntity).FirstOrDefault();
        } //SELECT * FROM {...} WHERE {...}
        public TEntity FirstOrDefault()
        {
            string query = string.Format(Queries.FirstOrDefault, TableName);
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
            string query = string.Format(Queries.InsertScalar, TableName, nameText, valueText);

            return OnExecuteScalar(query, parameters);
        }
        public int Update(TEntity entity, int id)
        {
            var nameBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in entity.GetType().GetProperties().Where(p => p.Name != PrimaryKey && p.GetValue(entity) != null))
            {
                if (prop != null)
                {
                    nameBuilder.Append(prop.Name).Append("=").Append("@").Append(prop.Name).Append(",");

                    var sqlP = new SqlParameter(prop.Name, prop.PropertyType);
                    object value = prop.GetValue(entity);
                    if (value == null)
                        value = DBNull.Value;
                    sqlP.Value = value;
                    parameters.Add(sqlP);
                }
            }
            string nameText = nameBuilder.ToString().TrimEnd(',');
            string query = string.Format(Queries.Update, TableName, nameText, id, TableName);

            return (int)OnExecuteScalar(query, parameters);
        }  // Update with Id
        public int Update(TEntity entity)
        {
            Type t = entity.GetType();
            int id = (int)t.GetProperties().First().GetValue(entity);

            var nameBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var prop in entity.GetType().GetProperties().Where(p => p.Name != PrimaryKey && p.GetValue(entity) != null))
            {
                if (prop != null)
                {
                    nameBuilder.Append(prop.Name).Append("=").Append("@").Append(prop.Name).Append(",");

                    var sqlP = new SqlParameter(prop.Name, prop.PropertyType);
                    object value = prop.GetValue(entity);
                    if (value == null)
                        value = DBNull.Value;
                    sqlP.Value = value;
                    parameters.Add(sqlP);
                }
            }
            string nameText = nameBuilder.ToString().TrimEnd(',');
            string query = string.Format(Queries.Update, TableName, nameText, id, TableName);

            return (int)OnExecuteScalar(query, parameters);
        }  // Update without Id
        public int InsertOrUpdate(TEntity entity)
        {
            Type t = entity.GetType();
            int id = (int)t.GetProperties().First().GetValue(entity);
            if (id == 0)
                return Insert(entity);
            return Update(entity);
        }
        public void Delete(int id)
        {
            string query = string.Format(Queries.Delete, TableName, id);
            OnExecuteNonQuery(query);
        }  //DELETE {...} WHERE Id = {...}
    }
}