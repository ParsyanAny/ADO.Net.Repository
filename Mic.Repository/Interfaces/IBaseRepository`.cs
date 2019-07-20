using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.Repository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> SelectAll();
        TEntity FirstOrDefault(int id);
        int Insert(TEntity entity);
        void Delete(int id);

        //IEnumerable<TEntity> SelectAll(string query);
       // int Update(TEntity entity);
       // int InsertOrUpdate(TEntity entity);
    }
}
