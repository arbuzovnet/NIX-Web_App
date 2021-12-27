using DL.Models;
using DL.Interfaces;
using DL.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext applicationContext, ILogger logger)
            : base(applicationContext, logger)
        {

        }

        public override bool Add(Product entity)
        {
            try
            {
                appContext.Set<Product>().Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Add method error", typeof(ProductRepository));
                return false;
            }
        }

        public override bool AddRange(IEnumerable<Product> entities)
        {
            try
            {
                appContext.Set<Product>().AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} AddRange method error", typeof(ProductRepository));
                return false;
            }
        }

        public override IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            try
            {
                return appContext.Set<Product>().Where(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Find method error", typeof(ProductRepository));
                return new List<Product>();
            }
        }

        public override Product Get(Guid id)
        {
            try
            {
                return appContext.Set<Product>().Find(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Get method error", typeof(ProductRepository));
                return new Product();
            }
        }

        public override IEnumerable<Product> GetAll()
        {
            try
            {
                return appContext.Set<Product>().ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} GetAll method error", typeof(ProductRepository));
                return new List<Product>();
            }
        }

        public override bool Remove(Product entity)
        {
            try
            {
                var exist = appContext.Set<Product>().Where(x => x.ProductId == entity.ProductId)
                                                    .FirstOrDefault();
                if (exist != null)
                {
                    appContext.Set<Product>().Remove(entity);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Remove method error", typeof(ProductRepository));
                return false;
            }
        }

        public override bool RemoveRange(IEnumerable<Product> entities)
        {
            try
            {
                foreach(Product product in entities)
                {
                    var exist = appContext.Set<Product>().Where(x => x.ProductId == product.ProductId)
                                    .FirstOrDefault();
                    if (exist == null)
                        return false;
                }

                appContext.Set<Product>().RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} RemoveRange method error", typeof(ProductRepository));
                return false;
            }
        }
    }
}
