using GenealogicalTree.Shared.Entity;

namespace GenealogicalTree.APP.UI;

public interface ITreePrinter
{
    public void Print(Person person);
}