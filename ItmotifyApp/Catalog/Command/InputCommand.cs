using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public abstract class InputCommand
{
    protected readonly InputHandler InputHandler = new();
}