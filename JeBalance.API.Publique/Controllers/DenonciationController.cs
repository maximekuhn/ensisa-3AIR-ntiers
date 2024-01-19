using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Publique.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DenonciationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DenonciationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDenonciation([FromBody] DenonciationAPI resource)
    {
        var createDenonciationCommand = new CreateDenonciationCommand(resource.TypeDelit, resource.PaysEvasion,
            resource.NomInformateur, resource.PrenomInformateur, resource.NomSuspect, resource.PrenomSuspect);
        var denonciationId = await _mediator.Send(createDenonciationCommand);
        return Ok(denonciationId);
    }
}