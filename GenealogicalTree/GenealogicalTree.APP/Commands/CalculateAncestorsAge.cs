using GenealogicalTree.BLL.Contract;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class CalculateAncestorsAge(IPersonService personService) : ICommand
{
    public void Execute()
    {
        var ancestorId = AnsiConsole.Ask<int>("Enter an ancestor's id: ");
        var descendantId = AnsiConsole.Ask<int>("Enter a descendant's id: ");

        var age = personService.CalculateAgeAtBirth(ancestorId, descendantId);

        AnsiConsole.MarkupLine($"Ancestor was {age} years old.");

    }
}