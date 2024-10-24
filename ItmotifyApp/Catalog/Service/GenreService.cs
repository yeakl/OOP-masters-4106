using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class GenreService
{
    private readonly GenreRepository _genreRepository = new();
    
    public Genre CreateGenre(string name)
    {
        var genre = new Genre(name);
        _genreRepository.AddGenre(genre);
        return genre;
    }

    public List<Genre> GetAllGenres()
    {
        return _genreRepository.GetGenres();
    }
    
    public Genre GetGenreByIndex(int index)
    {
        return _genreRepository.GetGenre(index);
    }
}
