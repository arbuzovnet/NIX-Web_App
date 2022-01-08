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
    public class ProductService : IProduct
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public ProductService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public ProductDTO FindByName(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                //List<ProductDTO> productDTOs = unitOfWork.ProductRepository.Find(n => n.Name == productName).ToList();
                List<Product> products = unitOfWork.ProductRepository.Find(n => n.Name == productName).ToList();
                if(products.Count != 0)
                    return mapper.Map<Product, ProductDTO>(products[0]);
                    //return new ProductDTO()
                    //{
                    //    ProductId = products[0].ProductId,
                    //    Name = products[0].Name,
                    //    Price = products[0].Price,
                    //    Image = products[0].Image,
                    //    Description = products[0].Description,
                    //    TrademarkTrademarkId = products[0].TrademarkTrademarkId
                    //};
                else
                    return new ProductDTO();
            }
            else
                return new ProductDTO();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            //mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.ProductRepository.GetAll());

            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.ProductRepository.GetAll());
        }

        public IEnumerable<ProductDTO> GetByReview()
        {
            List<Product> products = unitOfWork.ProductRepository.GetAll().OrderBy(n => n.Reviews.Count).ToList();
            return mapper.Map<List<Product>, IList<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetCheapToExpensive()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.ProductRepository.GetAll().OrderBy(u => u.Price));
        }

        public IEnumerable<ProductDTO> GetExpensiveToCheap()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(unitOfWork.ProductRepository.GetAll().OrderByDescending(u => u.Price));
        }

        public IEnumerable<ProductDTO> GetPopular()
        {
            throw new System.NotImplementedException();
        }

        public ProductDTO GetProduct(Guid productId)
        {
            var product = unitOfWork.ProductRepository.Get(productId);
            if (product != null)
                return mapper.Map<Product, ProductDTO>(product);
            else
                return new ProductDTO();
        }

        public double GetProductRating(Guid productId)
        {
            var product = unitOfWork.ProductRepository.Get(productId);         
            if (product != null)
            {
                List<Review> resultList = unitOfWork.ReviewRepository.Find(n => n.ProductProductId == productId).ToList();
                return resultList.Average(n => n.Rating);
            }
            else
                return 0;
        }

        public IEnumerable<ProductDTO> GetProductsByBrand(string modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                List<Product> products = unitOfWork.ProductRepository.Find(n => n.Trademark.Name == modelName).ToList();
                if (products.Count != 0)
                {
                    //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
                    return mapper.Map<List<Product>, IList<ProductDTO>>(products);
                }
                else
                    return new List<ProductDTO>();
            }
            else
                return new List<ProductDTO>();
        }

        public int GetReviewsNumber(Guid productId)
        {
            var products = unitOfWork.ProductRepository.Get(productId);          
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
