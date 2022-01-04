using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Product_color> Product_Colors { get; set; }

    }
}
