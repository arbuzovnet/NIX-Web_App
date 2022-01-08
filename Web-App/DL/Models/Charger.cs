using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
    [Table("Chargers")]
    public class Charger:Product
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Type { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Cable { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Connector { get; set; }   // Разъём: usb, type-c   enum?
        [Required]
        public bool FastCharging { get; set; }  // Поддержка быстрой зарядки
    }
}
