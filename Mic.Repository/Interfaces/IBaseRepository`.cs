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

        //IEnumerable<TEntity> SelectAll(string query);
       // int Delete(int id);
       // int Update(TEntity entity);
       // int InsertOrUpdate(TEntity entity);
    }
}
