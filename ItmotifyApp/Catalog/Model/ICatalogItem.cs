namespace ItmotifyApp.Catalog.Model;

public interface ICatalogItem
{
    public string Name { get; set; }
    
    public string FullName();
}