namespace ItmotifyApp.Catalog.Model;

public class Artist(string name) : ISearchable, ICatalogItem
{
    public string Name { get; set; } = name;
    public string FullName() => Name;
}