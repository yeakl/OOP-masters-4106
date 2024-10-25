using System.Collections.Generic;

namespace ItmotifyApp.Catalog.Model;

public class Playlist(string name, List<Track> tracks): ICatalogItem
{
    public string Name { get; set; } = name;
    public string FullName() => $"{Name} - {Tracks.Count} tracks";

    public List<Track> Tracks { get; set; } = tracks;

    public void AddTrack(Track track)
    {
        Tracks.Add(track);
    }
}