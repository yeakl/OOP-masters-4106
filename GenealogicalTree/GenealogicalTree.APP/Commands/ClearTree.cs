using GenealogicalTree.BLL.Contract;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class ClearTree(ITreeService service) : ICommand
{
    public void Execute()
    {
        service.ClearAll();
        AnsiConsole.MarkupLine("[green]Tree is empty[/]");
    }
}