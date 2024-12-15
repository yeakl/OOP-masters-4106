using GenealogicalTree.Shared.Enum;

namespace GenealogicalTree.Shared.Entity;

public class Person(string fullName, Gender gender, DateOnly birthDate)
{
    public int Id { get; set; }
    public string FullName { get; set; } = fullName;
    public Gender Gender { get; set; } = gender;
    public DateOnly BirthDate { get; set; } = birthDate;
    
    public List<Person> Children { get; set; } = [];
    public List<Person> Parents { get; set; } = [];
    public Person? Partner { get; set; }
    public int? PartnerId;

    public void GiveBirth(Person person)
    {
        if (person.Parents.Count > 2)
        {
            throw new Exception("Что-то пошло не так");
        }
        
        Children.Add(person);
        person.Parents.Add(this);
    }
}