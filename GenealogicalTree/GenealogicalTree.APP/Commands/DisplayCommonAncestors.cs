using GenealogicalTree.BLL.Contract;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class DisplayCommonAncestors(IPersonService service) : ICommand
{
    public void Execute()
    {
        var person1 = AnsiConsole.Ask<int>("Enter first person's id: ");
        var person2 = AnsiConsole.Ask<int>("Enter second person's id: ");

        var ancestors = service.FindCommonAncestors(person1, person2);
        if (ancestors.Count == 0)
        {
            AnsiConsole.MarkupLine("No ancestors found");
        }
        else
        {
            foreach (var ancestor in ancestors)
            {
                AnsiConsole.WriteLine($"{ancestor.FullName} - {ancestor.BirthDate}");
            }
        }
    }
}