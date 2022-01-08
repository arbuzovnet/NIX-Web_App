using System;
using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Review
    {
        [Required]
        public Guid ReviewId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        [StringLength(200)]
        public string ReviewText { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Guid ProductProductId { get; set; }
        public Product Product { get; set; }

        public Guid ClientClientId { get; set; }
        public Client Client { get; set; }
    }
}
