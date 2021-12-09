using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class ShoppingCart
    {
        [Key]
        public int UserId { get; set; }
        [Range(1, 30)]
        public int Count { get; set; }                  // Количество товара в корзине

        public List<Product> Products { get; set; }

        public Client Client { get; set; }
    }
}
