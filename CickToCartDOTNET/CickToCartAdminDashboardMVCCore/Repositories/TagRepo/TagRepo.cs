using CickToCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Repositories
{
    public class TagRepo:Repository<Tag>,ITagRepo
    {
        public TagRepo (ContextDataBase context) : base(context) { }
    }
}
