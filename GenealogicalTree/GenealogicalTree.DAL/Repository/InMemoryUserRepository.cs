using GenealogicalTree.BLL.Contract;
using GenealogicalTree.Shared.Entity;

namespace GenealogicalTree.DAL.Repository;

public class InMemoryUserRepository: IPersonRepository
{
    private List<Person> _people = [];
    
    public Person CreatePerson(Person person)
    {
        _people.Add(person);
        return person;
    }

    public Person? GetPerson(int id)
    {
        return _people[id];
    }

    public List<Person> GetPeople()
    {
        return _people;
    }

    public Person UpdatePerson(Person person)
    {
        return person;
    }

    public void ClearAll()
    {
        _people.Clear();
    }

    public List<Person> GetAll()
    {
        return _people;
    }

    public List<Person> GetPeopleWithoutParents()
    {
        return _people.Where(p => p.Parents.Count == 0).ToList();
    }

    public Person? GetOldestPersonWithoutParents()
    {
        return _people.Where(p => p.Parents.Count == 0).OrderBy(p => p.BirthDate).FirstOrDefault();
    }
}