using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public int TrademarkTrademarkId { get; set; }
        public Trademark Trademark { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Delivery> Deliveries { get; set; }

        public List<Order> Orders { get; set; }
    }
}
