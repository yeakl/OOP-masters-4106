using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateGenre(GenreService service) : InputCommand, ICommand
{
    public void Execute()
    {
        var input = InputHandler.InputName("жанра");
        service.CreateGenre(input);
    }
}