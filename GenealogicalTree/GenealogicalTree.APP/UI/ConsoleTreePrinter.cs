using GenealogicalTree.Shared.Entity;
using Spectre.Console;

namespace GenealogicalTree.APP.UI;

public class ConsoleTreePrinter : ITreePrinter
{
    private TreeNode? _currentNode = null;
    private Tree _tree = new("[yellow]Genealogical Tree[/]");

    public void Print(Person person)
    {
        _tree.Nodes.Clear();
        Visit(person);
        AnsiConsole.Write(_tree);
    }

    public void Visit(Person person)
    {
        var nodeToAdd = person.FullName;
        if (person.Partner is not null)
        {
            nodeToAdd += " ---- " + person.Partner.FullName;
        }


        var personNode = _currentNode is null ? _tree.AddNode(nodeToAdd) : _currentNode.AddNode(nodeToAdd);

        var previousNode = _currentNode;

        _currentNode = personNode;
        foreach (var child in person.Children)
        {
            Visit(child);
        }

        _currentNode = previousNode;
    }
}