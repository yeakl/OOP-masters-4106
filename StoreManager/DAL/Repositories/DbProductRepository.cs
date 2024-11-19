using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class DbProductRepository(StoreDbContext context): IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }
}