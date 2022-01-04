using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string payment_type { get; set; }
        public string provider { get; set; }
        public DateTime expiry { get; set; }
        public List<Order> orders { get; set; }
    }
}
