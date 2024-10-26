using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class CreatePlaylist(PlaylistService playlistService, TrackService trackService) : InputCommand, ICommand
{
    public void Execute()
    {
        var name = InputHandler.InputName("плейлиста");

        Console.WriteLine("Песни в каталоге:");
        var allTracks = trackService.GetAllTracks();
        ChoiceItemRenderer.Render(allTracks);
        List<Track> tracks = [];

        while (true)
        {
            Console.WriteLine(
                $"Выберите номер песни для добавления в плейлист или введите D для окончания создания плейлиста:");
            var input = Console.ReadLine();
            if (input == "D")
            {
                break;
            }

            int.TryParse(input, out var trackIndex);
            tracks.Add(allTracks[trackIndex]);
        }

        playlistService.CreatePlaylist(name, tracks);
    }
}