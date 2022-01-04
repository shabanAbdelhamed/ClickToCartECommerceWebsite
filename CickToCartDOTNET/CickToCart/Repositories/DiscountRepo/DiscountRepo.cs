using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class DiscountRepo:Repository<Discount>,IDiscountRepo
    {

        ContextDataBase Context;
        public DiscountRepo(ContextDataBase context) : base(context) {
            Context = context;
        }
        public IEnumerable<Discount> GetAll()
        {
            var result = Context.Discounts;
            return result;
        }


    }
}
