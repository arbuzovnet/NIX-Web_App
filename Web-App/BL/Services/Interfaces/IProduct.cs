using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;

namespace BL.Services.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetCheapToExpensive();                 // Сортировка от дешевых к дорогим продуктам
        IEnumerable<Product> GetExpensiveToCheap();                 // Сортировка от дорогих к дешевым продуктам
        IEnumerable<Product> GetByReview();                         // Сортировка по количеству отзывов
        IEnumerable<Product> GetPopular();                          // Сортировка по популярности (проверять на наличие в заказах)
        double GetProductRating(int productId);                     // Средний рейтинг продукта
        double GetReviewsNumber(int productId);                     // Получить количество отзывов продукта
        Product GetProduct(int productId);                          // Получить информацию о конкретном продукте
        IEnumerable<Product> GetAllProducts();                      // Получить все продукты
        Product FindByName(string productName);                     // Поиск по названию продукта
        IEnumerable<Product> GetProductsByBrand(string modelName);  // Получить продукт по марке производителя
    }
}