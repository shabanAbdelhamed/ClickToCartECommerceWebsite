using CickToCart.Models;
using System;

namespace CickToCart.DTOS
{
    public class OrderStatusDTO
    {
        public int ID { get; set; }
        public int StatusID { get; set; }
        public int OrderID { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
