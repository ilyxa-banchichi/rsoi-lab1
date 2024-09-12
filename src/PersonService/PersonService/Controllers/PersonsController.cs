using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonService.Converters;
using PersonService.Dto;
using PersonService.Repositories;

namespace PersonService.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PersonsController : Controller
{
    private readonly IPersonRepository _personRepository;

    public PersonsController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    /// <summary>
    /// Get all Persons
    /// </summary>
    /// <response code="200">All Persons</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PersonResponse>), (int)HttpStatusCode.OK)]
    public IActionResult GetAllPersons()
    {
        var persons = _personRepository.GetAll();
        return Ok(persons);
    }
    
    /// <summary>
    /// Get Person by ID
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Person for ID</response>
    /// <response code="404">Not found Person for ID</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult GetPerson(int id)
    {
        var person = _personRepository.Get(id);
        return person != null ? Ok(person.ToDto()) : NotFound(new ErrorResponse("Not found Person for ID"));
    }
    
    /// <summary>
    /// Create new Person
    /// </summary>
    /// <param name="person">Person data</param>
    /// <response code="201">Created new Person</response>
    /// <response code="400">Invalid data</response>
    [HttpPost()]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreatePerson([FromBody] PersonRequest person)
    {
        if (!person.IsValid())
            return BadRequest("Invalid data");
        
        var id = await _personRepository.Create(person.ToModel());
        return Created($"/api/v1/persons/{id}", null);
    }
    
    /// <summary>
    /// Remove Person by ID
    /// </summary>
    /// <param name="id">Person ID</param>
    /// <response code="204">Person for ID was removed</response>
    /// <response code="404">Not found Person for ID</response>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var result = await _personRepository.Delete(id);
        return result ? NoContent() : NotFound(new ErrorResponse("Not found Person for ID"));
    }
    
    /// <summary>
    /// Update Person by ID
    /// </summary>
    /// <param name="id">Person ID</param>
    /// <param name="person">Person data</param>
    /// <response code="200">Person for ID was updated</response>
    /// <response code="400">Invalid data</response>
    /// <response code="404">Not found Person for ID</response>
    [HttpPatch("{id}")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonRequest person)
    {
        if (!person.IsValid())
            return BadRequest("Invalid data");

        var exist = await _personRepository.Update(person.ToModel(id));
        if (exist)
        {
            var updatedPerson = _personRepository.Get(id);
            return Ok(updatedPerson);
        }
        
        return NotFound(new ErrorResponse("Not found Person for ID"));
    }
}