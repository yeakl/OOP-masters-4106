using StoreManager.DAL.Contracts;

namespace StoreManager.DAL.Service;

public class JsonFileHandler: IFileHandler
{
    public void EnsureFileExistsOrCreate(string path)
    {
        if (!File.Exists(path)) File.WriteAllText(path, "[]");
    }

    public void WriteToFile(string path, string json)
    {
        throw new NotImplementedException();
    }

    public async Task WriteToFileAsync(string path, string json)
    {
        await File.WriteAllTextAsync(path, json);
    }
}
