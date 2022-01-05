using System;
using System.Drawing;

namespace BL.DTO
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public Guid TrademarkTrademarkId { get; set; }
    }
}
