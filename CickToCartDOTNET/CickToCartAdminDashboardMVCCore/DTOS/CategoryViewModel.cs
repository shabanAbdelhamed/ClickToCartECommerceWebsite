using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Category Name Required")]
        public string Name { get; set; }
        [Display(Name = "Discount")]
        public int? DiscountID { get; set; }
    }
}
