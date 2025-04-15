using BonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace BonApp.Infrastructure.Configuration;

public abstract class ConfigurationEntity<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // đặt khóa chính
        builder.HasKey(e => e.Id);
        // 
        // builder.Property(c => c.Id);
        //   .ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UpdatedAt)
            // .HasDefaultValueSql("CURRENT_TIMESTAMP")
            // .ValueGeneratedOnUpdate()
            .IsRequired(true);
    }
}
