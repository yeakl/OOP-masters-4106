using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Repository;

namespace ItmotifyApp.Catalog.Service;

public class PlaylistService
{
    private readonly PlaylistRepository _playlistRepository = new();
    
    public Playlist CreatePlaylist(string name, List<Track> tracks)
    {
        var playlist = new Playlist(name, tracks);
        _playlistRepository.Add(playlist);
        return playlist;
    }

    public List<Playlist> GetAllPlaylists()
    {
        return _playlistRepository.GetAll();
    }
    
    public List<Playlist> Search(string term)
    {
        List<Playlist> playlists = [];
        foreach (var playlist in _playlistRepository.GetAll())
        {
            if (playlist.Name.ToLower().Contains(term.ToLower()))
            {
                playlists.Add(playlist);
            }
        }

        return playlists;
    }
}