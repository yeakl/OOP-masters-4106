using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class CreatePlaylist(PlaylistService playlistService, TrackService trackService): ICommand 
{
    public void Execute()
    {
        Console.WriteLine($"Введите название плейлиста:");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.Error.WriteLine("Название не может быть пустым");
            return;
        }
        
        Console.WriteLine("Песни в каталоге:");
        var allTracks = trackService.GetAllTracks();
        ChoiceItemRenderer.Render(allTracks);
        List<Track> tracks = [];
        
        while (true)
        {
            Console.WriteLine($"Выберите номер песни для добавления в плейлист или введите D для окончания создания плейлиста:");
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
