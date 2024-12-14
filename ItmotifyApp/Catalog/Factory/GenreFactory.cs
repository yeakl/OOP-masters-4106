using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Factory;

public class GenreFactory(GenreService genreService)
{
    public void CreateFromNames(List<string> names)
    {
        foreach (var name in names)
        {
            genreService.CreateGenre(name);
        }
    }
}