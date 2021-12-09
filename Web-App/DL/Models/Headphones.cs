using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Headphones:Product
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Kind { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Connection { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Fastening { get; set; }   //Крепление
    }
}
