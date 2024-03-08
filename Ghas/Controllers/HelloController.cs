using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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

    [HttpGet("image")]
    public IActionResult GetImage(int w = 100, int h = 100)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image.png");

        // Resize image with ImageSharp
        using var image = Image.Load(path);
        image.Mutate(x => x.Resize(w, h));
        using var memoryStream = new MemoryStream();
        image.SaveAsPng(memoryStream);
        memoryStream.Position = 0;
        return File(memoryStream, "image/png");
    }
}