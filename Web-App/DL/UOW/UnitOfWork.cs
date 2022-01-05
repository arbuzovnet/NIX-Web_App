using System;
using DL.EF;
using DL.Models;
using DL.Repositories;
using Microsoft.Extensions.Logging;

namespace DL.UOW
{
    class UnitOfWork : IDisposable
    {
        private ApplicationContext applicationContext;
        private readonly ILogger logger;

        private ProductRepository productRepository;
        private ReviewRepository reviewRepository;
        private Repository<Client> clientRepository;
        private Repository<Trademark> trademarkRepository;
        private Repository<Delivery> deliveryRepository;
        private Repository<Provider> providerRepository;
        private Repository<Order> orderRepository;

        public UnitOfWork(ApplicationContext applicationContext, ILoggerFactory loggerFactory)
        {
            this.applicationContext = applicationContext;
            logger = loggerFactory.CreateLogger("logs");
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(applicationContext, logger);
                }
                return productRepository;
            }
        }

        public ReviewRepository ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new ReviewRepository(applicationContext, logger);
                }
                return reviewRepository;
            }
        }

        public Repository<Client> ClientRepository
        {
            get
            {
                if (this.clientRepository == null)
                {
                    this.clientRepository = new Repository<Client>(applicationContext, logger);
                }
                return clientRepository;
            }
        }

        public Repository<Trademark> TrademarkRepository
        {
            get
            {
                if (this.trademarkRepository == null)
                {
                    this.trademarkRepository = new Repository<Trademark>(applicationContext, logger);
                }
                return trademarkRepository;
            }
        }

        public Repository<Delivery> DeliveryRepository
        {
            get
            {
                if (this.deliveryRepository == null)
                {
                    this.deliveryRepository = new Repository<Delivery>(applicationContext, logger);
                }
                return deliveryRepository;
            }
        }

        public Repository<Provider> ProviderRepository
        {
            get
            {
                if (this.providerRepository == null)
                {
                    this.providerRepository = new Repository<Provider>(applicationContext, logger);
                }
                return providerRepository;
            }
        }

        public Repository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new Repository<Order>(applicationContext, logger);
                }
                return orderRepository;
            }
        }

        public void Save()
        {
            applicationContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    applicationContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
