using CickToCart.DTOS;
using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
   public interface ICategoryRepo:IRepository<Category>
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Product> GetAllProdByCat(int id);
        IEnumerable<Product> GetFirst5ProdByCat(int id);
        IEnumerable<Product> GetAllProdByCat(List<CategoryListIds> CategoryListIds);
    }
}
