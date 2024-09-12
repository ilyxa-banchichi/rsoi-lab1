using Microsoft.AspNetCore.Mvc;

namespace PersonService.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class JopaController : Controller
{
    [HttpGet]
    public IActionResult Jopa()
    {
        return Ok("Jopa");
    }
}