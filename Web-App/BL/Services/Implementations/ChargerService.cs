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
    public class ChargerService : ICharger
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public ChargerService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public IEnumerable<ChargerDTO> GetChargerByCableType(string chargerCableType)
        {
            if (!string.IsNullOrEmpty(chargerCableType))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Cable == chargerCableType));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerByConnector(string chargerConnector)
        {
            if (!string.IsNullOrEmpty(chargerConnector))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Connector == chargerConnector));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerByType(string chargerType)
        {
            if (!string.IsNullOrEmpty(chargerType))
            {
                return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.Type == chargerType));
            }
            else
                return new List<ChargerDTO>();
        }

        public IEnumerable<ChargerDTO> GetChargerWithFastCharging()
        {
            return mapper.Map<IEnumerable<Charger>, IEnumerable<ChargerDTO>>(unitOfWork.ChargerRepository.Find(n => n.FastCharging == true));
        }

        public IEnumerable<ChargerDTO> GetCheapToExpensive()
        {
            return mapper.Map<IEnumerable<Charger>, List<ChargerDTO>>(unitOfWork.ChargerRepository.GetAll().OrderBy(u => u.Price));
        }

        public IEnumerable<ChargerDTO> GetExpensiveToCheap()
        {
            return mapper.Map<IEnumerable<Charger>, List<ChargerDTO>>(unitOfWork.ChargerRepository.GetAll().OrderByDescending(u => u.Price));
        }

        public IEnumerable<ChargerDTO> GetByReview()
        {
            List<Charger> products = unitOfWork.ChargerRepository.GetAll().OrderBy(n => n.Reviews.Count).ToList();
            return mapper.Map<List<Charger>, IList<ChargerDTO>>(products);
        }

        public IEnumerable<ChargerDTO> GetPopular()
        {
            throw new NotImplementedException();
        }

        public double GetProductRating(Guid productId)
        {
            var product = unitOfWork.ChargerRepository.Get(productId);
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
            var products = unitOfWork.ChargerRepository.Get(productId);
            if (products != null)
            {
                int count = unitOfWork.ReviewRepository.GetAll().Count(n => n.ProductProductId == productId);
                return count;
            }
            else
                return 0;
        }

        public ChargerDTO GetProduct(Guid productId)
        {
            var product = unitOfWork.ChargerRepository.Get(productId);
            if (product != null)
                return mapper.Map<Charger, ChargerDTO>(product);
            else
                return new ChargerDTO();
        }

        public IEnumerable<ChargerDTO> GetAllProducts()
        {
            return mapper.Map<IEnumerable<Charger>, List<ChargerDTO>>(unitOfWork.ChargerRepository.GetAll());
        }

        public ChargerDTO FindByName(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                List<Charger> products = unitOfWork.ChargerRepository.Find(n => n.Name == productName).ToList();
                if (products.Count != 0)
                    return mapper.Map<Charger, ChargerDTO>(products[0]);
                else
                    return new ChargerDTO();
            }
            else
                return new ChargerDTO();
        }

        public IEnumerable<ChargerDTO> GetProductsByBrand(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                List<Charger> products = unitOfWork.ChargerRepository.Find(n => n.Trademark.Name == modelName).ToList();
                if (products.Count != 0)
                {
                    return mapper.Map<List<Charger>, IList<ChargerDTO>>(products);
                }
                else
                    return new List<ChargerDTO>();
            }
            else
                return new List<ChargerDTO>();
        }
    }
}
