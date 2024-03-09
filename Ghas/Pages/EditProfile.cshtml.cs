using Ghas.Data;
using Ghas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ghas.Pages;

public class EditProfile : PageModel
{
    [FromRoute] public string? Id { get; set; }

    public Person Person { get; set; } = new() { Id = "", Name = "" };

    // Load the person from the repository
    public void OnGet([FromServices] IRepository repository)
    {
        if (Id == null) throw new InvalidOperationException("Id is required");

        var model = repository.GetPerson(Id);

        Person = model ?? throw new InvalidOperationException("Person not found");
    }

    // Save the person to the repository
    public IActionResult OnPost([FromServices] IRepository repository)
    {
        repository.SavePerson(Person);

        return RedirectToPage("Profile", new { id = Person.Id });
    }
}