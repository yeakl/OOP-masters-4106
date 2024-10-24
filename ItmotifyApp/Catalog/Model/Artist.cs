namespace ItmotifyApp.Catalog.Model;

public class Artist(string name): ISearchable
{
    public string Name { get; set; } = name;
}