using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class ShoppingCart
    {
        [Required]
        public Guid ShoppingCartId { get; set; }
        [Range(1, 30)]
        public int Count { get; set; }                  // Количество товара в корзине
        public DateTime DateCreated { get; set; }

        public Guid ProductproductId { get; set; }
        public Product Product { get; set; }

        public Guid ClientClientId { get; set; }
        public Client Client { get; set; }

        //[Required]
        //public Guid ShoppingCartId { get; set; }
        //[Range(1, 30)]
        //public int Count { get; set; }                  

        //public List<Product> Products { get; set; }

        //public Guid ClientClientId { get; set; }
        //public Client Client { get; set; }
    }
}
