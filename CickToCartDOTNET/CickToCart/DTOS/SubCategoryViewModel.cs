using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class SubCategoryViewModel
    {

        public int ID { get; set; }
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }
        public int? DiscountID { get; set; }
        [Required(ErrorMessage ="Category Required")]
        [Display(Name ="Category")]
        public int CategoryID { get; set; }
    }
}
