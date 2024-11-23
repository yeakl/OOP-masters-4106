using Microsoft.EntityFrameworkCore;
using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class DbStockRepository(StoreDbContext context): IStockRepository
{
    public async Task UpdateStockAsync(List<Stock>? stockToAdd = null, List<Stock>? stockToUpdate = null)
    {
        if (stockToAdd is not null && stockToAdd.Any())
        {
            context.Stocks.AddRange(stockToAdd);
        }

        if (stockToUpdate is not null && stockToUpdate.Any())
        {
            context.Stocks.UpdateRange(stockToUpdate);
        }

        await context.SaveChangesAsync();
    }
    
    public async Task<List<Stock>> GetStockInStoreAsync(string storeCode)
    {
        var products = await context.Stocks.Where(s => s.StoreCode == storeCode).ToListAsync();
        return products;
    }

    public async Task<string?> GetStoreCodeByCheapestProduct(string productSku)
    {
        var storeCode = await context.Stocks.OrderBy(s => (double)s.Price).Select(s => s.StoreCode).FirstOrDefaultAsync();
        return storeCode;
    }

    public async Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode,
        decimal moneyAmount)
    {
        return await context.Stocks
            .Where(ps => ps.StoreCode == storeCode)
            .Select(ps => new AffordableProductsDto
            {
                ProductSku = ps.ProductSku,
                Amount = Math.Min((int)(moneyAmount / ps.Price), ps.Quantity),
            })
            .Where(dto => dto.Amount > 0)
            .ToListAsync();
    }
    
    public async Task<List<Stock>> GetStockByProductSkusAsync(string storeCode, List<string> productSkus)
    {
        return await context.Stocks.Where(s => productSkus.Contains(s.ProductSku) && s.StoreCode == storeCode && s.Quantity > 0).ToListAsync();
    }

    public async Task<string?> FindCheapestStoreCodeWithProductCombination(List<PurchaseRequestDto> productCombination)
    {
        var allSkus = productCombination.Select(s => s.ProductSku).ToList();
        var productQuantityMap = productCombination.ToDictionary(p => p.ProductSku, p => p.Quantity);

        var stockData = await context.Stocks
            .Where(stock => allSkus.Contains(stock.ProductSku))
            .ToListAsync();

        var storesWithSufficientQuantitiesAndTotalSum = stockData
            .GroupBy(stock => stock.StoreCode)
            .Where(group =>
                allSkus.All(sku =>
                        group.Any(stock => stock.ProductSku == sku) &&
                        group.Any(stock => stock.ProductSku == sku && stock.Quantity >= productQuantityMap[sku])
                )
            )
            .Select(group => new
            {
                StoreCode = group.Key,
                TotalSum = group
                    .Where(stock => productQuantityMap.ContainsKey(stock.ProductSku))
                    .Sum(stock =>
                            productQuantityMap[stock.ProductSku] * stock.Price
                    )
            })
            .OrderBy(store => store.TotalSum)
            .FirstOrDefault();
        
        return storesWithSufficientQuantitiesAndTotalSum?.StoreCode;
    }   
}
