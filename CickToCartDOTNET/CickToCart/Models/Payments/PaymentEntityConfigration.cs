using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CickToCart.Models.Payments
{
    public class PaymentEntityConfigration
    {
       
            public void Configure(EntityTypeBuilder<Payment> builder)
            {
                builder.ToTable("Payment");
                builder.HasKey(t => t.Id);
                builder.Property(t => t.expiry).IsRequired();
                builder.Property(t => t.payment_type).IsRequired();
                builder.Property(t => t.provider).IsRequired();
                

            }
        
    }
}
