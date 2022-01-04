using CickToCart.Models;
using CickToCart.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class OrderViewModels
    {
    public int ID { get; set; }
    public string UserID { get; set; }
    public float TotalPrice { get; set; }
    public int? PaymentID { get; set; }
    public bool OrderStatus { get; set; }
    public int? shippingID { get; set; }
        public Shipping Shipping { get; set; }

        public AppUser User { get; set; }
    }
}
