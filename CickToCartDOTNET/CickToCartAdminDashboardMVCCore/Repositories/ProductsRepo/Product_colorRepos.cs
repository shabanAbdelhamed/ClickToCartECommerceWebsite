using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories.ProductsRepo
{
    public class Product_colorRepos:Repository<Product_color>,IProduct_colorRepos
    {
        ContextDataBase _context;
        public Product_colorRepos(ContextDataBase context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Product_color> GetProductColor()
        {
            return _context.Product_Colors.Include(s=>s.color);
        }
    }
}
