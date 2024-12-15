using GenealogicalTree.BLL.Contract;
using GenealogicalTree.DAL.Infrastructure;
using GenealogicalTree.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace GenealogicalTree.DAL.Repository;

public class DbPersonRepository(TreeDbContext context) : IPersonRepository
{
    public Person CreatePerson(Person person)
    {
        context.Add(person);
        context.SaveChanges();
        return person;
    }

    public Person? GetPerson(int personId)
    {
        return context.People.Include(p => p.Parents).FirstOrDefault(p => p.Id == personId);
    }

    public Person UpdatePerson(Person person)
    {
        context.Update(person);
        context.SaveChanges();
        return person;
    }

    public void ClearAll()
    {
        context.Database.ExecuteSqlRaw("DELETE FROM People");
    }

    public List<Person> GetAll()
    {
        var people = context.People
            .Include(p => p.Parents)
            .Include(p => p.Children)
            .ToList();

        return people;
    }

    public List<Person> GetPeopleWithoutParents()
    {
        return GetAll().Where(p => p.Parents.Count == 0).ToList();
    }

    public Person? GetOldestPersonWithoutParents()
    {
        return GetAll().Where(p => p.Parents.Count == 0).OrderBy(p => p.BirthDate).FirstOrDefault();
    }
}