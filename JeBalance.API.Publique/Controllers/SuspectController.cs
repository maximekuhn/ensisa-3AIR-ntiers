using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Publique.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SuspectController: ControllerBase
{
    private readonly IMediator _mediator;

    public SuspectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSuspectById([FromQuery] int suspectId)
    {
        var getSuspectByIdQuery = new GetSuspectByIdQuery(suspectId);
        var suspect = await _mediator.Send(getSuspectByIdQuery);
        Console.WriteLine($"{suspect.Nom} {suspect.Prenom}");
        return Ok(new SuspectAPI(suspect));
    }
}