using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public float TotalPrice { get; set; }

    }
}
