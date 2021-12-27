using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DL.Context;
using DL.Interfaces;
using Microsoft.Extensions.Logging;

namespace DL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext appContext;
        protected readonly ILogger logger;
        
        public Repository(ApplicationContext applicationContext, ILogger log)
        {
            appContext = applicationContext;
            logger = log;
        }

        public virtual bool Add(T entity)
        {
            appContext.Set<T>().Add(entity);
            return true;
        }

        public virtual bool AddRange(IEnumerable<T> entities)
        {
            appContext.Set<T>().AddRange(entities);
            return true;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return appContext.Set<T>().Where(expression);
        }

        public virtual T Get(Guid id)
        {
            return appContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return appContext.Set<T>().ToList();
        }

        public virtual bool Remove(T entity)
        {
            appContext.Set<T>().Remove(entity);
            return true;
        }

        public virtual bool RemoveRange(IEnumerable<T> entities)
        {
            appContext.Set<T>().RemoveRange(entities);
            return true;
        }
    }
}
