﻿using Microsoft.EntityFrameworkCore;
using WebShopSolution.DataAccess.Entities;
using WebShopSolution.DataAccess.Entities.Enums;

namespace WebShopSolution.DataAccess;

public class WebShopDbContext(DbContextOptions<WebShopDbContext> options) : DbContext
{
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    public DbSet<PaymentMethodEntity> PaymentMethods { get; set; } = null!;
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
        
        modelBuilder.Entity<OrderEntity>()
            .HasOne(o => o.PaymentMethod).WithMany()
            .HasForeignKey(o => o.PaymentMethodId);
        
        modelBuilder.Entity<PaymentMethodEntity>()
            .HasMany(pm => pm.Orders)
            .WithOne(o => o.PaymentMethod);

        modelBuilder.Entity<PaymentMethodEntity>().Property(pm => pm.PaymentMethod)
            .HasConversion(v => v.ToString(),
                v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));
    }
}