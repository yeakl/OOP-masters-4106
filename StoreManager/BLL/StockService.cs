using StoreManager.DAL;
using StoreManager.DAL.Contracts;
using StoreManager.Models;

namespace StoreManager.BLL;

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