
using CickToCart.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }//refrence 
        public float TotalPrice { get; set; }
        public Payment Payment { get; set; }
    
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAT { get; set; }
        public bool OrderStatus { get; set; }

        public Shipping shipping { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public  AppUser  User { get; set; }

        [ForeignKey("Shipping")]
        public int shippingID { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }


    }
}
