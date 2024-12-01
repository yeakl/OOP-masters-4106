using Microsoft.EntityFrameworkCore;
using StoreManager.Shared.Models;

namespace StoreManager.DAL.Infrastructure;

public class StoreDbContext: DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>().HasKey(s => new {s.ProductSku, s.StoreCode});
        modelBuilder.Entity<Stock>()
            .HasOne(s => s.Product)
            .WithMany()
            .HasForeignKey(s => s.ProductSku);
        
        modelBuilder.Entity<Stock>()
            .HasOne(s => s.Store)
            .WithMany()
            .HasForeignKey(s => s.StoreCode);

        modelBuilder.Entity<Store>().HasKey(s => s.Code);
        modelBuilder.Entity<Product>().HasKey(p => p.Sku);
    }
}