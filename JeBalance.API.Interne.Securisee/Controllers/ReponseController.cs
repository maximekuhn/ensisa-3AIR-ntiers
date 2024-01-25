using JeBalance.Domain.Commands.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JeBalance.API.Interne.Securisee.Resources;

namespace JeBalance.API.Interne.Securisee.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ReponseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReponseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateReponse([FromQuery] Guid denonciationId, [FromBody] ReponseCreateAPI resource)
    {
        var createReponseCommand = new CreateReponseCommand(
            resource.TypeReponse,
            resource.Retribution,
            denonciationId
        );
        var reponseId = await _mediator.Send(createReponseCommand);
        return Ok(reponseId);
    }
    
}