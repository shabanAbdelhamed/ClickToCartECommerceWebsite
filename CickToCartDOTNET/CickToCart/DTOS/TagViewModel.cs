using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class TagViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Title Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Meta Title Required")]
        [Display(Name ="Meta Title")]
        public string Meta_title { get; set; }
        [Required(ErrorMessage = " Content Required")]
        [Display(Name = "Content")]
        public string content { get; set; }
    }
}
