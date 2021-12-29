using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.DTOS
{
    public class ProductShowDto
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        
        public double Price { get; set; }

        public string Description { get; set; }

        public string ImgCoverURl { get; set; }
       
        public int SubCategoryID { get; set; }
        
        public int? DiscountID { get; set; }
        
        public int? TagId { get; set; }
    }
}
