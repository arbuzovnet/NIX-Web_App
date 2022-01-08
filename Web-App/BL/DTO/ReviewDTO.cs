using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime Date { get; set; }
        public int ProductProductId { get; set; }
        public int ClientClientId { get; set; }
    }
}
