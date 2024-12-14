using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateAlbum(ArtistService artistService, AlbumService albumService) : InputCommand, ICommand
{
    public void Execute()
    {
        var albumName = InputHandler.InputName("альбома");

        Console.WriteLine($"Введите год выхода альбома");
        int.TryParse(Console.ReadLine(), out int albumYear);


        var pickedArtist = InputHandler.InputArtist(artistService);

        albumService.CreateAlbum(albumName, albumYear, pickedArtist);
    }
}