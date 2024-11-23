using System.Text.Json;
using StoreManager.DAL.Contracts;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class FileStockRepository : IStockRepository
{
    private readonly string _filePath;
    private readonly IFileHandler _fileHandler;
    
    public FileStockRepository(string filePath, IFileHandler fileHandler)
    {
        _filePath = filePath;
        _fileHandler = fileHandler;
        _fileHandler.EnsureFileExistsOrCreate(filePath);
    }

    public async Task UpdateStockAsync(List<Stock>? stockToAdd, List<Stock>? stockToUpdate)
    {
        var stock = await GetAllStockAsync();
        bool hasChanges = false;
        if (stockToAdd is not null && stockToAdd.Any())
        {
            stock.AddRange(stockToAdd);
            hasChanges = true;
        }

        if (stockToUpdate is not null && stockToUpdate.Any())
        {
            foreach (var updatedStock in stockToUpdate)
            {
                var existingStockIndex = stock.FindIndex(s =>
                    s.ProductSku == updatedStock.ProductSku &&
                    s.StoreCode == updatedStock.StoreCode);
                
                stock[existingStockIndex] = updatedStock;
            }
            hasChanges = true;
        }

        if (hasChanges)
        {
            var json = JsonSerializer.Serialize(stock);
            await _fileHandler.WriteToFileAsync(_filePath, json);
        }
    }

    public async Task<List<Stock>> GetStockInStoreAsync(string storeCode)
    {
        var stock = await GetAllStockAsync();

        return stock.Where(s => s.StoreCode == storeCode).ToList();
    }

    public async Task<string?> GetStoreCodeByCheapestProduct(string productSku)
    {
        var stock = await GetAllStockAsync();

        return stock.Where(s => s.ProductSku == productSku).OrderBy(s => s.Price)
            .Select(s => s.StoreCode).FirstOrDefault();;
    }

    public async Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount)
    {
       var stock = await GetStockInStoreAsync(storeCode);
       return stock.Where(ps => ps.StoreCode == storeCode)
           .Select(ps => new AffordableProductsDto
           {
               ProductSku = ps.ProductSku,
               Amount = Math.Min((int)(moneyAmount / ps.Price), ps.Quantity),
           })
           .Where(dto => dto.Amount > 0)
           .ToList();
    }

    public async Task<List<Stock>> GetStockByProductSkusAsync(string storeCode, List<string> productSkus)
    {
        var stock = await GetAllStockAsync();

        return stock.Where(s => productSkus.Contains(s.ProductSku) && s.StoreCode == storeCode && s.Quantity > 0).ToList();
    }

    public async Task<string?> FindCheapestStoreCodeWithProductCombination(List<PurchaseRequestDto> productCombination)
    {
        var allSkus = productCombination.Select(s => s.ProductSku).ToList();
        var productQuantityMap = productCombination.ToDictionary(p => p.ProductSku, p => p.Quantity);

        var stock = await GetAllStockAsync();
        var stockData = stock
            .Where(s => productQuantityMap.Keys.Contains(s.ProductSku))
            .ToList();

        var storesWithSufficientQuantitiesAndTotalSum = stockData
            .GroupBy(s => s.StoreCode)
            .Where(group =>
                allSkus.All(sku =>
                    group.Any(s => s.ProductSku == sku) &&
                    group.Any(s => s.ProductSku == sku && s.Quantity >= productQuantityMap[sku])
                )
            )
            .Select(group => new
            {
                StoreCode = group.Key,
                TotalSum = group    
                    .Where(s => productQuantityMap.ContainsKey(s.ProductSku))
                    .Sum(s =>
                        productQuantityMap[s.ProductSku] * s.Price
                    )
            })
            .OrderBy(store => store.TotalSum)
            .FirstOrDefault();
        
        return storesWithSufficientQuantitiesAndTotalSum?.StoreCode;
    }
    
    private async Task<List<Stock>> GetAllStockAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Stock>>(json) ?? new List<Stock>();
    }
}