using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Repository;

public class ArtistRepository
{
    private readonly List<Artist> _artists = [];

    public void AddArtist(Artist artist)
    {
        _artists.Add(artist);
    }
    
    public List<Artist> GetArtists() => _artists;

    public Artist GetArtist(int index)
    {
        return _artists.ElementAt(index);
    }
}