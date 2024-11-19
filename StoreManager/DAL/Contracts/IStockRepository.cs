using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Contracts;

public interface IStockRepository
{
    public Task AddStockAsync(List<Stock> stocks);
    public Task UpdateStockAsync(List<Stock>? stockToAdd = null, List<Stock>? stockToUpdate = null);

    public Task<List<string>> GetProductIdsInStoreAsync(string storeCode);
    
    public Task<List<Stock>> GetStockInStoreAsync(string storeCode);
    
    public Task<string?> GetStoreCodeByCheapestProduct(string productSku);

    public Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount);
    
    public Task<List<Stock>> GetStockByProductSkusAsync(string storeCode, List<string> productSkus);
}