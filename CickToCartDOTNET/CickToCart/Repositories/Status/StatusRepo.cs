using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class StatusRepo : Repository<Status>, IStatusRepo
    {
        public StatusRepo(ContextDataBase contextData) : base(contextData)
        {
        }
    }
}
