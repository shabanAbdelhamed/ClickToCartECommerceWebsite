using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class AppUserUpdate
    {
        [Required]
        public string Id { get; set; }
       
        public string FirstName { get; set; }
 
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
