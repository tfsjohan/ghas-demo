using Microsoft.AspNetCore.Mvc;

namespace Ghas.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController(ILogger<HelloController> Logger) : ControllerBase
{
    [HttpGet]
    public string Get(string name)
    {
        Logger.LogInformation("Saying hello to {name}", name);
        return $"Hello, {name}!";
    }
}