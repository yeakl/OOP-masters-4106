using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Search;

public class TrackSearchForm(string? name = null, Artist? artist = null, Genre? genre = null)
{
    public string? Name { get; } = name;
    public Artist? Artist { get; } = artist;
    public Genre? Genre { get; } = genre;
}