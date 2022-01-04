using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.orderdetails
{
    public class OrderDetailsConfigration
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.CreatedAT).IsRequired();

            builder.Property(t => t.ModifiedAT).IsRequired();

        }
    }
}
