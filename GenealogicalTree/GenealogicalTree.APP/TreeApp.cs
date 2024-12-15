using GenealogicalTree.APP.Commands;
using GenealogicalTree.APP.UI;
using GenealogicalTree.BLL.Contract;
using Spectre.Console;

namespace GenealogicalTree.APP;

public class TreeApp(
    IPersonService personService,
    ITreeService treeService,
    ITreePrinter printer
)
{
    public void Run()
    {
        var options = new Dictionary<int, string>
        {
            { 1, "Add person" },
            { 2, "Add relation" },
            { 3, "Display first line relatives" },
            { 4, "Calc ancestor's age during descendant's birthdate" },
            { 5, "Find two common ancestors" },
            { 6, "Display genealogical tree" },
            { 7, "Clear tree" },
            { 8, "Quit" }
        };

        while (true)
        {
            var command = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("Choose option:")
                    .PageSize(options.Count)
                    .AddChoices(options.Keys)
                    .UseConverter(key => $"{key} - {options[key]}"));

            var executeCommand = ResolveCommand(command);
            if (executeCommand is null)
            {
                AnsiConsole.MarkupLine("[yellow]Bye bye![/]");
                break;
            }

            executeCommand.Execute();
        }
    }

    private ICommand? ResolveCommand(int index)
    {
        return index switch
        {
            1 => new CreatePerson(personService),
            2 => new AddRelation(personService),
            3 => new DisplayFirstLineRelatives(personService),
            4 => new CalculateAncestorsAge(personService),
            5 => new DisplayCommonAncestors(personService),
            6 => new DisplayTree(treeService, printer),
            7 => new ClearTree(treeService),
            8 => null,
            _ => throw new NotImplementedException()
        };
    }
}