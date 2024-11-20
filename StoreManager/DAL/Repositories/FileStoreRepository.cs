using System.Text.Json;
using StoreManager.DAL.Contracts;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class FileStoreRepository: IStoreRepository
{
    private readonly string _filePath;
    private readonly IFileHandler _fileHandler;
    
    public FileStoreRepository(string filePath, IFileHandler fileHandler)
    {
        _filePath = filePath;
        _fileHandler = fileHandler;
        _fileHandler.EnsureFileExistsOrCreate(filePath);
    }

    public async Task AddStoreAsync(Store store)
    {
        var allStores = await GetAllStoresAsync();
        if (!allStores.Exists(s => s.Name == store.Name))
        {
            allStores.Add(store);
        }

        var json = JsonSerializer.Serialize(allStores);
        await _fileHandler.WriteToFileAsync(_filePath, json);
    }

    public async Task<Store?> GetStoreByCodeAsync(string code)
    {
        var allStores = await GetAllStoresAsync();
        return allStores.FirstOrDefault(s => s.Code == code);
    }
    
    private async Task<List<Store>> GetAllStoresAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Store>>(json) ?? new List<Store>();
    }
}