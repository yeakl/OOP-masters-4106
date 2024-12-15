using GenealogicalTree.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GenealogicalTree.DAL.Infrastructure;

public class TreeDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasOne(p => p.Partner)
            .WithOne()
            .HasForeignKey<Person>(p => p.PartnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string relativeDbPath = "data/database.db";
        optionsBuilder.UseSqlite($"Data Source={relativeDbPath}");
    }
}