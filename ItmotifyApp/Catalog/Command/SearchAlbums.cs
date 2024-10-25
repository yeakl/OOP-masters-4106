using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchAlbums(AlbumService albumService): ICommand
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

        var albums = albumService.Search(input);
        Console.WriteLine($"Найдено альбомов: {albums.Count}");
        CatalogItemRenderer.Render(albums);
    }
}