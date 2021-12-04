using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Case:Product
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string CompatibilityByModel { get; set; }    // Совместимость по модели
    }
}
