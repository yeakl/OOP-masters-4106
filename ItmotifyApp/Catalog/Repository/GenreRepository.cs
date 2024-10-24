using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Repository;

public class GenreRepository
{
    private readonly List<Genre> _genres = [];

    public void AddGenre(Genre genre)
    {
        _genres.Add(genre);
    }
    
    public List<Genre> GetGenres() => _genres;

    public Genre GetGenre(int index) => _genres.ElementAt(index);
}