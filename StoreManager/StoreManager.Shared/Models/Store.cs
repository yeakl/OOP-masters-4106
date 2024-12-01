namespace StoreManager.Shared.Models;

public class Store(string code, string name, string address)
{
    public string Code { get; init; } = code;
    public string Name { get; init; } = name;
    public string Address { get; init; } = address;
}