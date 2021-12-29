using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class OrderStatusRepo : Repository<OrderStatus>, IOrderStatusRepo
    {
        ContextDataBase _context;

        public OrderStatusRepo(ContextDataBase contextData) : base(contextData)
        {
            _context = contextData;

        }

        public IEnumerable<OrderStatus> GetAll()
        {
            var result = _context.OrdersStatuses.Include(s => s.Status).Include(o=>o.Order);
            return result;
        }
    }
}
