using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public interface IOrderRepo : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersbyUserId(string userId);
        int GetIdOfLastRow();
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
