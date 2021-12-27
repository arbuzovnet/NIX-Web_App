using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Drawing;

namespace DL.Models
{
    public class Product
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Image Image { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public Guid TrademarkTrademarkId { get; set; }
        public Trademark Trademark { get; set; }

        public List<Review> Reviews { get; set; }   

        public List<Delivery> Deliveries { get; set; }

        public List<Order> Orders { get; set; }

        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
