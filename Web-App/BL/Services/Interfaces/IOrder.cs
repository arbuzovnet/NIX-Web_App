using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IOrder
    {
        void NewOrder(Guid clientId, string notes);                 // Создание нового заказа
        void OrderCancellation(Guid orderId);                       // Отмена заказа
        IEnumerable<OrderDTO> GetAllOrder(Guid clientId);           // Получить заказы клиента
    }
}
