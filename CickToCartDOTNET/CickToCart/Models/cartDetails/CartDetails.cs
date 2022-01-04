using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CickToCart.Models
{
    public class CartDetails
    {
        public int ID { get; set; }
        [Required]
        public int productID { get; set; }
        [ForeignKey("productID")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int cartID { get; set; }
        [ForeignKey("cartID")]
        public Cart Cart { get; set; }
    }
}
