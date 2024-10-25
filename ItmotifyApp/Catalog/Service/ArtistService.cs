using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class ArtistService
{
    private readonly ArtistRepository _artistRepository = new();
    
    public Artist CreateArtist(string name)
    {
        var artist = new Artist(name);
        _artistRepository.Add(artist);
        return artist;
    }

    public List<Artist> GetAllArtists()
    {
        return _artistRepository.GetAll();
    }

    public Artist GetArtistByIndex(int index)
    {
        return _artistRepository.GetByIndex(index);
    }
    
    public List<Artist> Search(string term)
    {
        List<Artist> artists = [];
        foreach (var artist in _artistRepository.GetAll())
        {
            if (artist.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase))
            {
                artists.Add(artist);
            }
        }

        return artists;
    }
}
