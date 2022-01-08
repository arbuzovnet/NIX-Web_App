using System;
using DL.EF;
using DL.Models;
using DL.Repositories;
using Microsoft.Extensions.Logging;

namespace DL.UOW
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext applicationContext;
        private readonly ILogger logger;

        private ProductRepository productRepository;
        private Repository<Smartphone> smartphoneRepository;
        private Repository<Case> caseRepository;
        private Repository<Charger> chargerRepository;
        private Repository<Headphones> headphonesRepository;
        private ReviewRepository reviewRepository;
        private Repository<Client> clientRepository;
        private Repository<Trademark> trademarkRepository;
        private Repository<Delivery> deliveryRepository;
        private Repository<Provider> providerRepository;
        private Repository<Order> orderRepository;
        private Repository<ShoppingCart> cartRepository;

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

        public Repository<Smartphone> SmartphoneRepository
        {
            get
            {
                if (this.smartphoneRepository == null)
                {
                    this.smartphoneRepository = new Repository<Smartphone>(applicationContext, logger);
                }
                return smartphoneRepository;
            }
        }

        public Repository<Case> CaseRepository 
        {
            get
            {
                if (this.caseRepository == null)
                {
                    this.caseRepository = new Repository<Case>(applicationContext, logger);
                }
                return caseRepository;
            }
        }

        public Repository<Charger> ChargerRepository
        {
            get
            {
                if (this.chargerRepository == null)
                {
                    this.chargerRepository = new Repository<Charger>(applicationContext, logger);
                }
                return chargerRepository;
            }
        }

        public Repository<Headphones> HeadphonesRepository
        {
            get
            {
                if (this.headphonesRepository == null)
                {
                    this.headphonesRepository = new Repository<Headphones>(applicationContext, logger);
                }
                return headphonesRepository;
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

        public Repository<ShoppingCart> CartRepository
        {
            get
            {
                if (this.cartRepository == null)
                {
                    this.cartRepository = new Repository<ShoppingCart>(applicationContext, logger);
                }
                return cartRepository;
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
