using System.Text.Json;
using StoreManager.DAL.Contracts;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class FileProductRepository: IProductRepository
{
    private readonly string _filePath;
   
    public FileProductRepository(string filePath)
    {
        _filePath = filePath;
        EnsureExistsOrCreateFile(filePath);
    }

    private void EnsureExistsOrCreateFile(string filePath)
    {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
    }
    
    public async Task AddProductAsync(Product product)
    {
        var allProducts = await GetProductsAsync();
        if (!allProducts.Exists(p => p.Name == product.Name))
        {
            allProducts.Add(product);
        }

        await WriteProductsAsync(allProducts);
    }

    private async Task<List<Product>> GetProductsAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
    }

    private async Task WriteProductsAsync(List<Product> products)
    {
        var json = JsonSerializer.Serialize(products);
        await File.WriteAllTextAsync(_filePath, json);
    }
}