using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationOrder : ConfigurationEntity<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Quanity).IsRequired(true);
        builder.Property(e => e.Status).IsRequired(true).HasMaxLength(40);
        builder.Property(e => e.Price_At_Purchase).IsRequired(true);
        builder.Property(e => e.UserId).IsRequired(true);

        builder.HasOne(e => e.User).WithMany(u => u.Orders).HasForeignKey(cd => cd.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Payment).WithOne(u => u.Order).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.OrderDetails).WithOne(u => u.Order).OnDelete(DeleteBehavior.Cascade);
    }
}
