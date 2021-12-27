using System;
using DL.Interfaces;
using DL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repositories
{
    class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository() : base()
        {

        }
        public IEnumerable<Review> DisplayHighRatings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> DisplayLowRatings()
        {
            throw new NotImplementedException();
        }
    }
}
