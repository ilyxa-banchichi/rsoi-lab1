using PersonService.Dto;
using PersonService.Models;

namespace PersonService.Converters;

public static class PersonConverter
{
    public static Person ToModel(this PersonRequest request, int id = 0)
    {
        return new Person()
        {
            Id = id,
            Name = request.Name,
            Address = request.Address,
            Work = request.Work,
            Age = request.Age,
        };
    }
}