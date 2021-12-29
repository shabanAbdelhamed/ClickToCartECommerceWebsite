using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class SizeViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Required")]
        public string Discription { get; set; }
    }
}
