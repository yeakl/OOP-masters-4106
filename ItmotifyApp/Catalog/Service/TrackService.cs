using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class TrackService
{
    private readonly TrackRepository _trackRepository = new();

    public Track CreateTrack(string name, Album album, Genre genre)
    {
        var track = new Track(name, album.Artist, genre, album);
        _trackRepository.Add(track);
        return track;
    }
    
    public List<Track> GetAllTracks() => _trackRepository.GetAll();

    public List<Track> Search(string term)
    {
        List<Track> tracks = [];
        foreach (var track in _trackRepository.GetAll())
        {
            if (track.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase))
            {
                tracks.Add(track);
            }
        }

        return tracks;
    }

    public Track GetTrackByIndex(int index)
    {
        return _trackRepository.GetByIndex(index);
    }
}
