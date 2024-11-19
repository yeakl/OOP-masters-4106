using StoreManager.Models;

namespace StoreManager.DAL.Contracts;

public interface IProductRepository
{
    public Task AddProductAsync(Product product);
}
