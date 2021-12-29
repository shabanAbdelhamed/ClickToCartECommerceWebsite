using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class Product_colorDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Color Required")]
        [Display(Name ="Color")]
        public int colorID { get; set; }
        [Required(ErrorMessage = "Image Required")]
        
        public IFormFile Img { get; set; }
        public int ProductID { get; set; }
    }
}
