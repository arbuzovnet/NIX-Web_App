using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Headphones:Product
    {
        public string Kind { get; set; }
        public string Connection { get; set; }
        public string Fastening { get; set; }   //Крепление
    }
}
