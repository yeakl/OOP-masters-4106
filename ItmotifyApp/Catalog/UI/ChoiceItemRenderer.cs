using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.UI;

public class ChoiceItemRenderer
{
    public static void Render<T>(List<T> items) where T : ICatalogItem
    {
        var index = 0;
        foreach (var item in items)
        {
            Console.WriteLine($"{index}: {item.FullName()}");
            index++;
        }
    }
}