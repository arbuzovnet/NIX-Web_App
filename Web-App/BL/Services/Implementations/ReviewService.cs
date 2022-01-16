using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using DL.EF;
using DL.Models;
using DL.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services.Implementations
{
    public class ReviewService : IReview
    {
        private UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReviewService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public IEnumerable<ReviewDTO> DisplayHighRatings()
        {
            return mapper.Map<List<Review>, List<ReviewDTO>>(unitOfWork.ReviewRepository.GetAll().Where(n => n.Rating > 3).ToList());
        }

        public IEnumerable<ReviewDTO> DisplayLowRatings()
        {
            return mapper.Map<List<Review>, List<ReviewDTO>>(unitOfWork.ReviewRepository.GetAll().Where(n => n.Rating <= 3).ToList());
        }

        public void EditReview(Guid reviewId, int newRating, string newText)
        {
            Review review = unitOfWork.ReviewRepository.Get(reviewId);
            review.Rating = newRating;
            review.ReviewText = newText;
            review.Date = DateTime.Now;
            review.ChangeStatus = true;
            unitOfWork.ReviewRepository.Update(review);
            unitOfWork.Save();
        }
    }
}
