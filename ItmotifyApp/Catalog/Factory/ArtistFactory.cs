using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Factory;

public class ArtistFactory(ArtistService artistService)
{
    public void CreateFromNames(List<string> names)
    {
        foreach (var name in names)
        {
            artistService.CreateArtist(name);
        }
    }
}