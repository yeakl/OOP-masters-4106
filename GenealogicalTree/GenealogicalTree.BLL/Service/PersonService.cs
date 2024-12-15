using GenealogicalTree.BLL.Contract;
using GenealogicalTree.Shared.Dto;
using GenealogicalTree.Shared.Entity;
using GenealogicalTree.Shared.Enum;

namespace GenealogicalTree.BLL.Service;

public class PersonService(IPersonRepository repository) : IPersonService
{
    public Person AddPerson(NewPersonDto personDto)
    {
        var person = new Person(personDto.FullName, personDto.Gender, personDto.BirthDate);
        repository.CreatePerson(person);
        return person;
    }

    public Person RecordPerson(Person person)
    {
        repository.UpdatePerson(person: person);
        return person;
    }

    public void AddRelation(int personId, int targetId, RelationType type)
    {
        var person1 = repository.GetPerson(personId);
        var person2 = repository.GetPerson(targetId);
        if (person1 is null || person2 is null)
        {
            throw new Exception();
        }
        
        if (type == RelationType.Partner)
        {
            if (person1.Partner is not null && person2.Partner is not null)
            {
                throw new Exception("Polygamy is outlawed!");
            }
            person1.Partner = person2;
            person2.Partner = person1;
        }
        else if (type == RelationType.Parent)
        {
            if (!person1.Children.Contains(person2))
            {
                person1.Children.Add(person2);
            }

            if (!person2.Parents.Contains(person1))
            {
                person2.Parents.Add(person1);
            }
        }

        RecordPerson(person1);
        RecordPerson(person2);
    }

    public Dictionary<string, List<Person>> GetFirstLineRelatives(int personId)
    {
        var relatives = new Dictionary<string, List<Person>>();
        var person = repository.GetPerson(personId);
        if (person == null)
        {
            throw new Exception(); 
        }

        relatives["parents"] = person.Parents;
        relatives["children"] = person.Children;
        return relatives;
    }

    public int CalculateAgeAtBirth(int ancestorId, int descendantId)
    {
        var ancestor = repository.GetPerson(ancestorId);
        var descendant = repository.GetPerson(descendantId);
        if (ancestor is null || descendant is null)
        {
            throw new Exception();
        }
        
        var result = descendant.BirthDate.Year - ancestor.BirthDate.Year;
        if (descendant.BirthDate < descendant.BirthDate.AddYears(result))
        {
            result--;
        }

        return result;
    }

    public bool CheckAtLeastTwoPeopleExist()
    {
        return repository.GetAll().Count >= 2;
    }

    public List<Person> FindCommonAncestors(int person1Id, int person2Id)
    {
        var person1 = repository.GetPerson(person1Id);
        var person2 = repository.GetPerson(person2Id);
        if (person1 is null || person2 is null)
        {
            throw new Exception();
        }
        
        var ancestorsOfPerson1 = GetAncestors(person1);
        var ancestorsOfPerson2 = GetAncestors(person2);
      
        var commonAncestors = ancestorsOfPerson1.Intersect(ancestorsOfPerson2).ToList();

        return commonAncestors;
    }
    
    private HashSet<Person> GetAncestors(Person person)
    {
        var ancestors = new HashSet<Person>();

        CollectAncestors(person);
        return ancestors;

        void CollectAncestors(Person current)
        {
            foreach (var parent in current.Parents.Where(parent => ancestors.Add(parent)))
            {
                CollectAncestors(parent);
            }
        }
    }

}