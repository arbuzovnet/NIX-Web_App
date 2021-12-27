﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    interface IClient
    {
        IEnumerable<Order> GetOrders();                     // Получить список всех заказов
        void AddItemToCart(Product product);                // Добавить продукт в корзину
        Client GetClientProfile(Guid clientId);             // Просмотреть профиль
        IEnumerable<Product> ViewedProducts();              // Просмотренные товары
    }
}
