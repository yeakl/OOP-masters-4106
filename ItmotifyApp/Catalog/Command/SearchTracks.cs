using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchTracks(TrackService trackService): ICommand
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

        var tracks = trackService.Search(input);
        Console.WriteLine($"Найдено артистов: {tracks.Count}");
        CatalogItemRenderer.Render(tracks);
    }
}