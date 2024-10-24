using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Repository;

public class TrackRepository
{
    private readonly List<Track> _tracks = [];

    public void AddTrack(Track track)
    {
        _tracks.Add(track);
    }
    
    public List<Track> GetTracks() => _tracks;
}