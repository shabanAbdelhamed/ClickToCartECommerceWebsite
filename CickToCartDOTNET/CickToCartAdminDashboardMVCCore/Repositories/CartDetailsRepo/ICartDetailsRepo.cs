using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.CartDetailsRepo
{
    public interface ICartDetailsRepo: IRepository<CartDetails>
    {
        IEnumerable<CartDetails> GetAllProductsInCart(int Id);
        void RemoveOldCartDetails(int id);
        CartDetails GetByCartId(int iD);
    }
}
