using CickToCart.DTOS;
using System.Collections.Generic;

namespace ClickToCartWebApi
{
    public class CartUserViewModel2
    {
       
        public string UserID { get; set; }
        public List<CartDetailsViewModel2> CartDetailsItems { get; set; }
    }
}