using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationOrderDetail : ConfigurationEntity<OrderDetail>
{
    public override void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Quantity).IsRequired(true);
        builder.Property(e => e.Price_At_Purchase).IsRequired(true);
        builder.Property(e => e.OrderId).IsRequired(true);
        builder.Property(e => e.ProductId).IsRequired(true);

        builder.HasOne(e => e.Order).WithMany(u => u.OrderDetails).HasForeignKey(cd => cd.OrderId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Product).WithMany(u => u.OrderDetails).HasForeignKey(cd => cd.ProductId).OnDelete(DeleteBehavior.Cascade);

    }
}
