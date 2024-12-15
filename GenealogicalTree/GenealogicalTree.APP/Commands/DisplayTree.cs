using GenealogicalTree.APP.UI;
using GenealogicalTree.BLL.Contract;
using GenealogicalTree.BLL.Service;
using GenealogicalTree.Shared.Entity;
using Spectre.Console;

namespace GenealogicalTree.APP.Commands;

public class DisplayTree(ITreeService treeService, ITreePrinter printer) : ICommand
{
    public void Execute()
    {
        try
        {
            var rootPerson = treeService.GetRootNode();
            printer.Print(rootPerson);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
        }
    }
}