using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DL.Interfaces
{
    interface IRepository<T> where T : class
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);

        bool RemoveById(Guid id);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);

        bool Update(T entity);
    }
}



//List<T> GetAllList();
//T Get(Guid id);
//bool Create(T entity);
//bool Update(T entity);
//bool Delete(T entity);
//void Save();