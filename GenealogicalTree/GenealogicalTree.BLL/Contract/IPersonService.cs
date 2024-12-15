using GenealogicalTree.Shared.Dto;
using GenealogicalTree.Shared.Entity;
using GenealogicalTree.Shared.Enum;

namespace GenealogicalTree.BLL.Contract;

public interface IPersonService
{
    Person AddPerson(NewPersonDto personDto);
    Person RecordPerson(Person person);
    void AddRelation(int personId, int targetId, RelationType type);
    Dictionary<string, List<Person>> GetFirstLineRelatives(int personId);
    int CalculateAgeAtBirth(int ancestorId, int descendantId);
    bool CheckAtLeastTwoPeopleExist();
    List<Person> FindCommonAncestors(int person1Id, int person2Id);
}
