using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchArtists(ArtistService artistService) : ICommand
{
    public void Execute()
    {
        var input = InputHandler.SearchTerm();
        var artists = artistService.Search(input);
        Console.WriteLine($"Найдено артистов: {artists.Count}");
        CatalogItemRenderer.Render(artists);
    }
}