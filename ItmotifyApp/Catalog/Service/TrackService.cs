using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class TrackService
{
    private readonly TrackRepository _trackRepository = new();

    public Track CreateTrack(string name, Album album, Genre genre)
    {
        var track = new Track(name, album.Artist, genre, album);
        _trackRepository.AddTrack(track);
        return track;
    }
    
    public List<Track> GetAllTracks() => _trackRepository.GetTracks();
}
