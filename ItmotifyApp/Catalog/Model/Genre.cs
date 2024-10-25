namespace ItmotifyApp.Catalog.Model;

public class Genre(string name): ISearchable, ICatalogItem
{
    public string Name { get; set; } = name;
    public string FullName() => Name;
}