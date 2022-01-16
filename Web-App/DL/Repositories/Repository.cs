using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DL.EF;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext appContext;
        protected readonly ILogger logger;
        protected DbSet<T> dbSet;
        
        public Repository(ApplicationContext applicationContext, ILogger log)
        {
            appContext = applicationContext;
            logger = log;
            dbSet = appContext.Set<T>();
        }

        public virtual bool Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual bool AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            return true;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public virtual T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual bool RemoveById(Guid id)
        {
            T entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
            return true;
        }

        public virtual bool Remove(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual bool RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return true;
        }

        public virtual bool Update(T entity)
        {
            dbSet.Attach(entity);
            appContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
