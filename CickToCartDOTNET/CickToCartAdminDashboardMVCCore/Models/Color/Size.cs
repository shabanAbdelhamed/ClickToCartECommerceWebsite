using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public List<Product_Size> Product_Sizes { get; set; }

    }
}
