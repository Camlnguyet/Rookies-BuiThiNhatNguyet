using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonApp.Infrastructure.Configuration;

public class ConfigurationReview : ConfigurationEntity<Review>
{
    public override void Configure(EntityTypeBuilder<Review> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Rating).IsRequired(true);
        builder.Property(e => e.Comment).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UserId).IsRequired(true);
        builder.Property(e => e.ProductId).IsRequired(true);

        builder.HasOne(e => e.User).WithMany(u => u.Reviews).HasForeignKey(cd => cd.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Product).WithMany(u => u.Reviews).HasForeignKey(cd => cd.ProductId).OnDelete(DeleteBehavior.Cascade);
    }
}