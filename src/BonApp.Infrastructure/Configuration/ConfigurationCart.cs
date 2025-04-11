using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationCart : ConfigurationEntity<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.UserId).IsRequired(true);

        builder.HasOne(e => e.User).WithMany(u => u.Carts).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.CartDetails).WithOne(u => u.Cart)
        .HasForeignKey(cd => cd.CartId).OnDelete(DeleteBehavior.Cascade);
    }
}
