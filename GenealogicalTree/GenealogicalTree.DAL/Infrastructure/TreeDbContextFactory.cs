using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace GenealogicalTree.DAL.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TreeDbContext>
{
    public TreeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TreeDbContext>();
        optionsBuilder.UseSqlite("Data Source=data/database.db");

        return new TreeDbContext(optionsBuilder.Options);
    }
}