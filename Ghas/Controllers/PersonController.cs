using Ghas.Data;
using Ghas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ghas.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IRepository repository) : ControllerBase
{
    public ActionResult<Person> Get(string id)
    {
        var person = repository.GetPerson(id);

        if (person != null)
        {
            return Ok(person);
        }

        return NotFound();
    }
}