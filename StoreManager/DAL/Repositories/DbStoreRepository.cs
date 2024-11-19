using Microsoft.EntityFrameworkCore;
using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class DbStoreRepository(StoreDbContext context) : IStoreRepository
{
    public async Task AddStoreAsync(Store store)
    {
        context.Stores.Add(store);
        await context.SaveChangesAsync();
    }

    public async Task<Store?> GetStoreByCodeAsync(string code)
    {
        var store = await context.Stores.FirstOrDefaultAsync(s => s.Code == code);
        return store;
    }
}