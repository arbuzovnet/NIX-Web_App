using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace DL.Models
{
    public class Client
    {
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string DeliveryAddress { get; set; }
        public List<Order> Orders { get; set; }

        public List<Review> Reviews { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
