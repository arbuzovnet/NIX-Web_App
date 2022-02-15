using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ClientDTO
    {
        public Guid ClientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
