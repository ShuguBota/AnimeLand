using Microsoft.AspNetCore.Mvc;

namespace AnimeLand.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageGeneratorController : Controller
{
    [HttpGet(Name = "GetImageGenerator")]
    public IActionResult Get()
    {
        var dirPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
        var imgName = "Luffy.png";

        var imagePath = Path.Combine(dirPath, imgName);
        var imageFileStream = System.IO.File.OpenRead(imagePath);

        return File(imageFileStream, "image/png");
    }
}
