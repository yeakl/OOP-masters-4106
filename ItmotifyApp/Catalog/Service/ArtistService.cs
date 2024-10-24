using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class ArtistService
{
    private readonly ArtistRepository _artistRepository = new();
    
    public Artist CreateArtist(string name)
    {
        var artist = new Artist(name);
        _artistRepository.AddArtist(artist);
        return artist;
    }

    public List<Artist> GetAllArtists()
    {
        return _artistRepository.GetArtists();
    }

    public Artist GetArtistByIndex(int index)
    {
        return _artistRepository.GetArtist(index);
    }
}
