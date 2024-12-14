using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateTrack(
    ArtistService artistService,
    GenreService genreService,
    AlbumService albumService,
    TrackService trackService) : InputCommand, ICommand
{
    public void Execute()
    {
        var songName = InputHandler.InputName("песни");
        var pickedArtist = InputHandler.InputArtist(artistService);
        var pickedGenre = InputHandler.InputGenre(genreService);

        Console.WriteLine("Выберите номер альбома из списка или введите N для создания альбома");
        var albums = albumService.GetAllAlbums();
        var index = 0;
        foreach (var album in albums)
        {
            Console.WriteLine($"{index}: {album.Artist.Name} - {album.Name} ({album.Year})");
            ++index;
        }

        var input = Console.ReadLine();
        Album? pickedAlbum;

        if (input == "N")
        {
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