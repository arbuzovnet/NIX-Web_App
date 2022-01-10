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
    public class ClientService : IClient
    {
        private UnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientService(ApplicationContext applicationContext, ILoggerFactory loggerFactory, IMapper mapper)
        {
            unitOfWork = new(applicationContext, loggerFactory);
            this.mapper = mapper;
        }

        public void AddItemToCart(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetClientProfile(Guid clientId)
        {
            Client temp = unitOfWork.ClientRepository.Find(n => n.ClientId == clientId).FirstOrDefault();
            if (temp != null)
                return mapper.Map<Client, ClientDTO>(temp);
            else
                return new ClientDTO();
        }

        public IEnumerable<OrderDTO> GetOrders(Guid clientId)
        {
            Client temp = unitOfWork.ClientRepository.Find(n => n.ClientId == clientId).FirstOrDefault();
            if (temp != null)
                return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(unitOfWork.OrderRepository.Find(n => n.ClientClientId == clientId));
            else
                return new List<OrderDTO>();
        }

        public IEnumerable<ProductDTO> ViewedProducts()
        {
            throw new NotImplementedException();
        }
    }
}
