using GenealogicalTree.BLL.Contract;
using GenealogicalTree.BLL.Service;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class DisplayFirstLineRelatives(IPersonService service) : ICommand
{
    public void Execute()
    {
        var personId = AnsiConsole.Ask<int>("Input person id whose relatives will be displayed:");

        var relatives = service.GetFirstLineRelatives(personId);
        foreach (var relation in relatives.Where(relation => relation.Value.Count != 0))
        {
            AnsiConsole.WriteLine($"{relation.Key}");
            foreach (var relative in relation.Value)
            {
                AnsiConsole.WriteLine(relative.FullName + " - " + relative.BirthDate);
            }
        }
    }
}