namespace StoreManager.Shared.Models;

public class Stock(string productSku, string storeCode, int quantity, decimal price)
{
    public string ProductSku { get; init; } = productSku;
    public string StoreCode { get; init; } = storeCode;
    public int Quantity { get; private set; } = quantity;
    public decimal Price { get; private set; } = price;
    public Store? Store { get; }
    public Product? Product { get; }
    
    public Stock UpdateQuantity(int quantity)
    {
        Quantity += quantity;
        return this;
    }
    
    public Stock UpdatePrice(decimal price)
    {
        Price = price;
        return this;
    }
}