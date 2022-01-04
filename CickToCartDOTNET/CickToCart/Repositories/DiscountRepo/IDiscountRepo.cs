using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public interface IDiscountRepo:IRepository<Discount>
    {
        IEnumerable<Discount> GetAll();
    }
}
