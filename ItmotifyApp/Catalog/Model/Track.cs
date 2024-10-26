namespace ItmotifyApp.Catalog.Model;

public class Track(string name, Artist artist, Genre genre, Album album) : ICatalogItem
{
    public string Name { get; } = name;
    public string FullName() => $"{Artist.Name} - {Name} ({Genre.Name}, Album: {Album.Name})";
    public Artist Artist { get; } = artist;
    public Genre Genre { get; } = genre;
    public Album Album { get; } = album;
}