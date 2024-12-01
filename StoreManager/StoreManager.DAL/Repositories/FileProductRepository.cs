using System.Text.Json;
using StoreManager.DAL.Contracts;
using StoreManager.Shared.Models;
using StoreManager.BLL.Contracts;

namespace StoreManager.DAL.Repositories;

public class FileProductRepository: IProductRepository
{
    private readonly string _filePath;
    private readonly IFileHandler _fileHandler;
   
    public FileProductRepository(string filePath, IFileHandler fileHandler)
    {
        _filePath = filePath;
        _fileHandler = fileHandler;
        _fileHandler.EnsureFileExistsOrCreate(filePath);
    }
    
    public async Task AddProductAsync(Product product)
    {
        var allProducts = await GetProductsAsync();
        if (!allProducts.Exists(p => p.Name == product.Name))
        {
            allProducts.Add(product);
        }

        var json = JsonSerializer.Serialize(allProducts);
        await _fileHandler.WriteToFileAsync(_filePath, json);
    }

    private async Task<List<Product>> GetProductsAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
    }
}