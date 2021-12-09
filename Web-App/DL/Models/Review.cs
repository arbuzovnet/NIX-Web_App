﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        [StringLength(200)]
        public string ReviewText { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public int ProductProductId { get; set; }
        public Product Product { get; set; }

        public int ClientClientId { get; set; }
        public Client Client { get; set; }
    }
}