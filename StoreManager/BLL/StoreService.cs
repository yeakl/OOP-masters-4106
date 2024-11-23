using StoreManager.BLL.Exceptions;
using StoreManager.DAL.Contracts;
using StoreManager.Dto;
using StoreManager.Models;

namespace StoreManager.BLL;

public class StoreService(
    IStoreRepository repository,
    IStockRepository stockRepository
)
{
    public async Task<Store?> GetStoreByCode(string code)
    {
        var store = await repository.GetStoreByCodeAsync(code);
        return store;
    }

    public async Task AddStoreAsync(StoreDto storeDto)
    {
        var store = new Store(
            storeDto.Code,
            storeDto.Name,
            storeDto.Address
        );

        await repository.AddStoreAsync(store);
    }

    public async Task AddProductsToStore(Store store, List<StoreStockRequestDto> storeStockRequestDto)
    {
        var productsInStock = await stockRepository.GetStockInStoreAsync(store.Code);
        var productSkusInStock = productsInStock.Select(p => p.ProductSku).ToList();

        var productsToAdd = new List<Stock>();
        var productsToUpdate = new List<Stock>();

        foreach (var stock in storeStockRequestDto)
        {
            if (!productSkusInStock.Contains(stock.ProductSku))
            {
                var newProductInStock = new Stock(
                    stock.ProductSku,
                    store.Code,
                    stock.Quantity,
                    stock.Price
                );
                productsToAdd.Add(newProductInStock);
            }
            else
            {
                var productInStock = productsInStock.FirstOrDefault(p => p.ProductSku == stock.ProductSku);
                if (productInStock is not null)
                {
                    productInStock.UpdateQuantity(stock.Quantity).UpdatePrice(stock.Price);
                    productsToUpdate.Add(productInStock);
                }
            }
        }

        await stockRepository.UpdateStockAsync(productsToAdd, productsToUpdate);
    }

    public async Task<List<AffordableProductsDto>> GetAffordableProductsByMoneyAmount(Store store, decimal amount)
    {
        return await stockRepository.GetAffordableProductsByMoneyAmount(store.Code, amount);
    }

    public async Task<decimal> Buy(Store store, List<PurchaseRequestDto> purchaseItems)
    {
        var productSkusInPurchase = purchaseItems.Select(p => p.ProductSku).ToList();
        var purchaseProductsInStore =
            await stockRepository.GetStockByProductSkusAsync(store.Code, productSkusInPurchase);
        if (purchaseProductsInStore.Count < productSkusInPurchase.Count)
        {
            throw new UnavailableProductsInStoreException("В магазине есть не все продукты");
        }

        decimal total = 0;

        foreach (var purchase in purchaseItems)
        {
            var storeProduct = purchaseProductsInStore.Single(p => p.ProductSku == purchase.ProductSku);
            if (purchase.Quantity > storeProduct.Quantity)
            {
                throw new InsufficientProductsInStoreException("В магазине не хватает товаров");
            }

            total += storeProduct.Price * purchase.Quantity;
            storeProduct.UpdateQuantity(-1 * purchase.Quantity);
        }

        await stockRepository.UpdateStockAsync(stockToUpdate: purchaseProductsInStore);
        return total;
    }

    public async Task<Store> FindStoreWithCheapestProductCombination(List<PurchaseRequestDto> products)
    {
        var storeCode = await stockRepository.FindCheapestStoreCodeWithProductCombination(products);
        if (storeCode == null)
        {
            throw new ProductCombinationUnavailableException(
                "Не получится купить комбинацию товаров ни в одном магазине");
        }

        var store = await repository.GetStoreByCodeAsync(storeCode);
        if (store == null)
        {
            throw new ProductCombinationUnavailableException(
                "Не получится купить комбинацию товаров ни в одном магазине");
        }

        return store;
    }
}