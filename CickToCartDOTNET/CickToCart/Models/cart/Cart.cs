using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public List<CartDetails> CartDetails { get; set; }
        public string UserID { get; set; }//reference
        public float TotalPrice { get; set; }


    }
}
