using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class CartDetailsViewModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int cartID { get; set; }
       // public ProductDto2 Product { get; set; }
    }
    public class CartDetailsViewModel2
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int cartID { get; set; }
        public ProductDto2 Product { get; set; }
    }
    public class ProductDto2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qunatity { get; set; }

        public int SubCategoryID { get; set; }
        public string ImgCoverURl { get; set; }
    }
}
