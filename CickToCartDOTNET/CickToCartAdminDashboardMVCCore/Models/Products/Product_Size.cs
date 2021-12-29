using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Product_Size
    {
        public int ID { get; set; }
        [Required]
        public int sizeID { get; set; }
        [Required]
        public int QTE { get; set; }
        [ForeignKey("sizeID")]
        public Size size { get; set; }
        [Required]
        public int Product_ColorID { get; set; }
        [ForeignKey("Product_ColorID")]
        public Product_color  Product_Color { get; set; }

    }
}
