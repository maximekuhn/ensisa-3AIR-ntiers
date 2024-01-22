using JeBalance.API.Secrete.Securisee.Resources;
using JeBalance.Domain.Commands.VIPs;
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // TODO
        return null;
    }
}