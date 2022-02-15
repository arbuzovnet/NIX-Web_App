using AutoMapper;
using BL.AutoMapper;
using BL.DTO;
using BL.Services.Implementations;
using DL.EF;
using DL.Models;
using DL.UOW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

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

            UnitOfWork unit = new UnitOfWork(applicationContext, logger);



            List<Trademark> trademarks = new List<Trademark>
            {
                new Trademark(){TrademarkId = Guid.NewGuid(), Name = "Xiaomi", Mail = "xiaomi@kk.com" },
                new Trademark(){TrademarkId = Guid.NewGuid(), Name = "Samsung", Mail = "samsung@kk.com" }
            };
            List<Smartphone> smartphones = new List<Smartphone>
            {
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "9T", Price = 100, Description = "It's Xiaomi smartphone", TrademarkTrademarkId = trademarks[0].TrademarkId, BuiltMemory = 64, RAM = 4, OS = "Android", Matrix = "IPS", Resolution = "100x100"},
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "Redmi Note", Price = 150, Description = "It's Xiaomi smartphone", TrademarkTrademarkId = trademarks[0].TrademarkId, BuiltMemory = 128, RAM = 8, OS = "Android", Matrix = "Amouled", Resolution = "1920x1080"},
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "Sams 9P", Price = 300, Description = "It's Samsung smartphone", TrademarkTrademarkId = trademarks[1].TrademarkId, BuiltMemory = 512, RAM = 16, OS = "Android", Matrix = "Amouled", Resolution = "1920x1080"},
                new Smartphone(){ProductId = Guid.NewGuid(), Name = "Sams low", Price = 70, Description = "It's Samsung smartphone", TrademarkTrademarkId = trademarks[1].TrademarkId, BuiltMemory = 32, RAM = 2, OS = "Android", Matrix = "TFT", Resolution = "50x50"}
            };
            //List<Case> cases = new List<Case>
            //{
            //    new Case(){ProductId = Guid.NewGuid(), Name = "9T", Price = 100, Description = "It's Xiaomi case", TrademarkTrademarkId = trademarks[0].TrademarkId, Color = "red", Material = "Plastik", Type = "ForTelephone", CompatibilityByModel = "Xiaomi" }
            //};

            unit.TrademarkRepository.AddRange(trademarks);
            unit.Save();

            var tradeList = applicationContext.Trademarks.ToList();
            Console.WriteLine("Список Trademarks:");
            foreach (Trademark u in tradeList)
            {
                Console.WriteLine($"{u.TrademarkId}.{u.Name} - {u.Mail}");
            }
            Console.WriteLine("\n\n");

            //SmartphoneService smartService = new(applicationContext, logger, mapper);
            ////ProductService productService = new(applicationContext, logger, mapper);

            ////IEnumerable<ProductDTO> res = productService.GetAllProducts();

            ////Console.WriteLine("Список Products:");
            ////foreach (ProductDTO u in res)
            ////{
            ////    Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId}");
            ////}

            SmartphoneService service = new(applicationContext, logger, mapper);
            unit.ProductRepository.AddRange(smartphones);
            unit.Save();

            IEnumerable<SmartphoneDTO> result = service.GetAllProducts();
            Console.WriteLine("Список Smart:");
            foreach (SmartphoneDTO u in result)
            {
                Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.BuiltMemory} - {u.Matrix} - {u.OS} - {u.RAM} - {u.Resolution}");
            }
            Console.WriteLine("\n\n");

            Client client = new Client { ClientId = Guid.NewGuid(), FullName = "TestName", Birthday = DateTime.Now };

            ClientService clientService = new(applicationContext, logger, mapper);
            unit.ClientRepository.Add(client);
            unit.Save();

            ClientDTO resultClient = clientService.GetClientProfile(client.ClientId);
            Console.WriteLine($"Список клиентов:\n" +
                              $"{resultClient.ClientId} - {resultClient.FullName} - {resultClient.Birthday}");
            Console.WriteLine("\n\n");

            List<Product> list1 = new List<Product>
            {
                smartphones[0],
                smartphones[0],
                smartphones[0]
            };
            List<Product> list2 = new List<Product>
            {
                smartphones[1],
                smartphones[1],
                smartphones[1]
            };

            List<Order> orders = new List<Order>
            {
                new Order(){ OrderId = Guid.NewGuid(), Date = DateTime.Now, Notes = "TestNotes", Price = 0, Client = client, ClientClientId = client.ClientId, Products = list1},
                new Order(){ OrderId = Guid.NewGuid(), Date = DateTime.Now, Notes = "TestNotes", Price = 0, Client = client, ClientClientId = client.ClientId, Products = list2}
            };

            OrderService orderService = new(applicationContext, logger, mapper);
            unit.OrderRepository.AddRange(orders);
            unit.Save();

            IEnumerable<OrderDTO> resultOrder = orderService.GetAllOrder(client.ClientId);
            Console.WriteLine("Список Заказов:");
            foreach (OrderDTO u in resultOrder)
            {
                Console.WriteLine($"{u.ClientClientId} - {u.Date} - {u.Notes}");
            }
            Console.WriteLine("\n\n");

            IEnumerable<SmartphoneDTO> resultPopular = service.GetPopular();
            Console.WriteLine("Список PopularSmart:");
            foreach (SmartphoneDTO u in resultPopular)
            {
                Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.BuiltMemory} - {u.Matrix} - {u.OS} - {u.RAM} - {u.Resolution}");
            }
            Console.WriteLine("\n\n");


            //result = service.GetCheapToExpensive();
            //Console.WriteLine("GetCheapToExpensive():");
            //foreach (SmartphoneDTO u in result)
            //{
            //    Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.BuiltMemory} - {u.Matrix} - {u.OS} - {u.RAM} - {u.Resolution}");
            //}
            //Console.WriteLine("\n\n");

            //result = service.GetExpensiveToCheap();
            //Console.WriteLine("GetExpensiveToCheap():");
            //foreach (SmartphoneDTO u in result)
            //{
            //    Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.BuiltMemory} - {u.Matrix} - {u.OS} - {u.RAM} - {u.Resolution}");
            //}
            //Console.WriteLine("\n\n");

            //CaseService serviceCase = new(applicationContext, logger, mapper);
            //unit.CaseRepository.AddRange(cases);
            //unit.Save();

            //IEnumerable<CaseDTO> resultcases = serviceCase.GetAllProducts();
            //Console.WriteLine("Список Case:");
            //foreach (CaseDTO u in resultcases)
            //{
            //    Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.Color} - {u.Material} - {u.Type}");
            //}
            //Console.WriteLine("\n\n");


            //resultcases = serviceCase.GetCaseByColor("red");
            //Console.WriteLine("Список GetCaseByColor('red'):");
            //foreach (CaseDTO u in resultcases)
            //{
            //    Console.WriteLine($"{u.ProductId} - {u.Name} - {u.Price} - {u.Description} - {u.TrademarkTrademarkId} - {u.Color} - {u.Material} - {u.Type}");
            //}
            //Console.WriteLine("\n\n");

            //Console.WriteLine("End work");
            //Console.ReadKey();
        }
    }
}
