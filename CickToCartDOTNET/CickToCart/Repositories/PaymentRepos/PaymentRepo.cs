using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class PaymentRepo :Repository<Payment>, IPaymentRepo
    {
        private ContextDataBase _context;
        public PaymentRepo(ContextDataBase context) : base(context)
    {
            _context = context;
        }

        //public IEnumerable<Payment> GetAll()
        //{
        //    // return _context.Products.Include(s => s.SubCategory).Include(s => s.Tag).Include(s => s.Discount).Include(s => s.Product_Colors).ThenInclude(cs => cs.Product_Sizes);
        //    //return _context.P //.Include(s => s.SubCategory).Include(s => s.Tag).Include(s => s.Discount).Include(s => s.Product_Colors).ThenInclude(cs => cs.Product_Sizes);

        //}
    }
}
