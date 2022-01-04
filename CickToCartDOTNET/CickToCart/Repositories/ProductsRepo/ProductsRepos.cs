using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CickToCart.Models;
using Microsoft.EntityFrameworkCore;

namespace CickToCart.Repositories.ProductsRepo
{
    public class ProductsRepos:Repository<Product>, IProductsRepos
    {
        private ContextDataBase _context;
        public ProductsRepos(ContextDataBase context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(s => s.SubCategory);
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Include(s => s.SubCategory).FirstOrDefault(s => s.ID == id);
        }
        public IEnumerable<Product> GetAllProdByCat(int id)
        {
            var res = _context.Products.Include(s => s.SubCategory).ThenInclude(s => s.Category).Where(s => s.SubCategory.CategoryID==id).ToList();
            return res;
        }
        public IEnumerable<Product> GetFirst5ProdByCat(int id)
        {
            var res = _context.Products.Include(s => s.SubCategory).ThenInclude(s => s.Category).Where(s => s.SubCategory.CategoryID == id).Take(5).ToList();
            return res;
        }

    }
}
