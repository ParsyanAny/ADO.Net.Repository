using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.Repository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        IEnumerable<TEntity> SelectAll();
        //IEnumerable<TEntity> SelectAll(string query);
        TEntity FirstOrDefault(int id);

        int Insert(TEntity entity);
       // int Delete(int id);
       // int Update(TEntity entity);
       // int InsertOrUpdate(TEntity entity);
    }
}
