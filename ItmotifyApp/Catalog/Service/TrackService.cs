using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;
using ItmotifyApp.Catalog.Search;

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

    public List<Track> FullSearch(TrackSearchForm searchForm)
    {
        List<Track> search = [];
        if (searchForm is { Name: not null, Artist: null })
        {
            search.AddRange(_trackRepository.FindByName(searchForm.Name));
            return search;
        }

        if (searchForm is { Name: not null, Artist: not null })
        {
            search.AddRange(_trackRepository.FindByNameAndArtist(searchForm.Artist, searchForm.Name));
            return search;
        }

        if (searchForm is { Name: null, Artist: not null })
        {
            search.AddRange(_trackRepository.FindByArtist(searchForm.Artist));
            return search;
        }

        if (searchForm is { Name: not null, Genre: not null })
        {
            search.AddRange(_trackRepository.FindByNameAndGenre(searchForm.Name, searchForm.Genre));
        }

        return search;
    }

    public Track GetTrackByIndex(int index)
    {
        return _trackRepository.GetByIndex(index);
    }
}