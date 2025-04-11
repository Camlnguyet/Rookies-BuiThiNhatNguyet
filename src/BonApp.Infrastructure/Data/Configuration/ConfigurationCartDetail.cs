using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationCartDetail : ConfigurationEntity<CartDetail>
{
    public override void Configure(EntityTypeBuilder<CartDetail> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Quantity).IsRequired(true);
        builder.Property(e => e.CartId).IsRequired(true);
        builder.Property(e => e.ProductId).IsRequired(true);

        builder.HasOne(e => e.Product).WithMany(u => u.CartDetails).HasForeignKey(cd => cd.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Cart).WithMany(u => u.CartDetails).HasForeignKey(cd => cd.CartId).OnDelete(DeleteBehavior.Cascade);
    }
}
