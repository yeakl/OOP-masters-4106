namespace ItmotifyApp.Catalog.Model;

public interface ICatalogItem
{
    public string Name { get; }

    public string FullName();
}