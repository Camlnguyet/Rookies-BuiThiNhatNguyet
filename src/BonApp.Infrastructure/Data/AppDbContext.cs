using Microsoft.EntityFrameworkCore;
using BonApp.Domain.Entities;

namespace BonApp.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
}
