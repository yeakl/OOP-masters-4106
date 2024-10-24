using System.Collections.Generic;

namespace ItmotifyApp.Catalog.Model;

public class Album
{
    public readonly Artist Artist; 
    public List<Track> Tracks { get; set; } = [];
    public readonly string Name;
    public readonly int Year;

    public Album(Artist artist, string name, int year)
    {
        Artist = artist;
        Name = name;
        Year = year;
    }

    public Album(Artist artist, string name, int year, List<Track> tracks)
    {
        Artist = artist;
        Name = name;
        Year = year;
        Tracks = tracks;
    }
}
