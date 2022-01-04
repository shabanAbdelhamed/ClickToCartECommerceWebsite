using CickToCart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        public OrderRepo(ContextDataBase context) : base(context) { }
        public IEnumerable<Order> GetOrdersbyUserId(string userId)
        {
            return Context.orders
                .Where(order => order.UserID == userId)
                .ToList();
        }

        public int GetIdOfLastRow() => Context.Set<Order>().OrderByDescending(o => o.ID).FirstOrDefault().ID;

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await Context
            .Set<Order>()
            .Include("User").Include(u=>u.shipping)
            .ToListAsync();

    }
}
