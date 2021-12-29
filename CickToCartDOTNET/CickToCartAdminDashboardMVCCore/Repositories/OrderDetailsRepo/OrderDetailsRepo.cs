using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class OrderDetailsRepo : Repository<OrderDetails>,IOrderDetailsRepo
    {
        private ContextDataBase _context;
       
          
        public OrderDetailsRepo(ContextDataBase contextData) : base(contextData)
        {
            _context = contextData;
        }
        
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(s => s.SubCategory).Include(s => s.Tag).Include(s => s.Discount).Include(s => s.Product_Colors).ThenInclude(cs => cs.Product_Sizes);
        }
        public IEnumerable<OrderDetails> GetAllProductsFromOrder(int id)
        {
            var res= _context.orderdetails.Where(o => o.orderID == id).Include(o => o.product).ToList();
            return res;
        }

        //public IEnumerable<OrderDetails> GetAllProductsFromOrder(int id)
        //{
        //    return _context.orderdetails.Where(o => o.orderID == id).ToList();
        //}
    }
}
