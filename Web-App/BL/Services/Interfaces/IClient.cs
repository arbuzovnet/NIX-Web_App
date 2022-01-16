using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    interface IClient
    {
        IEnumerable<OrderDTO> GetOrders(Guid clientId);                                         // Получить список всех заказов
        ClientDTO GetClientProfile(Guid clientId);                                              // Просмотреть профиль
        IEnumerable<ProductDTO> ViewedProducts();                                               // Просмотренные товары
        void EditPersonalData(Guid clientId, string name, DateTime dateTime, string gender);    // Изменить персональные данные
        void EditDeliveryAddress(Guid clientId, string address);                                // Изменить адрес доставки
        void ChangeContacts(Guid clientId, string phone, string mail);                          // Изменить номер телефона, почту
        IEnumerable<ReviewDTO> GetClientReview(Guid clientId);                                  // Получить все отзывы пользователя
    }
}
