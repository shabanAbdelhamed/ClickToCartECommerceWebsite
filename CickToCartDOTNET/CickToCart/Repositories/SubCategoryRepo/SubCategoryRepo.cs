using CickToCart.DTOS;
using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class SubCategoryRepo : Repository<SubCategory>, ISubCategoryRepo
    {
        ContextDataBase _context;
        public SubCategoryRepo(ContextDataBase context) : base(context) {
            _context = context;
        }
        public IEnumerable<SubCategory> GetAll() {
            return _context.SubCategories.Include(s=>s.Category).Include(s=>s.Discount);
        }
        public IEnumerable<Product> GetAllProdBySubCat(List<CategoryListIds> CategoryListIds)
        {
            var produtList = new List<Product>(); // {4,5,6}
            foreach (var item in CategoryListIds)
            {
                var res = _context.Products
                   .Include(s => s.SubCategory)
                   .Where(s => s.SubCategory.ID == item.Id).ToList();
                //produtList = produtList + res;
                produtList.AddRange(res);
            }
            return produtList;
        }

    }
}
