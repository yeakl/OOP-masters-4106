using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateGenre(GenreService service) : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"Введите название жанра:");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception();
        }

        service.CreateGenre(input);
    }
}