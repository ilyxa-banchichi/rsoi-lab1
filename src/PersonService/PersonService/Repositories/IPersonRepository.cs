using PersonService.Models;

namespace PersonService.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    Person? Get(int id);
    Task<long> Create(Person person);
    Task<bool> Delete(int id);
    Task<bool> Update(Person person);
}