using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.ProductsRepo
{
    public class Product_SizeRepos:Repository<Product_Size>,IProduct_SizeRepos
    {
        ContextDataBase _context;
        public Product_SizeRepos(ContextDataBase context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Product_Size> GetProductSize()
        {
            return _context.Product_Sizes.Include(s => s.size);
        }
    }
}
