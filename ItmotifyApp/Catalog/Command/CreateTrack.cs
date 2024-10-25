using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateTrack(
    ArtistService artistService,
    GenreService genreService,
    AlbumService albumService,
    TrackService trackService) : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"Введите название песни:");
        var songName = Console.ReadLine();
        if (string.IsNullOrEmpty(songName))
        {
            Console.Error.WriteLine("Название не может быть пустым");
            return;
        }

        Console.WriteLine($"Выберите номер артиста из списка");
        var artists = artistService.GetAllArtists();
        var index = 0;
        foreach (var artist in artists)
        {
            Console.WriteLine($"{index}: {artist.Name}");
            ++index;
        }

        var artistIndex = Convert.ToInt32(Console.ReadLine());
        var pickedArtist = artists.ElementAt(artistIndex);


        Console.WriteLine($"Выберите номер жанра из списка");
        var genres = genreService.GetAllGenres();
        index = 0;
        foreach (var genre in genres)
        {
            Console.WriteLine($"{index}: {genre.Name}");
            ++index;
        }

        var genreIndex = Convert.ToInt32(Console.ReadLine());
        var pickedGenre = genres.ElementAt(genreIndex);

        Console.WriteLine("Выберите номер альбома из списка или введите N для создания альбома");
        var albums = albumService.GetAllAlbums();
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

        var track = trackService.CreateTrack(songName, pickedAlbum, pickedGenre);
        albumService.AddTrack(track, pickedAlbum);
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

        return albumService.CreateAlbum(albumName, albumYear, artist);
    }
}