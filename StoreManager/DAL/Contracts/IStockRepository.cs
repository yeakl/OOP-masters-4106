using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Contracts;

public interface IStockRepository
{
    public Task AddStockAsync(List<Stock> stocks);
    public Task UpdateStockAsync(List<Stock>? stockToAdd, List<Stock>? stockToUpdate);

    public Task<List<string>> GetProductIdsInStoreAsync(string storeCode);
    
    public Task<List<Stock>> GetStockInStoreAsync(string storeCode);
    
    public Task<List<Stock>> GetStockByProductIdAsync(string productId);

    public Task<string?> GetStoreCodeByCheapestProduct(string productSku);

    public Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount);
}