using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.CartRepo
{
    public  interface ICartRepo: IRepository<Cart>
    {
        Cart GetCartByUserID(string Id);
    }
}
