using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.Command;

public class CreateArtist(ArtistService service) : InputCommand, ICommand
{
    public void Execute()
    {
        var input = InputHandler.InputName("артиста");
        service.CreateArtist(input);
    }
}