using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
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
