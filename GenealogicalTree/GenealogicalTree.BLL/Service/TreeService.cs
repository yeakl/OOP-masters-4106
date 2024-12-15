using GenealogicalTree.BLL.Contract;
using GenealogicalTree.Shared.Entity;

namespace GenealogicalTree.BLL.Service;

public class TreeService(IPersonRepository personRepository) : ITreeService
{
    public void ClearAll()
    {
        personRepository.ClearAll();
    }

    public List<Person> Load()
    {
        return personRepository.GetAll();
    }

    public List<Person> GetRootNodes()
    {
        return personRepository.GetPeopleWithoutParents();
    }

    public Person GetRootNode()
    {
        var rootNode = personRepository.GetOldestPersonWithoutParents();
        if (rootNode == null)
        {
            throw new Exception("The tree is either empty or no root person exists");
        }
        
        return rootNode;
    }

    public bool IsValidTree()
    {
        return personRepository.GetAll().Count > 1;
    }
}