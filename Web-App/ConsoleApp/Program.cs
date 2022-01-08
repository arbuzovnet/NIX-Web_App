using AutoMapper;
using BL.AutoMapper;
using BL.DTO;
using BL.Services.Implementations;
using DL.EF;
using DL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext applicationContext = new();
            LoggerFactory logger = new();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();




            Trademark trademark = new Trademark()
            {
                TrademarkId = Guid.NewGuid(),
                Name = "Phone",
                Mail = "test@kk.com"
            };

            List<Product> products = new List<Product>
            {
                new Product(){ProductId = Guid.NewGuid(), Name = "Xiaomi", Price = 100, Description = "It's Xiaomi smartphone", TrademarkTrademarkId = trademark.TrademarkId},
                new Product(){ProductId = Guid.NewGuid(), Name = "Samsung", Price = 300, Description = "It's Samsung smartphone", TrademarkTrademarkId = trademark.TrademarkId},
                new Product(){ProductId = Guid.NewGuid(), Name = "Apple", Price = 70, Description = "It's Apple smartphone", TrademarkTrademarkId = trademark.TrademarkId},
                new Product(){ProductId = Guid.NewGuid(), Name = "Nokia", Price = 120, Description = "It's Nokia smartphone", TrademarkTrademarkId = trademark.TrademarkId},
                new Product(){ProductId = Guid.NewGuid(), Name = "LG", Price = 50, Description = "It's LG smartphone", TrademarkTrademarkId = trademark.TrademarkId}
            };
            List<Smartphone> smartphones = new List<Smartphone>
            {
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "Xiaomi", Price = 100, Description = "It's Xiaomi smartphone", TrademarkTrademarkId = trademark.TrademarkId, BuiltMemory = 64, RAM = 8, OS = "Android", Matrix = "IPS", Resolution = "1920x1080"},
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "Xiaomi", Price = 100, Description = "It's Xiaomi smartphone", TrademarkTrademarkId = trademark.TrademarkId, BuiltMemory = 64, RAM = 8, OS = "Android", Matrix = "IPS", Resolution = "1920x1080"}
            };

            //List<Product> products1 = new List<Product>
            //{
            //    smartphones[0]
            //};

            //Smartphone s = (Smartphone) products1[0];
            //Console.WriteLine($"{s.ProductId} - {s.Name} - {s.Price} - {s.Description} - {s.TrademarkTrademarkId} - {s.BuiltMemory} - {s.Matrix} - {s.OS} - {s.RAM} - {s.Resolution}");

            applicationContext.Trademarks.Add(trademark);
            applicationContext.SaveChanges();

            var tradeList = applicationContext.Trademarks.ToList();
            Console.WriteLine("Список Trade:");
            foreach (Trademark u in tradeList)
            {
                Console.WriteLine($"{u.TrademarkId}.{u.Name} - {u.Mail}");
            }

            applicationContext.Products.AddRange(smartphones);
            applicationContext.Products.AddRange(products);
            applicationContext.SaveChanges();

            SmartphoneService smartService = new(applicationContext, logger, mapper);
            ProductService productService = new(applicationContext, logger, mapper);

            IEnumerable<ProductDTO> res = productService.GetAllProducts();
            Console.WriteLine("Список Products:");
            foreach (ProductDTO u in res)
            {
                Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId}");
            }


            IEnumerable<SmartphoneDTO> result = smartService.GetSmartphoneByMatrixType("");
            Console.WriteLine("Список Smart:");
            foreach (SmartphoneDTO u in result)
            {
                Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.BuiltMemory} - {u.Matrix} - {u.OS} - {u.RAM} - {u.Resolution}");
            }

            Console.WriteLine("End work");
            Console.ReadKey();
        }
    }
}
