using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public List<Order> Orders { get; set; }

        public List<Review> Reviews { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
