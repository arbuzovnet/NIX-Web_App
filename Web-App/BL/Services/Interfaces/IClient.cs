using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    interface IClient
    {
        IEnumerable<OrderDTO> GetOrders();                     // Получить список всех заказов
        void AddItemToCart(ProductDTO product);                // Добавить продукт в корзину
        ClientDTO GetClientProfile(Guid clientId);             // Просмотреть профиль
        IEnumerable<ProductDTO> ViewedProducts();              // Просмотренные товары
    }
}
