namespace StoreManager.Dto;

public class StoreStockRequestDto(string productSku, int quantity, decimal price)
{
    public string ProductSku { get; } = productSku;
    public int Quantity { get; } = quantity;
    public decimal Price { get; } = price;
}