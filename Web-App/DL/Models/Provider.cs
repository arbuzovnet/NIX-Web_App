using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DL.Models
{
    public class Provider                                           // Поставщик
    {
        [Key]
        public int ProviderId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Url]
        public string Site { get; set; }

        public List<Delivery> Deliveries { get; set; }
    }
}
