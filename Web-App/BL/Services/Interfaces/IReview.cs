using System;
using System.Collections.Generic;
using BL.DTO;

namespace BL.Services.Interfaces
{
    interface IReview
    {
        IEnumerable<ReviewDTO> DisplayLowRatings();                     // Отобразить отзывы с низкими рейтингами (1-3)
        IEnumerable<ReviewDTO> DisplayHighRatings();                    // Отобразить отзывы с высокими рейтнгами (4-5)
        void EditReview(Guid reviewId, int newRating, string newText);  // Изменить отзыв 

    }
}
