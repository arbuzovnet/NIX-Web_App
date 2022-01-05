using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DL.EF;
using DL.Interfaces;
using DL.Models;
using Microsoft.Extensions.Logging;

namespace DL.Repositories
{
    class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext applicationContext, ILogger logger)
            : base(applicationContext, logger)
        {

        }

        public override bool Add(Review entity)
        {
            try
            {
                if(appContext.Set<Product>().Find(entity.ProductProductId) != null)
                {
                    appContext.Set<Review>().Add(entity);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Add method error", typeof(ReviewRepository));
                return false;
            }
        }

        public override bool AddRange(IEnumerable<Review> entities)
        {
            try
            {
                foreach(Review review in entities)
                {
                    if (appContext.Set<Product>().Find(review.ProductProductId) == null)
                        return false;
                }
                appContext.Set<Review>().AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} AddRange method error", typeof(ReviewRepository));
                return false;
            }
        }

        public override IEnumerable<Review> Find(Expression<Func<Review, bool>> expression)
        {
            try
            {
                return appContext.Set<Review>().Where(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Find method error", typeof(ReviewRepository));
                return new List<Review>();
            }
        }

        public override Review Get(Guid id)
        {
            try
            {
                return appContext.Set<Review>().Find(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Get method error", typeof(ReviewRepository));
                return new Review();
            }
        }

        public override IEnumerable<Review> GetAll()
        {
            try
            {
                return appContext.Set<Review>().ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} GetAll method error", typeof(ReviewRepository));
                return new List<Review>();
            }
        }

        public override bool RemoveById(Guid id)
        {
            try
            {
                var entityToDelete = dbSet.Where(x => x.ReviewId == id)
                                                    .FirstOrDefault();
                if (entityToDelete != null)
                {
                    dbSet.Remove(entityToDelete);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} RemoveById method error", typeof(ReviewRepository));
                return false;
            }
        }

        public override bool Remove(Review entity)
        {
            try
            {
                var exist = appContext.Set<Review>().Where(x => x.ReviewId == entity.ReviewId)
                                                    .FirstOrDefault();
                if (exist != null)
                {
                    appContext.Set<Review>().Remove(entity);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} Remove method error", typeof(ReviewRepository));
                return false;
            }
        }

        public override bool RemoveRange(IEnumerable<Review> entities)
        {
            try
            {
                foreach (Review Review in entities)
                {
                    var exist = appContext.Set<Review>().Where(x => x.ReviewId == Review.ReviewId)
                                    .FirstOrDefault();
                    if (exist == null)
                        return false;
                }

                appContext.Set<Review>().RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repository} RemoveRange method error", typeof(ReviewRepository));
                return false;
            }
        }
    }
}
