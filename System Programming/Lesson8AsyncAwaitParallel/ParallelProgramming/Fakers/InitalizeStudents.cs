using Bogus;
using ParallelProgramming.Models;

namespace ParallelProgramming.Fakers;

public static class InitalizeStudents
{
    private static readonly Faker<Student> _faker;
    static InitalizeStudents()
    {
        _faker = new Faker<Student>();
        _faker.RuleFor(s => s.Id, f => f.UniqueIndex)
             .RuleFor(s => s.Name, f => f.Name.FirstName())
             .RuleFor(s => s.Surname, f => f.Name.LastName())
             .RuleFor(s => s.Email, f => f.Person.Email);
    }

    public static List<Student> GenerateStudents(int count) => _faker.Generate(count);
}
