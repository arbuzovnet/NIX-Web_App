using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }
    }
}
