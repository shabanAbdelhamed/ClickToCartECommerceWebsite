
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Number { get; set; }
        
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Cagtgories { get; set; }

    }
}
