using Microsoft.EntityFrameworkCore;
using StoreManager.DAL.Contracts;
using StoreManager.DAL.Infrastructure;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class DbStockRepository(StoreDbContext context): IStockRepository
{
    public async Task AddStockAsync(List<Stock> stocks)
    {
        context.Stocks.AddRange(stocks);
        await context.SaveChangesAsync();
    }

    public async Task UpdateStockAsync(List<Stock>? stockToAdd, List<Stock>? stockToUpdate)
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
    

    public async Task<List<string>> GetProductIdsInStoreAsync(string storeCode)
    {
        var productIds = await context.Stocks.Where(s => s.StoreCode == storeCode).Select(s => s.ProductSku).ToListAsync();
        return productIds;
    }

    public async Task<List<Stock>> GetStockInStoreAsync(string storeCode)
    {
        var products = await context.Stocks.Where(s => s.StoreCode == storeCode).ToListAsync();
        return products;
    }

    public Task<List<Stock>> GetStockByProductIdAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> GetStoreCodeByCheapestProduct(string productSku)
    {
        var storeCode = await context.Stocks.OrderBy(s => (double)s.Price).Select(s => s.StoreCode).FirstOrDefaultAsync();
        return storeCode;
    }

    public async Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(string storeCode, decimal moneyAmount)
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

    /*public async Task<Stock?> LoadProductByStoreAndProductAsync(string storeCode, int productId)
    {
        var stock = await context.Stocks.FirstOrDefaultAsync(stock => stock.ProductId == productId && stock.StoreCode == storeCode);
        return stock;
    }*/
}
