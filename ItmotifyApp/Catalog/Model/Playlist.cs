using System.Collections.Generic;

namespace ItmotifyApp.Catalog.Model;

public class Playlist(string name, List<Track> tracks) : ICatalogItem
{
    public string Name { get; } = name;
    public string FullName() => $"{Name} - {Tracks.Count} tracks";

    public List<Track> Tracks { get; } = tracks;
}