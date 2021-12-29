using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.CartRepo
{
    public class Cart_Repo : Repository<Cart>, ICartRepo
    {
        public Cart_Repo(ContextDataBase context) : base(context) { }
     

        public Cart GetCartByUserID(string Id)
        {
            return Context.Set<Cart>().Where(cart => cart.UserID == Id).FirstOrDefault();
        }
    }
}
