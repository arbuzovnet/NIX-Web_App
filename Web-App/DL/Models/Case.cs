using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
    [Table("Cases")]
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
