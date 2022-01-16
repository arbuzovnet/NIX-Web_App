using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IShoppingCart
    {
        void AddToCart(Guid clientId, Guid productId);                                 // Добавить в корзину
        void RemoveFromCart(Guid clientId, Guid productId);                            // Удалить товар с корзину
        IEnumerable<ShoppingCartDTO> GetAllItems(Guid clientId);        // Получить все товары с корзины
        decimal TotalValue(Guid clientId);                              // Суммарная стоимость корзины                                                
    }
}
