namespace ItmotifyApp.Catalog.Model;

public class Genre(string name): ISearchable
{
    public string Name { get; set; } = name;
}