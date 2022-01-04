using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(d => d.ID);
            builder.Property(d => d.ID).ValueGeneratedOnAdd();
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Code).IsRequired();
        }
    }
}
