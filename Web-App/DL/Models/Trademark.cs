using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class Trademark                      // Торговая марка
    {
        [Required]
        public Guid TrademarkId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public string Mail { get; set; }

        public List<Product> Products { get; set; }
    }
}
