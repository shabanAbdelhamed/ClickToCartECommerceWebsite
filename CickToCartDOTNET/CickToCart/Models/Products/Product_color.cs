using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Product_color
    {
        public int ID { get; set; }
        [Required]
        public int colorID { get; set; }
        [Required]
        public int productID { get; set; }
        [ForeignKey("colorID")]
        public Color color { get; set; }
        [ForeignKey("productID")]
        public Product product { get; set; }
        public string img { get; set; }
        public List<Product_Size> Product_Sizes { get; set; }
    }
}
