using System;

namespace BL.DTO
{
    public class ShoppingCartDTO
    {
        public Guid ShoppingCartId { get; set; }
        public int Count { get; set; }                  
        public DateTime DateCreated { get; set; }
        public Guid ProductproductId { get; set; }
        public Guid ClientClientId { get; set; }
    }
}
