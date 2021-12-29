using CickToCart.DTOS;
using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickToCartWebApi.APIViewModels
{
    public class CartUserViewModel
    {
        public string UserID { get; set; }
       public IEnumerable<CartDetailsViewModel> CartDetailsItems { get; set; }
    }
}
