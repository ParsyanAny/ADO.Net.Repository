using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mic.Repository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> SelectAll();
        IEnumerable<IDataReader> SelectOne(int id);
        TEntity FirstOrDefault(int id);
        int Insert(TEntity entity);
        void Delete(int id);
        int Update(TEntity entity, int id);

        //IEnumerable<TEntity> SelectAll(string query);
       // int InsertOrUpdate(TEntity entity);
    }
}
