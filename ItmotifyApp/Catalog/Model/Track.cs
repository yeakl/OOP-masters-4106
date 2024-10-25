namespace ItmotifyApp.Catalog.Model;

public class Track(string name, Artist artist, Genre genre, Album album) : ISearchable, ICatalogItem
{
    public string Name { get; set; } = name;
    public string FullName() => $"{Artist.Name} - {Name} ({Genre.Name}, Album: {Album.Name})";
    public Artist Artist { get; set; } = artist;
    public Genre Genre { get; set; } = genre;
    public Album Album { get; set; } = album;
}