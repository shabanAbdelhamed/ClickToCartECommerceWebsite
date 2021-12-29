using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class Product_RatingDto
    {
        public int ID { get; set; }
        public int Rate { get; set; }
        public string Comments { get; set; }
        public int productID { get; set; }
        public string UserId { get; set; }

    }
}
