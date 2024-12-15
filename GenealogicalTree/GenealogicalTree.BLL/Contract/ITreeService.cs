using GenealogicalTree.Shared.Entity;

namespace GenealogicalTree.BLL.Contract;

public interface ITreeService
{
    void ClearAll();
    List<Person> Load();
    Person GetRootNode();
    bool IsValidTree();
}