using ItmotifyApp.Catalog.Model;
using ItmotifyApp.Catalog.Service;

namespace ItmotifyApp.Catalog.UI;

public class InputHandler
{
    public static string SearchTerm()
    {
        Console.WriteLine($"Введите часть строки для поиска по названию:");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.Error.WriteLine("Невалидный поисковой запрос");
            throw new InvalidDataException();
        }

        return input;
    }

    public string InputName(string subject)
    {
        Console.WriteLine($"Введите имя/название {subject}:");
        var input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            Console.Error.Write("Название не может быть пустым");
            throw new InvalidDataException();
        }

        return input;
    }

    public Artist InputArtist(ArtistService service)
    {
        Console.WriteLine($"Выберите номер артиста из списка");
        var artists = service.GetAllArtists();
        ChoiceItemRenderer.Render(artists);
        int.TryParse(Console.ReadLine(), out int artistIndex);
        return artists.ElementAt(artistIndex);
    }

    public Genre InputGenre(GenreService service)
    {
        Console.WriteLine($"Выберите номер жанра из списка");
        var genres = service.GetAllGenres();
        ChoiceItemRenderer.Render(genres);

        int.TryParse(Console.ReadLine(), out int genreIndex);
        return genres.ElementAt(genreIndex);
    }
}