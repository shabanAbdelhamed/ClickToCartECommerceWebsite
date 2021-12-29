
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public int? DiscountID { get; set; }
        public int CategoryID { get; set; }
        public bool IsDeleted { get; set; }
        public Discount Discount{ get; set; }
        public List<Product> Products { get; set; }
        public Category  Category { get; set; }

    }

}
