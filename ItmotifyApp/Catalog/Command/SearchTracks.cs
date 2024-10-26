using ItmotifyApp.Catalog.Search;
using ItmotifyApp.Catalog.Service;
using ItmotifyApp.Catalog.UI;

namespace ItmotifyApp.Catalog.Command;

public class SearchTracks(TrackService trackService, ArtistService artistService, GenreService genreService) : InputCommand, ICommand
{
    public void Execute()
    {
        var options = new Dictionary<int, string>()
        {
            { 1, "Название" },
            { 2, "Исполнитель" },
            { 3, "Название и исполнитель" },
            { 4, "Название и жанр"}
        };
        
        Console.WriteLine("Выберите тип поиска");

        foreach (var option in options)
        {
            Console.WriteLine($"[{option.Key}] : {option.Value}");
        }
        
        int.TryParse(Console.ReadLine(), out int inputOption);
        var searchBuilder = new TrackSearchBuilder();
        TrackSearchForm form = new();
        switch (inputOption)
        {
            case 1: form = SearchByName(searchBuilder); break;
            case 2: form = SearchByArtist(searchBuilder);
                break;
            case 3: form = SearchByNameAndArtist(searchBuilder); break;
            case 4: form = SearchByNameAndGenre(searchBuilder);
                break;
        }
      

        var tracks = trackService.FullSearch(form);
        Console.WriteLine($"Найдено треков: {tracks.Count}");
        CatalogItemRenderer.Render(tracks);
    }
    
    private TrackSearchForm SearchByName(TrackSearchBuilder builder)
    {
        var input = InputHandler.SearchTerm();
        return builder.WithName(input).Build();
    }

    private TrackSearchForm SearchByArtist(TrackSearchBuilder builder)
    {
        var pickedArtist = InputHandler.InputArtist(artistService);
        return builder.WithArtist(pickedArtist).Build();
    }

    private TrackSearchForm SearchByNameAndArtist(TrackSearchBuilder builder)
    {
        var name = InputHandler.SearchTerm();
        var pickedArtist = InputHandler.InputArtist(artistService);
        return builder.WithName(name).WithArtist(pickedArtist).Build();
    }

    private TrackSearchForm SearchByNameAndGenre(TrackSearchBuilder builder)
    {
        var name = InputHandler.SearchTerm();
        var genre = InputHandler.InputGenre(genreService);
        return builder.WithName(name).WithGenre(genre).Build();
    }
}