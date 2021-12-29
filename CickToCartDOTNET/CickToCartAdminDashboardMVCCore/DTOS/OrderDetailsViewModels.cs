using CickToCart.Models;

namespace CickToCart.DTOS
{
    public class OrderDetailsViewModels
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int orderID { get; set; }
        public ProductDto Product { get; set; }


    }
}
