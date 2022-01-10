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
    public class HeadphonesService : IHeadphones
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public HeadphonesService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByConnectionType(string connectionType)
        {
            if (!string.IsNullOrEmpty(connectionType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Connection == connectionType));
            }
            else
                return new List<HeadphonesDTO>();
        }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByFasteningType(string fasteningType)
        {
            if (!string.IsNullOrEmpty(fasteningType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Fastening == fasteningType));
            }
            else
                return new List<HeadphonesDTO>();
        }

        public IEnumerable<HeadphonesDTO> GetHeadphonesByType(string headType)
        {
            if (!string.IsNullOrEmpty(headType))
            {
                return mapper.Map<IEnumerable<Headphones>, IEnumerable<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.Find(n => n.Kind == headType));
            }
            else
                return new List<HeadphonesDTO>();
        }

        public IEnumerable<HeadphonesDTO> GetCheapToExpensive()
        {
            return mapper.Map<IEnumerable<Headphones>, List<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.GetAll().OrderBy(u => u.Price));
        }

        public IEnumerable<HeadphonesDTO> GetExpensiveToCheap()
        {
            return mapper.Map<IEnumerable<Headphones>, List<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.GetAll().OrderByDescending(u => u.Price));
        }

        public IEnumerable<HeadphonesDTO> GetByReview()
        {
            List<Headphones> products = unitOfWork.HeadphonesRepository.GetAll().OrderBy(n => n.Reviews.Count).ToList();
            return mapper.Map<List<Headphones>, IList<HeadphonesDTO>>(products);
        }

        public IEnumerable<HeadphonesDTO> GetPopular()
        {
            throw new NotImplementedException();
        }

        public double GetProductRating(Guid productId)
        {
            var product = unitOfWork.HeadphonesRepository.Get(productId);
            if (product != null)
            {
                List<Review> resultList = unitOfWork.ReviewRepository.Find(n => n.ProductProductId == productId).ToList();
                return resultList.Average(n => n.Rating);
            }
            else
                return 0;
        }

        public int GetReviewsNumber(Guid productId)
        {
            var products = unitOfWork.HeadphonesRepository.Get(productId);
            if (products != null)
            {
                int count = unitOfWork.ReviewRepository.GetAll().Count(n => n.ProductProductId == productId);
                return count;
            }
            else
                return 0;
        }

        public HeadphonesDTO GetProduct(Guid productId)
        {
            var product = unitOfWork.HeadphonesRepository.Get(productId);
            if (product != null)
                return mapper.Map<Headphones, HeadphonesDTO>(product);
            else
                return new HeadphonesDTO();
        }

        public IEnumerable<HeadphonesDTO> GetAllProducts()
        {
            return mapper.Map<IEnumerable<Headphones>, List<HeadphonesDTO>>(unitOfWork.HeadphonesRepository.GetAll());
        }

        public HeadphonesDTO FindByName(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                List<Headphones> products = unitOfWork.HeadphonesRepository.Find(n => n.Name == productName).ToList();
                if (products.Count != 0)
                    return mapper.Map<Headphones, HeadphonesDTO>(products[0]);
                else
                    return new HeadphonesDTO();
            }
            else
                return new HeadphonesDTO();
        }

        public IEnumerable<HeadphonesDTO> GetProductsByBrand(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                List<Headphones> products = unitOfWork.HeadphonesRepository.Find(n => n.Trademark.Name == modelName).ToList();
                if (products.Count != 0)
                {
                    return mapper.Map<List<Headphones>, IList<HeadphonesDTO>>(products);
                }
                else
                    return new List<HeadphonesDTO>();
            }
            else
                return new List<HeadphonesDTO>();
        }
    }
}
