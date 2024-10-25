using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateAlbum(ArtistService artistService, AlbumService albumService): ICommand
{
    public void Execute()
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
        var artists = artistService.GetAllArtists();
        var index = 0;
        foreach (var artist in artists)
        {
            Console.WriteLine($"{index}: {artist.Name}");
            ++index;
        }

        var artistIndex = Convert.ToInt32(Console.ReadLine());
        var pickedArtist = artists.ElementAt(artistIndex);

        albumService.CreateAlbum(albumName, albumYear, pickedArtist);
    }
}