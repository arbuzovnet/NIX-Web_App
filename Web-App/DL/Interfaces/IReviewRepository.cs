using System;
using DL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> DisplayLowRatings();
        IEnumerable<Review> DisplayHighRatings();
    }
}
