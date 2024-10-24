using System.Collections.Generic;

namespace ItmotifyApp.Catalog.Model;

public class Playlist(string name, List<Track> tracks)
{
    public string Name { get; set; } = name;
    public List<Track> Tracks { get; set; } = tracks;

    public void AddTrack(Track track)
    {
        Tracks.Add(track);
    }
}