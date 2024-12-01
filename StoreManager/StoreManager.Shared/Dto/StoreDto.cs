namespace StoreManager.Shared.Dto;

public class StoreDto(string code, string name, string address)
{
    public string Code { get; } = code;
    public string Name { get; } = name;
    public string Address { get; } = address;
}