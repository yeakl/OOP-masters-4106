namespace StoreManager.Shared.Dto;

public class ProductCreateDto(string sku, string name)
{
    public string Sku { get; } = sku;
    public string Name { get; } = name;
}