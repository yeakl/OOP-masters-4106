using StoreManager.Shared.Models;

namespace StoreManager.BLL.Contracts;

public interface IProductRepository
{
    public Task AddProductAsync(Product product);
}
