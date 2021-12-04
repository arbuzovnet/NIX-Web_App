using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Delivery  // Поставки
    {
        public int DeliveryId { get; set; }
        public Provider Provider { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfGoodsDelivered { get; set; } // Количество доставленных товаров
        public int QuantityInStock { get; set; }        // Количество на складе
    }
}
