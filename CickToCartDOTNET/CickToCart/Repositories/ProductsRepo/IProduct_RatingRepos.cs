using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public interface IProduct_RatingRepos:IRepository<Product_Rating>
    {
        IEnumerable<Product_Rating> GetRateByProdId(int id);
        IEnumerable<Product_Rating> GetAll();
    }
}
