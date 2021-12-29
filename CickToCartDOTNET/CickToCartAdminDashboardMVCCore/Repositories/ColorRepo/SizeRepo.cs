using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class SizeRepo : Repository<Size>, ISizeRepo
    {
        public SizeRepo(ContextDataBase contextData) : base(contextData)
        {
        }
    }
}
