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
    public class CaseService : ICase
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;
        public CaseService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public CaseDTO FindByName(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                List<Case> products = unitOfWork.CaseRepository.Find(n => n.Name == productName).ToList();
                if (products.Count != 0)
                    return mapper.Map<Case, CaseDTO>(products[0]);
                else
                    return new CaseDTO();
            }
            else
                return new CaseDTO();
        }

        public IEnumerable<CaseDTO> GetAllProducts()
        {
            return mapper.Map<IEnumerable<Case>, List<CaseDTO>>(unitOfWork.CaseRepository.GetAll());
        }

        public IEnumerable<CaseDTO> GetByReview()
        {
            List<Case> products = unitOfWork.CaseRepository.GetAll().OrderBy(n => n.Reviews.Count).ToList();
            return mapper.Map<List<Case>, IList<CaseDTO>>(products);
        }

        public IEnumerable<CaseDTO> GetCaseByColor(string caseColor)
        {
            if (!string.IsNullOrEmpty(caseColor))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Color == caseColor));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByMaterial(string caseMaterial)
        {
            if (!string.IsNullOrEmpty(caseMaterial))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Material == caseMaterial));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByModel(string caseModel)
        {
            if (!string.IsNullOrEmpty(caseModel))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.CompatibilityByModel == caseModel));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCaseByType(string caseType)
        {
            if (!string.IsNullOrEmpty(caseType))
            {
                return mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(unitOfWork.CaseRepository.Find(n => n.Type == caseType));
            }
            else
                return new List<CaseDTO>();
        }

        public IEnumerable<CaseDTO> GetCheapToExpensive()
        {
            return mapper.Map<IEnumerable<Case>, List<CaseDTO>>(unitOfWork.CaseRepository.GetAll().OrderBy(u => u.Price));
        }

        public IEnumerable<CaseDTO> GetExpensiveToCheap()
        {
            return mapper.Map<IEnumerable<Case>, List<CaseDTO>>(unitOfWork.CaseRepository.GetAll().OrderByDescending(u => u.Price));
        }

        public IEnumerable<CaseDTO> GetPopular()
        {
            throw new NotImplementedException();
        }

        public CaseDTO GetProduct(Guid productId)
        {
            var product = unitOfWork.CaseRepository.Get(productId);
            if (product != null)
                return mapper.Map<Case, CaseDTO>(product);
            else
                return new CaseDTO();
        }

        public double GetProductRating(Guid productId)
        {
            var product = unitOfWork.CaseRepository.Get(productId);
            if (product != null)
            {
                List<Review> resultList = unitOfWork.ReviewRepository.Find(n => n.ProductProductId == productId).ToList();
                return resultList.Average(n => n.Rating);
            }
            else
                return 0;
        }

        public IEnumerable<CaseDTO> GetProductsByBrand(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                List<Case> products = unitOfWork.CaseRepository.Find(n => n.Trademark.Name == modelName).ToList();
                if (products.Count != 0)
                {
                    return mapper.Map<List<Case>, IList<CaseDTO>>(products);
                }
                else
                    return new List<CaseDTO>();
            }
            else
                return new List<CaseDTO>();
        }

        public int GetReviewsNumber(Guid productId)
        {
            var products = unitOfWork.CaseRepository.Get(productId);
            if (products != null)
            {
                int count = unitOfWork.ReviewRepository.GetAll().Count(n => n.ProductProductId == productId);
                return count;
            }
            else
                return 0;
        }
    }
}
