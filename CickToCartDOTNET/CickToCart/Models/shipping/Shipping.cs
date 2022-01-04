using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Shipping
    {
        public int ID { get; set; }
        public List<Order> OrderID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Information { get; set; }

    }
}
