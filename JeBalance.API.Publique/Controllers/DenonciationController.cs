using JeBalance.Domain.Commands;
using JeBalance.Domain.Model;
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
    public async Task<IActionResult> CreateDenonciation()
    {
        var command =
            new CreateDenonciationCommand(TypeDelit.EvasionFiscale, "France", new Informateur(0), new Suspect(0));
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}