using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationPayment : ConfigurationEntity<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Amount).IsRequired(true);
        builder.Property(e => e.PaymentMethod).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Status).IsRequired(true).HasMaxLength(50);

        builder.HasOne(e => e.Order).WithOne(u => u.Payment).OnDelete(DeleteBehavior.Cascade);
    }
}
