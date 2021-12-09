using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Smartphone:Product
    {
        [Required]
        public int BuiltMemory { get; set; }        // Встроенная память
        [Required]
        public int RAM { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Matrix { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Resolution { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string OS { get; set; }
    }
}
