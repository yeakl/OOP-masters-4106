using ItmotifyApp.Catalog.Model;

namespace ItmotifyApp.Catalog.UI;

public abstract class CatalogItemRenderer
{
    public static void Render<T>(List<T> items) where T : ICatalogItem
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.FullName()}");
        }
    }
}