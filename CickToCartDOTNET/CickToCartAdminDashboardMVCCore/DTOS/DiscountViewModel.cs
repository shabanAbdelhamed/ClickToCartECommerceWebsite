using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class DiscountViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Discount Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Discount Number Required")]
        public double Number { get; set; }
        [Required(ErrorMessage = "Start Date Name Required")]
        [Display(Name = "Start Date")]
        public DateTime Start_Date { get; set; }
        [Required(ErrorMessage = "End Date Name Required")]
        [Display(Name = "End Date")]
        public DateTime End_Date { get; set; }
    }
}
