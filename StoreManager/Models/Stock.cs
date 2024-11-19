namespace StoreManager.Models;

public class Stock
{
    public required string ProductSku { get; set; }
    public required string StoreCode { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Store Store { get; }
    public Product Product { get; }
    
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