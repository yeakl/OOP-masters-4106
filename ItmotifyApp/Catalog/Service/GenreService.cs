using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class GenreService
{
    private readonly GenreRepository _genreRepository = new();
    
    public Genre CreateGenre(string name)
    {
        var genre = new Genre(name);
        _genreRepository.Add(genre);
        return genre;
    }

    public List<Genre> GetAllGenres()
    {
        return _genreRepository.GetAll();
    }
    
    public Genre GetGenreByIndex(int index)
    {
        return _genreRepository.GetByIndex(index);
    }
}
