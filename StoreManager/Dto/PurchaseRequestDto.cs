namespace StoreManager.Dto;

public class PurchaseRequestDto(string productSku, int quantity)
{
    public string ProductSku { get; } = productSku;
    public int Quantity { get; } = quantity;
}