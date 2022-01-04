using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.shipping
{
    public class ShippingEntityConfigration
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.ToTable("Shipping");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.OrderID).IsRequired();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Phone).IsRequired();
            builder.Property(t => t.ImgUrl).IsRequired();
            builder.Property(t => t.Location).IsRequired();
            builder.Property(t => t.Information).IsRequired();

        }
    }
}
