using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Contracts;

public interface IStockRepository
{
    public Task UpdateStockAsync(List<Stock>? stockToAdd = null, List<Stock>? stockToUpdate = null);
    
    public Task<List<Stock>> GetStockInStoreAsync(string storeCode);
    
    public Task<string?> GetStoreCodeByCheapestProduct(string productSku);

    public Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount);
    public Task<List<Stock>> GetStockByProductSkusAsync(string storeCode, List<string> productSkus);
    
    public Task<string?> FindCheapestStoreCodeWithProductCombination(List<PurchaseRequestDto> productCombination);
}