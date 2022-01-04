using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class DiscountEntityConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount");
            builder.HasKey(d => d.ID);
            builder.Property(d => d.ID).ValueGeneratedOnAdd();
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Number).IsRequired();
        }
    }
}
