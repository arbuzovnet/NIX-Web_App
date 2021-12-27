﻿using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Case:Product
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Type { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Color { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Material { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string CompatibilityByModel { get; set; }    // Совместимость по модели
    }
}   
