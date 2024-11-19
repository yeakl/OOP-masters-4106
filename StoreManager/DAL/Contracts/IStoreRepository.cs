using StoreManager.Models;

namespace StoreManager.DAL.Contracts;

public interface IStoreRepository
{
    public Task AddStoreAsync(Store store);
    public Task<Store?> GetStoreByCodeAsync(string code);
}