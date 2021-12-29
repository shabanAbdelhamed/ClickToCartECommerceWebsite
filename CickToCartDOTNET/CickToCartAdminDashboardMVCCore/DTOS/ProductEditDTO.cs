using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CickToCart.DTOS
{
    public class ProductEditDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Quantity Required")]
        public int Qunatity { get; set; }
        [Display(Name = "Category")]
        public int? CatID { get; set; }
        public string Description { get; set; }
        [Display(Name = "Cover Image")]
        public IFormFile Img { get; set; }
        [Required(ErrorMessage = "SubCategory Required")]
        [Display(Name = "SubCategory")]
        public int SubCategoryID { get; set; }
        [Display(Name = "Discount")]
        public int? DiscountID { get; set; }
        [Display(Name = "Tag")]
        public int? TagId { get; set; }
        public string ImgCoverURl { get; set; }
    }
}
