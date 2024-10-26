using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchAlbums(AlbumService albumService) : InputCommand, ICommand
{
    private InputHandler _handler = new ();
    public void Execute()
    {
        var input = InputHandler.SearchTerm();
        var albums = albumService.Search(input);
        Console.WriteLine($"Найдено альбомов: {albums.Count}");
        CatalogItemRenderer.Render(albums);
    }
}