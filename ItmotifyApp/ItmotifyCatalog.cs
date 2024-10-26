using ItmotifyApp.Catalog.Command;
using ItmotifyApp.Catalog.Factory;
using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp;

public class ItmotifyCatalog
{
    private readonly GenreService _genreService = new();
    private readonly ArtistService _artistService = new();
    private readonly TrackService _trackService = new();
    private readonly AlbumService _albumService = new();
    private readonly PlaylistService _playlistService = new();

    public void Run()
    {
        Initiialize();
        var commands = new Dictionary<int, string>()
        {
            { 1, "Search Albums" },
            { 2, "Search Artists" },
            { 3, "Search Playlists" },
            { 4, "Search Tracks" },
            { 5, "Add Track" },
            { 6, "Add Album" },
            { 7, "Add Genre" },
            { 8, "Add Artist" },
            { 9, "Add Playlist" },
            { 10, "List everything" },
        };

        foreach (var command in commands)
        {
            Console.WriteLine($"[{command.Key}]: {command.Value}");
        }

        while (true)
        {
            Console.WriteLine("Выберите действие или введите q для выхода:");
            var option = Console.ReadLine();
            if (option == "q")
            {
                break;
            }
            if (!int.TryParse(option, out var index)) continue;
            try
            {
                var command = ResolveCommand(index);
                command.Execute();
            }
            catch (NotImplementedException)
            {
                Console.Error.WriteLine("Команда не найдена!");
            }
            catch (InvalidDataException)
            {
                Console.Error.WriteLine("Некорректный ввод, начните заново");
            }
        }
    }

    private ICommand ResolveCommand(int index)
    {
        return index switch
        {
            1 => new SearchAlbums(_albumService),
            2 => new SearchArtists(_artistService),
            3 => new SearchPlaylists(_playlistService),
            4 => new SearchTracks(_trackService, _artistService, _genreService),
            5 => new CreateTrack(_artistService, _genreService, _albumService, _trackService),
            6 => new CreateAlbum(_artistService, _albumService),
            7 => new CreateGenre(_genreService),
            8 => new CreateArtist(_artistService),
            9 => new CreatePlaylist(_playlistService, _trackService),
            10 => new ListCatalog(_artistService, _trackService, _albumService, _playlistService),
            _ => throw new NotImplementedException()
        };
    }
    
    private void Initiialize()
    {
        new GenreFactory(_genreService).CreateFromNames(["Metalcore", "Deathcore", "Metal", "Pop", "R&B", "Rap"]);
        new ArtistFactory(_artistService).CreateFromNames([
            "Ice Nine Kills", "Corpsegrinder", "Three Days Grace", "Papa Roach", "EXO"
        ]);

        _albumService.CreateAlbum("The Silver Screen", 2016, _artistService.GetArtistByIndex(0));
        _albumService.CreateAlbum("The Silver Screen 2", 2020, _artistService.GetArtistByIndex(0));
        _albumService.CreateAlbum("MAMA", 2012, _artistService.GetArtistByIndex(4));
        _albumService.CreateAlbum("XOXO", 2013, _artistService.GetArtistByIndex(4));

        _trackService.CreateTrack(
            "Welcome to horrorwood",
            _albumService.GetAlbumByIndex(1),
            _genreService.GetGenreByIndex(0)
        );
        _trackService.CreateTrack(
            "Assault and batteries",
            _albumService.GetAlbumByIndex(1),
            _genreService.GetGenreByIndex(0)
        );
        _trackService.CreateTrack(
            "Shower scene",
            _albumService.GetAlbumByIndex(1),
            _genreService.GetGenreByIndex(0)
        );
        
        _trackService.CreateTrack(
            "MAMA",
            _albumService.GetAlbumByIndex(2),
            _genreService.GetGenreByIndex(3)
        );
        _trackService.CreateTrack(
            "Two moons",
            _albumService.GetAlbumByIndex(2),
            _genreService.GetGenreByIndex(5)
        );
        _trackService.CreateTrack(
            "Hurt",
            _albumService.GetAlbumByIndex(3),
            _genreService.GetGenreByIndex(4)
        );

        _playlistService.CreatePlaylist(
            "Nice",
            [
                _trackService.GetTrackByIndex(0),
                _trackService.GetTrackByIndex(1),
                _trackService.GetTrackByIndex(2),
            ]
        );
    }
}