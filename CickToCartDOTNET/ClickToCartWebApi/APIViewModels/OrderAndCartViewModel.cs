using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickToCartWebApi.APIViewModels
{
    public class OrderAndCartViewModel
    {
        //Orders
        public int UserID { get; set; }
        public float TotalPrice { get; set; }
        public int? PaymentID { get; set; }
        public bool OrderStatus { get; set; }
        public int? shippingID { get; set; }

        //Order Details
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int orderID { get; set; }
    }
}
