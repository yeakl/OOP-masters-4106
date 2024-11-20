using System.Text.Json;
using StoreManager.DAL.Contracts;
using StoreManager.Models;

namespace StoreManager.DAL.Repositories;

public class FileStoreRepository: IStoreRepository
{
    private readonly string _filePath;
    public FileStoreRepository(string filePath)
    {
        _filePath = filePath;
        EnsureExistsOrCreateFile(filePath);
    }

    private void EnsureExistsOrCreateFile(string filePath)
    {
        if (!File.Exists(filePath)) File.WriteAllText(filePath, "[]");
    }
    
    public async Task AddStoreAsync(Store store)
    {
        var allStores = await GetAllStoresAsync();
        if (!allStores.Exists(s => s.Name == store.Name))
        {
            allStores.Add(store);
        }

        await WriteStoresAsync(allStores);
    }

    public async Task<Store?> GetStoreByCodeAsync(string code)
    {
        var allStores = await GetAllStoresAsync();
        return allStores.FirstOrDefault(s => s.Code == code);
    }

    private async Task WriteStoresAsync(List<Store> stores)
    {
        var json = JsonSerializer.Serialize(stores);
        await File.WriteAllTextAsync(_filePath, json);
    }

    private async Task<List<Store>> GetAllStoresAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Store>>(json) ?? new List<Store>();
    }
}