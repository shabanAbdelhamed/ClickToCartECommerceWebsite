using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class ElectronicCards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int numberCard { get; set; }
        public int CVV { get; set; }
        public int payment_id { get; set; }
        public int expier { get; set; }
    }
}
