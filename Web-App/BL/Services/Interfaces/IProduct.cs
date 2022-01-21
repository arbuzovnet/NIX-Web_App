using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IProduct<T> where T : class
    {
        IEnumerable<T> GetCheapToExpensive();                  // Сортировка от дешевых к дорогим продуктам
        IEnumerable<T> GetExpensiveToCheap();                  // Сортировка от дорогих к дешевым продуктам
        IEnumerable<T> GetByReview();                          // Сортировка по количеству отзывов
        IEnumerable<T> GetPopular();                           // Сортировка по популярности (проверять на наличие в заказах)
        double GetProductRating(Guid productId);               // Средний рейтинг продукта
        int GetReviewsNumber(Guid productId);                  // Получить количество отзывов продукта
        T GetProduct(Guid productId);                          // Получить информацию о конкретном продукте
        IEnumerable<T> GetAllProducts();                       // Получить все продукты
        T FindByName(string productName);                      // Поиск по названию продукта
        IEnumerable<T> GetProductsByBrand(string modelName);   // Получить продукт по марке производителя
        bool ProductAvailability(Guid productId);              // Наличие продукта на складе
        int QuantityInStock(Guid productId);                   // Количество продукта на складе


        //IEnumerable<T> GetCheapToExpensive();                  // Сортировка от дешевых к дорогим продуктам
        //IEnumerable<T> GetExpensiveToCheap();                  // Сортировка от дорогих к дешевым продуктам
        //IEnumerable<T> GetByReview();                          // Сортировка по количеству отзывов
        //IEnumerable<T> GetPopular();                           // Сортировка по популярности (проверять на наличие в заказах)
        //double GetProductRating(Guid productId);                         // Средний рейтинг продукта
        //int GetReviewsNumber(Guid productId);                            // Получить количество отзывов продукта
        //T GetProduct(Guid productId);                           // Получить информацию о конкретном продукте
        //IEnumerable<T> GetAllProducts();                       // Получить все продукты
        //T FindByName(string productName);                      // Поиск по названию продукта
        //IEnumerable<T> GetProductsByBrand(string modelName);   // Получить продукт по марке производителя
    }
}