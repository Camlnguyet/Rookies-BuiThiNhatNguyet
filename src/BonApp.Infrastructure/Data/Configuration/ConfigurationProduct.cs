using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationProduct : ConfigurationEntity<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.ProductName).IsRequired(true);
        builder.Property(e => e.ProductDescription).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.Price).IsRequired(true);
        builder.Property(e => e.Status).IsRequired(true);
        builder.Property(e => e.DateProduce).IsRequired(true);
        builder.Property(e => e.DateUse).IsRequired(true);
        builder.Property(e => e.CategoryId).IsRequired(true);

        builder.HasOne(e => e.Category).WithMany(u => u.Products).HasForeignKey(cd => cd.CategoryId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.OrderDetails).WithOne(u => u.Product).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Reviews).WithOne(u => u.Product).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.CartDetails).WithOne(u => u.Product).OnDelete(DeleteBehavior.Cascade);
    }
}
