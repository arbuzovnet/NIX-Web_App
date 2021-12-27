using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class ShoppingCart
    {
        [Required]
        public Guid UserId { get; set; }
        [Range(1, 30)]
        public int Count { get; set; }                  // Количество товара в корзине

        public List<Product> Products { get; set; }

        public Guid ClientClientId { get; set; }
        public Client Client { get; set; }
    }
}
