﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Order
    {
        [Key]
        public int OrdersId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string Notes { get; set; }                       // Примечания
        [Required]
        public DateTime Date { get; set; }

        public List<Product> Products { get; set; }

        public int ClientClientId { get; set; }
        public Client Client { get; set; }
    }
}