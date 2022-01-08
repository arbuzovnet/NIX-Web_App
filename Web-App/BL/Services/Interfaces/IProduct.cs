using BL.DTO;
using System;
using System.Collections.Generic;

namespace BL.Services.Interfaces
{
    public interface IProduct
    {
        IEnumerable<ProductDTO> GetCheapToExpensive();                  // Сортировка от дешевых к дорогим продуктам
        IEnumerable<ProductDTO> GetExpensiveToCheap();                  // Сортировка от дорогих к дешевым продуктам
        IEnumerable<ProductDTO> GetByReview();                          // Сортировка по количеству отзывов
        IEnumerable<ProductDTO> GetPopular();                           // Сортировка по популярности (проверять на наличие в заказах)
        double GetProductRating(Guid productId);                         // Средний рейтинг продукта
        int GetReviewsNumber(Guid productId);                            // Получить количество отзывов продукта
        ProductDTO GetProduct(Guid productId);                           // Получить информацию о конкретном продукте
        IEnumerable<ProductDTO> GetAllProducts();                       // Получить все продукты
        ProductDTO FindByName(string productName);                      // Поиск по названию продукта
        IEnumerable<ProductDTO> GetProductsByBrand(string modelName);   // Получить продукт по марке производителя
    }
}