using GenealogicalTree.Shared.Dto;
using GenealogicalTree.Shared.Entity;
namespace GenealogicalTree.BLL.Contract;

public interface IPersonRepository
{
    public Person CreatePerson(Person person);
    
    public Person? GetPerson(int id);

    public Person UpdatePerson(Person person);
    
    public void ClearAll();

    public List<Person> GetAll();
    public List<Person> GetPeopleWithoutParents();

    public Person? GetOldestPersonWithoutParents();
}