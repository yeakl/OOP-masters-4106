using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Search;

public class TrackSearchBuilder
{
    private string? _name;
    private Artist? _artist;
    private Genre? _genre;

    public TrackSearchBuilder WithName(string term)
    {
        _name = term;
        return this;
    }

    public TrackSearchBuilder WithArtist(Artist artist)
    {
        _artist = artist;
        return this;
    }

    public TrackSearchBuilder WithGenre(Genre genre)
    {
        _genre = genre;
        return this;
    }

    public TrackSearchForm Build()
    {
        return new TrackSearchForm(_name, _artist, _genre);
    }
}