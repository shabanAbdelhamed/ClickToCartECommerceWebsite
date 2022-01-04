using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.ProductsRepo
{
    public interface IProduct_colorRepos : IRepository<Product_color>
    {
        IEnumerable<Product_color> GetProductColor();
    }

}
