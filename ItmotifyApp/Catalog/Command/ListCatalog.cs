using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class ListCatalog(
    ArtistService artistService,
    TrackService trackService,
    AlbumService albumService,
    PlaylistService playlistService) : ICommand
{
    public void Execute()
    {
        var artists = artistService.GetAllArtists();
        var tracks = trackService.GetAllTracks();
        var albums = albumService.GetAllAlbums();
        var playlists = playlistService.GetAllPlaylists();

        Console.WriteLine("ВСЕ АРТИСТЫ: ");
        CatalogItemRenderer.Render(artists);

        Console.WriteLine("ВСЕ ТРЕКИ: ");
        CatalogItemRenderer.Render(tracks);

        Console.WriteLine("ВСЕ АЛЬБОМЫ: ");
        CatalogItemRenderer.Render(albums);

        Console.WriteLine("ВСЕ ПЛЕЙЛИСТЫ: ");
        CatalogItemRenderer.Render(playlists);
    }
}