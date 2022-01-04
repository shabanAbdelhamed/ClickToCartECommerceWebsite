using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int ProductID { get; set; }        
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAT { get; set; }
        public int orderID { get; set; }
        [ForeignKey("orderID")]
        public Order order { get; set; }
        public Product product { get; set; }


    }
}
