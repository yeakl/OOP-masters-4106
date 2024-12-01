namespace StoreManager.DAL.Contracts;

public interface IFileHandler
{
    public void EnsureFileExistsOrCreate(string path);
    public void WriteToFile(string path, string json);
    public Task WriteToFileAsync(string path, string json);
}