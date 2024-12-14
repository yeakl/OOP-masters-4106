using System.Collections.Generic;

namespace ItmotifyApp.Catalog.Model;

public class Album : ICatalogItem
{
    public readonly Artist Artist;
    public string Name { get; }
    public string FullName() => $"{Artist.Name} - {Name} ({Year})";
    public List<Track> Tracks { get; } = [];
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