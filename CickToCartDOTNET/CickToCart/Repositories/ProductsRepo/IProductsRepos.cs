using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.Models;
namespace CickToCart.Repositories.ProductsRepo
{
   public interface IProductsRepos:IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProdByCat(int id);
        IEnumerable<Product> GetFirst5ProdByCat(int id);

    }
}
