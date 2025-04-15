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
        // builder.HasKey(c => c.Id);
        // builder.Property(c => c.Id).IsRequired(true).ValueGeneratedOnAdd();

        builder.Property(e => e.CategoryName).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired(false).HasMaxLength(200);
        builder.Property(e => e.Status).IsRequired(true).HasMaxLength(50);
        builder.HasMany(e => e.Products).WithOne(u => u.Category).OnDelete(DeleteBehavior.Cascade);
    }
}
