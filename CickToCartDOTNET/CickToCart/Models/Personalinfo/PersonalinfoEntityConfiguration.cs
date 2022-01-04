using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models
{
    public class PersonalinfoEntityConfiguration : IEntityTypeConfiguration<Personalinfo>
    {
        public void Configure(EntityTypeBuilder<Personalinfo> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Address1).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(20);
            builder.Property(p => p.City).IsRequired().HasMaxLength(20);
        }
    }
}
