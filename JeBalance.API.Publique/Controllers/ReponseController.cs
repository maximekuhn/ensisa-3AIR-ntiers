using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Commands.Reponses;
using JeBalance.Domain.Queries.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> CreateReponse([FromBody] ReponseCreateAPI resource)
    {
        // TODO : deplacer dans l'autre api
        var createReponseCommand = new CreateReponseCommand(
            resource.TypeReponse,
            resource.Retribution,
            resource.DenonciationId
        );
        var reponseId = await _mediator.Send(createReponseCommand);
        return Ok(reponseId);
    }

    [HttpGet]
    public async Task<IActionResult> GetReponseById([FromQuery] int reponseId)
    {
        var getReponseByIdQuery = new GetReponseByIdQuery(reponseId);
        var reponse = await _mediator.Send(getReponseByIdQuery);
        return Ok(new ReponseAPI(reponse));
    }
}