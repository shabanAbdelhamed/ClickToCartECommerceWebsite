using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class Product_SizeDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Size Required !")]
        [Display(Name ="Size")]
        public int sizeID { get; set; }
        [Required(ErrorMessage = "Quantity Required !")]
        [Display(Name ="Quantity")]
        
        public int QTE { get; set; }
        public int Product_ColorID { get; set; }
    }
}
