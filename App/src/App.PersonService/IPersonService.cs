using App.Common.Models;

namespace App.PersonService;

public interface IPersonService
{
    IEnumerable<Person> GetAllPersons();
    Person GetPerson(int id);
    Task<long> CreatePersonAsync(Person person);
    Task DeletePersonAsync(int id);
    Task<Person> UpdatePersonAsync(Person person);
}