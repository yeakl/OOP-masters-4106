using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateArtist(ArtistService service): ICommand
{
    public void Execute()
    {
        Console.WriteLine($"Введите имя/название артиста:");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            service.CreateArtist(input);
        }
    }
}
