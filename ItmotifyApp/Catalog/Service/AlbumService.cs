using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class AlbumService
{
    private readonly AlbumRepository _albumRepository = new();
    
    public Album CreateAlbum(string name, int year, Artist artist)
    {
        var album = new Album(artist, name, year);
        _albumRepository.AddAlbum(album);
        return album;
    }

    public List<Album> GetAllAlbums()
    {
        return _albumRepository.GetAlbums();
    }

    public Album GetAlbumByIndex(int index)
    {
        return _albumRepository.GetAlbum(index);
    }
    
    public void AddTrack(Track track, Album album)
    {
        album.Tracks.Add(track);
    }
}