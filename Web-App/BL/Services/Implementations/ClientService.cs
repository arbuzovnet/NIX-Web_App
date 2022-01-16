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

        public void EditPersonalData(Guid clientId, string name, DateTime dateTime, string gender)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                Client client = unitOfWork.ClientRepository.Get(clientId);
                client.FullName = name;
                client.Birthday = dateTime;
                client.Gender = gender;
                unitOfWork.ClientRepository.Update(client);
                unitOfWork.Save();
            }
        }

        public void EditDeliveryAddress(Guid clientId, string address)
        {
            if (!String.IsNullOrWhiteSpace(address))
            {
                Client client = unitOfWork.ClientRepository.Get(clientId);
                client.DeliveryAddress = address;
                unitOfWork.ClientRepository.Update(client);
                unitOfWork.Save();
            }
        }

        public void ChangeContacts(Guid clientId, string phone, string mail)
        {
            if (!String.IsNullOrWhiteSpace(phone) && !String.IsNullOrWhiteSpace(mail))
            {
                Client client = unitOfWork.ClientRepository.Get(clientId);
                client.Phone = phone;
                client.Mail = mail;
                unitOfWork.ClientRepository.Update(client);
                unitOfWork.Save();
            }
        }

        public IEnumerable<ReviewDTO> GetClientReview(Guid clientId)
        {
            Client temp = unitOfWork.ClientRepository.Find(n => n.ClientId == clientId).FirstOrDefault();
            if (temp != null)
                return mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(unitOfWork.ReviewRepository.Find(n => n.ClientClientId == clientId));
            else
                return new List<ReviewDTO>();
        }
    }
}
