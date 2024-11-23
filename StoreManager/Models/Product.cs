namespace StoreManager.Models;

public class Product(string sku, string name)
{
    public string Sku { get; init; } = sku;
    public string Name { get; init; } = name;
}