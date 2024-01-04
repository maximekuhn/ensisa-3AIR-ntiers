using JeBalance.API.Publique.Resources;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Publique.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DenonciationController : ControllerBase
{

    [HttpPost("create")]
    public string CreateDenonciation([FromBody] DenonciationAPI denonciationApi)
    {
        Console.WriteLine(denonciationApi);
        return "super cool";
    }
}