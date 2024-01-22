using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.ValueObjects;
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
        var suspect = new Suspect(resource.NomSuspect, resource.PrenomSuspect,
            new Adresse(new NumeroVoie(resource.NumeroVoieSuspect), new NomVoie(resource.NomVoieSuspect),
                new CodePostal(resource.CodePostalSuspect), new NomCommune(resource.NomCommuneSuspect)), 0);
        var informateur = new Informateur(resource.NomInformateur, resource.PrenomInformateur,
            new Adresse(new NumeroVoie(resource.NumeroVoieInformateur), new NomVoie(resource.NomVoieInformateur),
                new CodePostal(resource.CodePostalInformateur), new NomCommune(resource.NomCommuneInformateur)), 0);
        var createDenonciationCommand = new CreateDenonciationCommand(
            resource.TypeDelit,
            resource.PaysEvasion,
            informateur,
            suspect
        );
        var denonciationId = await _mediator.Send(createDenonciationCommand);
        return Ok(denonciationId);
    }

    [HttpGet]
    public async Task<IActionResult> GetDenonciationById([FromQuery] Guid denonciationId)
    {
        var getDenonciationByIdQuery = new GetDenonciationByIdQuery(denonciationId);
        var denonciation = await _mediator.Send(getDenonciationByIdQuery);
        return Ok(denonciation);
    }
}