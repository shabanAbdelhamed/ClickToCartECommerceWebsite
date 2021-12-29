
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImgCoverURl { get; set; }
        public double Price { get; set; }
        public string Description  { get; set; }
        public int? Qunatity { get; set; } 
        public int? TagId { get; set; }
        public int SubCategoryID { get; set; }
        public int? DiscountID { get; set; }
        public List<Product_Rating> Product_Ratings { get; set; }
        public List<Product_color> Product_Colors { get; set; }
        public SubCategory SubCategory { get; set; }
        public Tag Tag { get; set; }
        public Discount Discount { get; set; }
        public List<CartDetails> CartDetails { get; set; }

    }
}
