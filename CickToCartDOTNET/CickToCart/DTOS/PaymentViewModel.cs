using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string payment_type { get; set; }
        public string provider { get; set; }
        public DateTime expiry { get; set; }
    }
}
