using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class AlbumService
{
    private readonly AlbumRepository _albumRepository = new();

    public Album CreateAlbum(string name, int year, Artist artist)
    {
        var album = new Album(artist, name, year);
        _albumRepository.Add(album);
        return album;
    }

    public List<Album> GetAllAlbums()
    {
        return _albumRepository.GetAll();
    }

    public Album GetAlbumByIndex(int index)
    {
        return _albumRepository.GetByIndex(index);
    }

    public void AddTrack(Track track, Album album)
    {
        album.Tracks.Add(track);
    }

    public List<Album> Search(string term)
    {
        List<Album> albums = [];
        foreach (var album in _albumRepository.GetAll())
        {
            if (album.Name.ToLower().Contains(term.ToLower()))
            {
                albums.Add(album);
            }
        }

        return albums;
    }
}