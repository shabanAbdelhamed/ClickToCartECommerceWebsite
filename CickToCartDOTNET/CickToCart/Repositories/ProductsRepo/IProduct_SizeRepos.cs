using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.ProductsRepo
{
    public interface IProduct_SizeRepos:IRepository<Product_Size>
    {
        IEnumerable<Product_Size> GetProductSize();
    }
}
