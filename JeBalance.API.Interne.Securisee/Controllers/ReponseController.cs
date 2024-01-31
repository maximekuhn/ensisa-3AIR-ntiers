using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.API.Securite.Shared.Model;
using JeBalance.Domain.Commands.Reponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = UserRoles.AdministrateurFiscale)]
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
    public async Task<IActionResult> CreateReponse([FromQuery] Guid denonciationId,
        [FromBody] ReponseCreateAPI resource)
    {
        try
        {
            var createReponseCommand = new CreateReponseCommand(
                resource.TypeReponse,
                resource.Retribution,
                denonciationId
            );
            var reponseId = await _mediator.Send(createReponseCommand);
            return Ok(reponseId);
        }
        catch (ApplicationException e)
        {
            return BadRequest(new { message = e.Message });
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}