using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class Product_RatingRepos:Repository<Product_Rating>,IProduct_RatingRepos
    {
        private ContextDataBase _context;

        public Product_RatingRepos(ContextDataBase context):base(context)
        {
            _context = context;



        }
        public IEnumerable<Product_Rating> GetRateByProdId(int id)
        {
            var res = _context.Product_Ratings.Include(u=>u.User).Include(s => s.product).Where(s => s.product.ID == id).ToList();
            return res;
        }
        public IEnumerable<Product_Rating> GetAll()
        {
            var res = _context.Product_Ratings.Include(s => s.product).Include(s => s.User);
            return res;
        }
    }
}
