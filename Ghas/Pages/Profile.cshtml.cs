using Ghas.Data;
using Ghas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ghas.Pages;

public class Profile : PageModel
{
    [FromRoute] public string? Id { get; set; }

    public Person? Person { get; private set; }

    public void OnGet([FromServices] IRepository repository)
    {
        if (Id != null)
        {
            Person = repository.GetPerson(Id);
        }
    }
}