using Microsoft.EntityFrameworkCore;
using WebShopSolution.DataAccess.Entities;
using WebShopSolution.DataAccess.Entities.Enums;

namespace WebShop;

public interface IWebShopDbContext
{
    DbSet<CustomerEntity> Customers { get; set; }
    DbSet<ProductEntity> Products { get; set; }
    DbSet<OrderEntity> Orders { get; set; }
    DbSet<OrderDetailEntity> OrderDetails { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Dispose();
    
}

public class WebShopDbContext(DbContextOptions<WebShopDbContext> options) : DbContext(options), IWebShopDbContext
{
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    public DbSet<OrderDetailEntity> OrderDetails { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProductEntity>().
            HasMany(p => p.OrderDetails).
            WithOne(od => od.Product);

        modelBuilder.Entity<OrderEntity>()
            .HasMany(o => o.OrderDetails)
            .WithOne(p => p.Order);
        
        modelBuilder.Entity<CustomerEntity>().HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
        
        modelBuilder.Entity<OrderDetailEntity>()
            .HasKey(od => new { od.OrderId, od.ProductId });
        
    }
    
}