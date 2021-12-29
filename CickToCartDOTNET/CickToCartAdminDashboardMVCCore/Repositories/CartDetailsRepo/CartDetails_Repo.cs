using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.CartDetailsRepo
{
    public class CartDetails_Repo : Repository<CartDetails>, ICartDetailsRepo
    {
        public CartDetails_Repo(ContextDataBase context) : base(context) { }
      
        public IEnumerable<CartDetails> GetAllProductsInCart(int Id)
        {
            return Context.Set<CartDetails>().Where(cartdetails => cartdetails.cartID == Id).Include(c=>c.Product).ToList();
        }

        public CartDetails GetByCartId(int iD)
        {
            throw new NotImplementedException();
        }

        public void RemoveOldCartDetails(int id)
        {
            var l= Context.Set<CartDetails>().Where(cartdetails => cartdetails.cartID == id).ToList();
            Context.Set<CartDetails>().RemoveRange(l);
           
        }
    }
}
