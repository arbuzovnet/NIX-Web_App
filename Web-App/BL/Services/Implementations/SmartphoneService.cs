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
    public class SmartphoneService : ISmartphone
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public SmartphoneService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByBuiltMemory(int builtMemory)
        {
            if (builtMemory > 0)
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.BuiltMemory == builtMemory));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByMatrixType(string matrixType)
        {
            if (!string.IsNullOrEmpty(matrixType))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.Matrix == matrixType));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByOS(string os)
        {
            if (!string.IsNullOrEmpty(os))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.OS == os));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByRAM(int ram)
        {
            if (ram > 0)
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.RAM == ram));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetSmartphoneByResolution(string resolution)
        {
            if (!string.IsNullOrEmpty(resolution))
            {
                return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.Find(n => n.Resolution == resolution));
            }
            else
                return new List<SmartphoneDTO>();
        }

        public IEnumerable<SmartphoneDTO> GetCheapToExpensive()
        {
            return mapper.Map<IEnumerable<Smartphone>, List<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.GetAll().OrderBy(u => u.Price));
        }

        public IEnumerable<SmartphoneDTO> GetExpensiveToCheap()
        {
            return mapper.Map<IEnumerable<Smartphone>, List<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.GetAll().OrderByDescending(u => u.Price));
        }

        public IEnumerable<SmartphoneDTO> GetByReview()
        {
            List<Smartphone> products = unitOfWork.SmartphoneRepository.GetAll().OrderBy(n => n.Reviews.Count).ToList();
            return mapper.Map<List<Smartphone>, IList<SmartphoneDTO>>(products);
        }

        public IEnumerable<SmartphoneDTO> GetPopular()
        {
            throw new NotImplementedException();
        }

        public double GetProductRating(Guid productId)
        {
            var product = unitOfWork.SmartphoneRepository.Get(productId);
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
            var products = unitOfWork.SmartphoneRepository.Get(productId);
            if (products != null)
            {
                int count = unitOfWork.ReviewRepository.GetAll().Count(n => n.ProductProductId == productId);
                return count;
            }
            else
                return 0;
        }

        public SmartphoneDTO GetProduct(Guid productId)
        {
            var product = unitOfWork.SmartphoneRepository.Get(productId);
            if (product != null)
                return mapper.Map<Smartphone, SmartphoneDTO>(product);
            else
                return new SmartphoneDTO();
        }

        public IEnumerable<SmartphoneDTO> GetAllProducts()
        {
            return mapper.Map<IEnumerable<Smartphone>, IEnumerable<SmartphoneDTO>>(unitOfWork.SmartphoneRepository.GetAll());
        }

        public SmartphoneDTO FindByName(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                List<Smartphone> products = unitOfWork.SmartphoneRepository.Find(n => n.Name == productName).ToList();
                if (products.Count != 0)
                    return mapper.Map<Smartphone, SmartphoneDTO>(products[0]);
                else
                    return new SmartphoneDTO();
            }
            else
                return new SmartphoneDTO();
        }

        public IEnumerable<SmartphoneDTO> GetProductsByBrand(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                List<Smartphone> products = unitOfWork.SmartphoneRepository.Find(n => n.Trademark.Name == modelName).ToList();
                if (products.Count != 0)
                {
                    return mapper.Map<List<Smartphone>, IList<SmartphoneDTO>>(products);
                }
                else
                    return new List<SmartphoneDTO>();
            }
            else
                return new List<SmartphoneDTO>();
        }

        public bool ProductAvailability(Guid productId)
        {
            if (QuantityInStock(productId) > 0)
                return true;
            else
                return false;
        }

        public int QuantityInStock(Guid productId)
        {
            return unitOfWork.DeliveryRepository.Find(n => n.ProductProductId == productId).Sum(s => s.NumberOfGoodsDelivered);
        }
    }
}
