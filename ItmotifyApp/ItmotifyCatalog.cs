using ItmotifyApp.Catalog.Factory;
using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp;

public class ItmotifyCatalog
{
    private readonly GenreService _genreService = new();
    private readonly ArtistService _artistService = new();
    private readonly TrackService _trackService = new();
    private readonly AlbumService _albumService = new();

    public void Run()
    {
        Initiialize();
        Dictionary<int, string> commands = new Dictionary<int, string>()
        {
            { 0, "Search All" },
            { 1, "Search Albums" },
            { 2, "Search Artists" },
            { 3, "Search Collections" },
            { 4, "Search Tracks" },
            { 5, "Add Track" },
            { 6, "Add Album" },
            { 7, "Add Genre" },
            { 8, "Add Artist" },
            { 9, "Add Collection" },
            { 10, "List everything" },
        };

        foreach (var command in commands)
        {
            Console.WriteLine($"{command.Key}: {command.Value}");
        }

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            var option = Console.ReadLine();
            if (int.TryParse(option, out int index))
            {
                switch (index)
                {
                    case 0:
                        break;
                    case 5:
                        CreateTrack();
                        break;
                    case 6:
                        CreateAlbum();
                        break;
                    case 7:
                        CreateGenre();
                        break;
                    case 8:
                        CreateArtist();
                        break;
                    case 10:
                        ListEverything();
                        break;
                }
            }
        }
    }

    private void CreateGenre()
    {
        Console.WriteLine($"Введите название жанра:");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            _genreService.CreateGenre(input);
        }
    }

    private void CreateArtist()
    {
        Console.WriteLine($"Введите имя/название артиста:");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            _artistService.CreateArtist(input);
        }
    }

    private void ListEverything()
    {
        Console.WriteLine("ALL ARTISTS: ");
        foreach (var artist in _artistService.GetAllArtists())
        {
            Console.WriteLine(artist.Name);
        }

        Console.WriteLine("ALL TRACKS: ");
        foreach (var track in _trackService.GetAllTracks())
        {
            Console.WriteLine($"{track.Artist.Name} - {track.Name} ({track.Genre.Name}, Album: {track.Album.Name})");
        }

        Console.WriteLine("ALL ALBUMS: ");
        foreach (var album in _albumService.GetAllAlbums())
        {
            Console.WriteLine($"{album.Artist.Name} - {album.Name} ({album.Year})");
        }
    }

    private void CreateTrack()
    {
        Console.WriteLine($"Введите название песни:");
        var songName = Console.ReadLine();
        if (string.IsNullOrEmpty(songName))
        {
            Console.Error.WriteLine("Название не может быть пустым");
            return;
        }

        Console.WriteLine($"Выберите номер артиста из списка");
        var artists = _artistService.GetAllArtists();
        var index = 0;
        foreach (var artist in artists)
        {
            Console.WriteLine($"{index}: {artist.Name}");
            ++index;
        }

        var artistIndex = Convert.ToInt32(Console.ReadLine());
        var pickedArtist = artists.ElementAt(artistIndex);


        Console.WriteLine($"Выберите номер жанра из списка");
        var genres = _genreService.GetAllGenres();
        index = 0;
        foreach (var genre in genres)
        {
            Console.WriteLine($"{index}: {genre.Name}");
            ++index;
        }

        var genreIndex = Convert.ToInt32(Console.ReadLine());
        var pickedGenre = genres.ElementAt(genreIndex);

        Console.WriteLine("Выберите номер альбома из списка или введите N для создания альбома");
        var albums = _albumService.GetAllAlbums();
        index = 0;
        foreach (var album in albums)
        {
            Console.WriteLine($"{index}: {album.Artist.Name} - {album.Name} ({album.Year})");
            ++index;
        }

        var input = Console.ReadLine();
        Album? pickedAlbum;

        if (input == "N")
        {
            //create Album
            pickedAlbum = CreateAlbum(pickedArtist);
        }
        else
        {
            int.TryParse(input, out int albumIndex);
            pickedAlbum = albums.ElementAt(albumIndex);
        }

        if (pickedAlbum == null)
        {
            Console.Error.WriteLine("Не смог создать альбом");
            return;
        }

        var track = _trackService.CreateTrack(songName, pickedAlbum, pickedGenre);
        _albumService.AddTrack(track, pickedAlbum);
        return;
    }

    private void CreateAlbum()
    {
        Console.WriteLine($"Введите название альбома:");
        var albumName = Console.ReadLine();
        if (string.IsNullOrEmpty(albumName))
        {
            Console.Error.WriteLine("Название не может быть пустым");
            return;
        }

        Console.WriteLine($"Введите год выхода альбома");
        Int32.TryParse(Console.ReadLine(), out int albumYear);


        Console.WriteLine($"Выберите номер артиста из списка");
        var artists = _artistService.GetAllArtists();
        var index = 0;
        foreach (var artist in artists)
        {
            Console.WriteLine($"{index}: {artist.Name}");
            ++index;
        }

        var artistIndex = Convert.ToInt32(Console.ReadLine());
        var pickedArtist = artists.ElementAt(artistIndex);

        _albumService.CreateAlbum(albumName, albumYear, pickedArtist);
    }

    private Album? CreateAlbum(Artist artist)
    {
        Console.WriteLine($"Введите название альбома:");
        var albumName = Console.ReadLine();
        if (string.IsNullOrEmpty(albumName))
        {
            Console.Error.WriteLine("Название не может быть пустым");
            return null;
        }

        Console.WriteLine($"Введите год выхода альбома");
        Int32.TryParse(Console.ReadLine(), out int albumYear);

        return _albumService.CreateAlbum(albumName, albumYear, artist);
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
    }
}