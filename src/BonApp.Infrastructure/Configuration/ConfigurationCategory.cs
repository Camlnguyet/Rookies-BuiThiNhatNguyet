using System.Runtime.CompilerServices;
using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationCategory : ConfigurationEntity<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.CategoryName).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired(false).HasMaxLength(200);
        builder.HasMany(e => e.Products).WithOne(u => u.Category).OnDelete(DeleteBehavior.Cascade);
    }
}
