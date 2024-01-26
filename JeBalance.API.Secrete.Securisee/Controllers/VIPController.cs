using JeBalance.API.Secrete.Securisee.Parameters;
using JeBalance.API.Secrete.Securisee.Resources;
using JeBalance.Domain.Commands.VIPs;
using JeBalance.Domain.Queries.VIPs;
using JeBalance.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Secrete.Securisee.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class VIPController : ControllerBase
{
    private readonly IMediator _mediator;

    public VIPController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateVIP([FromBody] VIPAPI resource)
    {
        var createVIPCommand = new CreateVIPCommand(resource.Nom, resource.Prenom,
            new Adresse(new NumeroVoie(resource.Adresse.NumeroVoie), new NomVoie(resource.Adresse.NomVoie),
                new CodePostal(resource.Adresse.CodePostal), new NomCommune(resource.Adresse.NomCommune)));
        var vipId = await _mediator.Send(createVIPCommand);
        return Ok(vipId);
    }

    [HttpDelete("{vipId}")]
    public async Task<IActionResult> Delete(int vipId)
    {
        var command = new DeleteVIPCommand(vipId);
        var deleteResult = await _mediator.Send(command);
        return Ok(deleteResult);
    }

    [HttpGet]
    public async Task<IActionResult> GetVIPs([FromQuery] FindVIPs parameters)
    {
        var getVIPs = new GetVIPsQuery((parameters.Limit, parameters.Offset));
        var (vips, total) = await _mediator.Send(getVIPs);
        return Ok(vips.Select(vip => new VIPGetAPI(vip)));
    }
}