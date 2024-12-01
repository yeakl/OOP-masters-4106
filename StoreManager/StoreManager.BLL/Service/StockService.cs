using StoreManager.BLL.Contracts;
using StoreManager.Shared.Models;
namespace StoreManager.BLL.Service;

public class StockService(IStockRepository repository, IStoreRepository storeRepository)
{
    public async Task<Store?> FindStoreWithCheapestProduct(string productSku)
    {
        var storeCode = await repository.GetStoreCodeByCheapestProduct(productSku);
        if (storeCode == null) return null;

        var store = await storeRepository.GetStoreByCodeAsync(storeCode);
        return store;
    }
}