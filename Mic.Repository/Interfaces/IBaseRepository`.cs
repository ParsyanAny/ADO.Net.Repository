using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mic.Repository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> SelectAll();   // SELECT * WHERE {...}
        TEntity SelectOne(int id);  //  SELECT * FROM {...} WHERE Id = {...}
        TEntity SelectOne(string query); // SELECT * FROM {...} WHERE {...}
        IEnumerable<TEntity> SelectWhere(string query);  // SELECT * FROM {...} WHERE {...}
        TEntity FirstOrDefault();
        int Insert(TEntity entity);
        void Delete(int id);
        int Update(TEntity entity, int id);

       // int InsertOrUpdate(TEntity entity);
    }
}
