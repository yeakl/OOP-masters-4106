using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.Repository;

public class TrackRepository : BaseRepository<Track>
{
    public List<Track> FindByArtist(Artist artist)
    {
        List<Track> tracks = [];
        tracks.AddRange(GetAll().Where(track => track.Artist.Equals(artist)));

        return tracks;
    }

    public List<Track> FindByNameAndGenre(string name, Genre genre)
    {
        List<Track> tracks = [];
        tracks.AddRange(GetAll().Where(track =>
            track.Genre.Equals(genre) && track.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)));

        return tracks;
    }

    public List<Track> FindByNameAndArtist(Artist artist, string name)
    {
        List<Track> tracks = [];
        tracks.AddRange(GetAll().Where(track =>
            track.Artist.Equals(artist) && track.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)));

        return tracks;
    }
}