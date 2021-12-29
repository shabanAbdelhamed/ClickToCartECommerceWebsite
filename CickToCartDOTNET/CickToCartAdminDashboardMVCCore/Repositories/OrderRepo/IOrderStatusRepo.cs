﻿using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public interface IOrderStatusRepo : IRepository<OrderStatus>
    {
        IEnumerable<OrderStatus> GetAll();
    }
}
