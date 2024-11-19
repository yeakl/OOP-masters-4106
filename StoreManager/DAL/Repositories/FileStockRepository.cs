using StoreManager.DAL.Contracts;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class FileStockRepository: IStockRepository
{
    public Task AddStockAsync(List<Stock> stocks)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStockAsync(List<Stock>? stockToAdd, List<Stock>? stockToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetProductIdsInStoreAsync(string storeCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<Stock>> GetStockInStoreAsync(string storeCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<Stock>> GetStockByProductIdAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetStoreCodeByCheapestProduct(string productSku)
    {
        throw new NotImplementedException();
    }

    public Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount)
    {
        throw new NotImplementedException();
    }

    public Task<List<Stock>> GetStockByProductSkusAsync(string storeCode, List<string> productSkus)
    {
        throw new NotImplementedException();
    }
}