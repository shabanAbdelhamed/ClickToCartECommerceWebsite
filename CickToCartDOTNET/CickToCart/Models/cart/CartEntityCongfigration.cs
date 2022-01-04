using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.cart
{
    public class CartEntityCongfigration
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.UserID).IsRequired();
            //builder.Property(t => t.Quantity).IsRequired();
            //builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.TotalPrice).IsRequired();

        }
    }
}
