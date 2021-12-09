using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class Trademark                      // Торговая марка
    {
        [Key]
        public int TrademarkId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public List<Product> Products { get; set; }
    }
}
