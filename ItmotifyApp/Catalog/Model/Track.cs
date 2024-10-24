namespace ItmotifyApp.Catalog.Model;

public class Track(string name, Artist artist, Genre genre, Album album): ISearchable
{
    public string Name { get; set; } = name;
    public Artist Artist { get; set; } = artist;
    public Genre Genre { get; set; } = genre;
    public Album Album { get; set; } = album;
}