using GenealogicalTree.Shared.Enum;
namespace GenealogicalTree.Shared.Dto;

public class NewPersonDto(string fullName, Gender gender, DateOnly birthDate)
{
    public string FullName { get; set; } = fullName;
    public Gender Gender { get; set; } = gender;
    public DateOnly BirthDate { get; set; } = birthDate;
}