using PersonService.Dto;
using PersonService.Models;

namespace PersonService.Converters;

public static class PersonResponseConverter
{
    public static PersonResponse ToDto(this Person person)
    {
        return new PersonResponse()
        {
            Id = person.Id,
            Name = person.Name ?? "",
            Address = person.Address ?? "",
            Work = person.Work ?? "",
            Age = person.Age ?? 0,
        };
    }
}