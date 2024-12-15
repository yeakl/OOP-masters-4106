using GenealogicalTree.BLL.Service;
using GenealogicalTree.Shared.Dto;
using GenealogicalTree.Shared.Enum;
using Spectre.Console;

namespace GenealogicalTree.APP.UI;

public class InputHandler
{
    public static NewPersonDto InputPerson()
    {
        var name = AnsiConsole.Ask<string>("Input name:");
        var birthDate = AnsiConsole.Ask<DateOnly>("Input DOB in yyyy-mm-dd format:");
        var gender = AnsiConsole.Prompt(
            new SelectionPrompt<Gender>()
                .Title("Gender")
                .AddChoices(Gender.Male, Gender.Female, Gender.Undefined)
        );

        var person = new NewPersonDto(
            name, gender, birthDate
        );

        return person;
    }

    public static RelationDto InputRelation()
    {
        var person1 = AnsiConsole.Ask<int>("Input id of person 1:");
        var person2 = AnsiConsole.Ask<int>("Input id of person 2:");

        var relationType = AnsiConsole.Prompt(
            new SelectionPrompt<RelationType>().
                Title("Relation type of person 1 to person 2").
                AddChoices(RelationType.Parent, RelationType.Partner)
            );

        return new RelationDto(person1, person2, relationType);
    }
}