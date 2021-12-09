using System;
using System.ComponentModel.DataAnnotations;

namespace DL.Models
{
    public class Delivery                               // Поставки
    {
        [Key]
        public int DeliveryId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int NumberOfGoodsDelivered { get; set; } // Количество доставленных товаров
        [Required]
        public int QuantityInStock { get; set; }        // Количество на складе

        public int ProductProductId { get; set; }
        public Product Product { get; set; }

        public int ProviderProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
