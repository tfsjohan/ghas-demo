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

    [HttpPost("{id}/description")]
    public ActionResult<Person> Post(
        string id,
        [FromBody] string description)
    {
        var person = repository.GetPerson(id);

        if (person != null)
        {
            person.Description = description;
            repository.UpdatePerson(person);
            return Ok(person);
        }

        return NotFound();
    }
}