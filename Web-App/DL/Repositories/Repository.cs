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
    public class Repository<T> : IRepository<T> where T : class, new()          // new() ???
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
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Add method error", typeof(T));
                return false;
            }
        }

        public virtual bool AddRange(IEnumerable<T> entities)
        {
            try
            {
                dbSet.AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} AddRange method error", typeof(T));
                return false;
            }
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return dbSet.Where(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Find method error", typeof(T));
                return new List<T>();
            }
        }

        public virtual T Get(Guid id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Get method error", typeof(T));
                return new T();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} GetAll method error", typeof(T));
                return new List<T>();
            }
        }

        public virtual bool RemoveById(Guid id)
        {
            try
            {
                T entityToDelete = dbSet.Find(id);
                dbSet.Remove(entityToDelete);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} RemoveById method error", typeof(T));
                return false;
            }
        }

        public virtual bool Remove(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Remove method error", typeof(T));
                return false;
            }
        }

        public virtual bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} RemoveRange method error", typeof(T));
                return false;
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                appContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Update method error", typeof(T));
                return false;
            }
        }
    }
}
