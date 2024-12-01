using StoreManager.Shared.Models;

namespace StoreManager.BLL.Contracts;

public interface IStoreRepository
{
    public Task AddStoreAsync(Store store);
    public Task<Store?> GetStoreByCodeAsync(string code);
}