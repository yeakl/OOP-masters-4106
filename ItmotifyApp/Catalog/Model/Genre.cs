namespace ItmotifyApp.Catalog.Model;

public class Genre(string name) : ICatalogItem
{
    public string Name { get; } = name;
    public string FullName() => Name;
}