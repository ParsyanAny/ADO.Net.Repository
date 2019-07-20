using Mic.Repository.Consts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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
            //return OnExecute(query).Select(reader => CreateEntity(reader));
            //IEnumerable<IDataReader> readers = OnExecute(query);
            //foreach (var reader in readers)
            //{
            //    TEntity entity = CreateEntity(reader);
            //}
        }
        public TEntity FirstOrDefault(int id)
        {
            string query = string.Format(Queries.SelectOne, TableName, PrimaryKey, id);
            return OnExecute(query).Select(CreateEntity).FirstOrDefault();
            //List<TEntity> entities = OnExecute(query);
            //if (entities != null && entities.Count > 0)
            //    return entities[0];
            //return null;
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

            //Type entityType = entity.GetType();
            //PropertyInfo[] propInf = entityType.GetProperties();

            //foreach (var property in propInf)
            //{
            //    object val = property.GetValue(entity);
            //    var param = new SqlParameter($"@{property.Name}", val);
            //    parameters.Add(param);
            //    string query = string.Format(Queries.Insert, TableName, property.Name, val);
            //    OnExecute(query);
            //}
        }
    }
}