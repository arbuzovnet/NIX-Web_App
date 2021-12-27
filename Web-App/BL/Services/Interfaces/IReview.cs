using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    interface IReview
    {
        IEnumerable<Review> DisplayLowRatings();            // Отобразить отзывы с низкими рейтингами (1-3)
        IEnumerable<Review> DisplayHighRatings();           // Отобразить отзывы с высокими рейтнгами (4-5)

    }
}
