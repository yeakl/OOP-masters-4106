using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Repository;

public class AlbumRepository
{
    private readonly List<Album> _albums = [];

    public void AddAlbum(Album album)
    {
        _albums.Add(album);
    }
    
    public List<Album> GetAlbums() => _albums;

    public Album GetAlbum(int index) => _albums.ElementAt(index);
}
