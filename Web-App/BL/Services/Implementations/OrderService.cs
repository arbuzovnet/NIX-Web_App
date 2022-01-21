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
    public class OrderService : IOrder
    {
        private protected UnitOfWork unitOfWork;
        private protected readonly IMapper mapper;

        public OrderService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAllOrder(Guid clientId)
        {
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>
                (unitOfWork.OrderRepository.Find(n => n.ClientClientId == clientId));
        }

        public void NewOrder(Guid clientId, string notes)
        {
            IEnumerable<ShoppingCart> cart = unitOfWork.CartRepository.Find(n => n.ClientClientId == clientId);

            List<Product> products = new List<Product>();
            foreach (var item in cart)
            {
                int onStock = unitOfWork.DeliveryRepository.Find(n => n.ProductProductId == item.ProductproductId).Count();
                if (item.Count == 1 && onStock >= 1)
                    products.Add(item.Product);
                else if (item.Count > 1 && onStock >= item.Count)
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        products.Add(item.Product);
                    }
                }
                else
                    return;
            }
            Order order = new Order
            {
                OrderId = Guid.NewGuid(),
                Price = unitOfWork.CartRepository.Find(n => n.ClientClientId == clientId)
                                                 .Sum(s => s.Product.Price),
                Notes = notes,
                Date = DateTime.Now,
                Products = products,
                ClientClientId = clientId,
                Client = unitOfWork.ClientRepository.Get(clientId)
            };
            unitOfWork.OrderRepository.Add(order);
            unitOfWork.Save();
        }

        public void OrderCancellation(Guid orderId)
        {
            unitOfWork.OrderRepository.RemoveById(orderId);
            unitOfWork.Save();
        }
    }
}
