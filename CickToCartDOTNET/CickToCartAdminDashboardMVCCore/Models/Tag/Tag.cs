using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Meta_title { get; set; }
        public string content { get; set; }
        public List<Product> product { get; set; }

    }
}
