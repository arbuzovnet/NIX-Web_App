using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Models
{
    public class Charger:Product
    {
        public string Type { get; set; }
        public string Cable { get; set; }
        public string Connector { get; set; }   // Разъём: usb, type-c
        public bool FastCharging { get; set; }  // Поддержка быстрой зарядки
    }
}
