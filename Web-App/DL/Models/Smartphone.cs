using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Smartphone:Product
    {
        public int BuiltMemory { get; set; }        // Встроенная память
        public int RAM { get; set; }
        public string Matrix { get; set; }
        public string Resolution { get; set; }
        public string OS { get; set; }
    }
}
