using GenealogicalTree.APP.UI;
using GenealogicalTree.BLL.Contract;
using GenealogicalTree.BLL.Service;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class AddRelation(IPersonService personService) : ICommand
{
    public void Execute()
    {
        if (!personService.CheckAtLeastTwoPeopleExist())
        {
            AnsiConsole.MarkupLine("[red]Error: Not enough people to form relations[/]");
            return;
        }

        var relation = InputHandler.InputRelation();
        personService.AddRelation(relation.SubjectId, relation.RelationId, relation.RelationType);
    }
}
