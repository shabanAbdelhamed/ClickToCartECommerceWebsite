
using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class ShippingRepo : Repository<Shipping>, IShippingRepo
    {
        public ShippingRepo(ContextDataBase context) : base(context)
        {
        }


    }
}
