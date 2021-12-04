using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }       // Примечания
        public DateTime Date { get; set; }
    }
}
