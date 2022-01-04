using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? DiscountID { get; set; }
        public bool IsDeleted { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public Discount Discount { get; set; }

    }
}
