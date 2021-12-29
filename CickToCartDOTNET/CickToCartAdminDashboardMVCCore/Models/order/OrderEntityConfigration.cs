using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.order
{
    public class OrderEntityConfigration
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.UserID).IsRequired();
            builder.Property(t => t.TotalPrice).IsRequired();
            builder.Property(t => t.CreatedAT).IsRequired();
            builder.Property(t => t.ModifiedAT).IsRequired();

        }
    }
}
