using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class OrderStatus
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public Order Order { get; set; }
        public DateTime StatusDate { get; set; }

    }
}
