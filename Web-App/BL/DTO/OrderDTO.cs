using System;

namespace BL.DTO
{
    public class OrderDTO
    {
        public Guid OrdersId { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }                       
        public DateTime Date { get; set; }
        public Guid ClientClientId { get; set; }
    }
}
