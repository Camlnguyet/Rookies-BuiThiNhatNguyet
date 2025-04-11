using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationUser : ConfigurationEntity<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.UserName).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.Password).IsRequired(true).HasMaxLength(30);
        builder.Property(e => e.FirstName).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired(true).HasMaxLength(30);
        builder.Property(e => e.Email).IsRequired(true).HasMaxLength(255).HasColumnType("varchar(255)");
        builder.Property(e => e.PhoneNumber).IsRequired(true).HasMaxLength(10);
        builder.Property(e => e.Role).IsRequired(true).HasMaxLength(40);

        builder.HasIndex(e => e.UserName).IsUnique(true);
        builder.HasIndex(e => e.PhoneNumber).IsUnique(true);

        builder.HasMany(e => e.Addresses).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Orders).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Reviews).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Carts).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);
    }
}
