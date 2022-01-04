using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.cartDetails
{
    public class CartDetailsEntityCongfigration
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.productID).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.cartID).IsRequired();


        }
    }
}
