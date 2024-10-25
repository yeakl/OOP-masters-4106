using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchArtists(ArtistService artistService): ICommand
{
    public void Execute()
    {
        Console.WriteLine($"Введите часть строки для поиска по названию:");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.Error.WriteLine("Невалидный поисковой запрос");
            return;
        }

        var artists = artistService.Search(input);
        Console.WriteLine($"Найдено артистов: {artists.Count}");
        CatalogItemRenderer.Render(artists);
    }
}
