using CickToCart.DTOS;
using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class CategoryRepo:Repository<Category>,ICategoryRepo
    {
        ContextDataBase _context;
        public CategoryRepo (ContextDataBase context) : base(context) {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            var result= _context.Categories;
            return result;
        }
        public IEnumerable<Product> GetAllProdByCat(int id)
        {
            var res = _context.Products.Include(s => s.SubCategory).ThenInclude(s => s.Category).Where(s => s.SubCategory.CategoryID == id).ToList();
            return res;
        }

        public IEnumerable<Product> GetAllProdByCat(List<CategoryListIds> CategoryListIds)
        {
            var produtList = new List<Product>(); // {4,5,6}
            foreach (var item in CategoryListIds)
            {
                var res = _context.Products
                   .Include(s => s.SubCategory).
                   ThenInclude(s => s.Category).Where(s => s.SubCategory.CategoryID == item.Id).ToList();
                //produtList = produtList + res;
                produtList.AddRange(res);
            }
            return produtList;
        }
        public IEnumerable<Product> GetFirst5ProdByCat(int id)
        {
            var res = _context.Products.Include(s => s.SubCategory).ThenInclude(s => s.Category).Where(s => s.SubCategory.CategoryID == id).Take(5).ToList();
            return res;
        }
    }
}
