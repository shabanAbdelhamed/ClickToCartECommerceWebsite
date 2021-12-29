using CickToCart.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Product_Rating
    {
        public int ID { get; set; }
        public AppUser? User { get; set; }
        public int Rate { get; set; }
        public string Comments { get; set; }
        public Product product { get; set; }

    }
}
