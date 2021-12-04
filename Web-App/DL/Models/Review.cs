using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
    }
}
