namespace ItmotifyApp.Catalog.Model;

public class Artist(string name) : ICatalogItem
{
    public string Name { get; } = name;
    public string FullName() => Name;
}