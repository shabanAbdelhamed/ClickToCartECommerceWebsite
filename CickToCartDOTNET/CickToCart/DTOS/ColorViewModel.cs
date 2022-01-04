using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class ColorViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Color Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Color Code Required")]
        public string Code { get; set; }
    }
}
