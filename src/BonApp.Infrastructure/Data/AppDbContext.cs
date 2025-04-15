using Microsoft.EntityFrameworkCore;
using BonApp.Domain.Entities;
using BonApp.Infrastructure.Configuration;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartsDetail { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Category>().HasIndex(c => c.CategoryName).IsUnique();
        // modelBuilder.ApplyConfiguration(new ConfigurationAddress());
        // modelBuilder.ApplyConfiguration(new ConfigurationCart());
        // modelBuilder.ApplyConfiguration(new ConfigurationCartDetail());
        // modelBuilder.ApplyConfiguration(new ConfigurationCategory());
        // modelBuilder.ApplyConfiguration(new ConfigurationOrderDetail());
        // modelBuilder.ApplyConfiguration(new ConfigurationOrder());
        // modelBuilder.ApplyConfiguration(new ConfigurationPayment());
        // modelBuilder.ApplyConfiguration(new ConfigurationProduct());
        // modelBuilder.ApplyConfiguration(new ConfigurationReview());
        // modelBuilder.ApplyConfiguration(new ConfigurationUser());
        // modelBuilder.Entity<Category>()
        //     .HasKey(c => c.Id);
    }

}
