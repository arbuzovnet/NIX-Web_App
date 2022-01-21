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
using System.Text;

namespace BL.Services.Implementations
{
    public class ShoppingCartService : IShoppingCart
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public ShoppingCartService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public void AddToCart(Guid clientId, Guid productId)
        {
            var cartItem = unitOfWork.CartRepository.GetAll().SingleOrDefault(
                c=>c.ClientClientId == clientId &&
                c.ProductproductId == productId
            );
            if(cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    ShoppingCartId = Guid.NewGuid(),
                    Count = 1,
                    DateCreated = DateTime.Now,
                    ProductproductId = productId,
                    Product = unitOfWork.ProductRepository.Get(productId),
                    ClientClientId = clientId,
                    Client = unitOfWork.ClientRepository.Get(clientId)
                };
                unitOfWork.CartRepository.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            unitOfWork.Save();
        }

        public void RemoveFromCart(Guid clientId, Guid productId)
        {
            var cartItem = unitOfWork.CartRepository.GetAll().SingleOrDefault(
                c => c.ClientClientId == clientId &&
                c.ProductproductId == productId
            );
            if (cartItem.Count == 1)
                unitOfWork.CartRepository.Remove(cartItem);
            else
            {
                cartItem.Count--;
                unitOfWork.CartRepository.Update(cartItem);
            }
            unitOfWork.Save();
        }

        public IEnumerable<ShoppingCartDTO> GetAllItems(Guid clientId)
        {
            return mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartDTO>>
                (unitOfWork.CartRepository.Find(n => n.ClientClientId == clientId));
        }

        public decimal TotalValue(Guid clientId)
        {
            return unitOfWork.CartRepository.Find(n => n.ClientClientId == clientId).Sum(s => s.Product.Price);
        }
    }
}