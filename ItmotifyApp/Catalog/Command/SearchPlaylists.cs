using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchPlaylists(PlaylistService playlistService): ICommand
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
        
        var playlists = playlistService.Search(input);
        Console.WriteLine($"Найдено артистов: {playlists.Count}");
        CatalogItemRenderer.Render(playlists);
    }
}