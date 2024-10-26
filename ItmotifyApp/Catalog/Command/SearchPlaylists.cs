using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchPlaylists(PlaylistService playlistService) : InputCommand, ICommand
{
    public void Execute()
    {
        var name = InputHandler.SearchTerm();
        var playlists = playlistService.Search(name);
        Console.WriteLine($"Найдено плейлистов: {playlists.Count}");
        CatalogItemRenderer.Render(playlists);
    }
}