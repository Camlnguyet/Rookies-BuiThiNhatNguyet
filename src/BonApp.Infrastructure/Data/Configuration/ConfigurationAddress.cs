using BonApp.Domain.Entities;
using BonApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationAddress : ConfigurationEntity<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.City).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.District).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.Ward).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.Street).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.HouseNumber).IsRequired(false).HasMaxLength(50);

        builder.Property(e => e.UserId).IsRequired(true);

        builder.HasOne(e => e.User).WithMany(u => u.Addresses).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);

    }
}
