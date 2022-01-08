using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
    [Table("Headphones")]
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
