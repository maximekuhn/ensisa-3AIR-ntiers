using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Queries.Informateurs;
using JeBalance.Domain.Queries.Reponses;
using JeBalance.Domain.Queries.Suspects;
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
        var suspect = new Suspect(resource.Suspect.Nom, resource.Suspect.Prenom, resource.Suspect.Adresse.ToAdresse());
        var informateur = new Informateur(resource.Informateur.Nom, resource.Informateur.Prenom,
            resource.Informateur.Adresse.ToAdresse());
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

        var getInformateurByIdQuery = new GetInformateurByIdQuery(denonciation.InformateurId);
        var informateur = await _mediator.Send(getInformateurByIdQuery);

        var getSuspectByIdQuery = new GetSuspectByIdQuery(denonciation.SuspectId);
        var suspect = await _mediator.Send(getSuspectByIdQuery);

        Reponse? reponse = null;
        if (denonciation.ReponseId != null)
        {
            var getReponseByIdQuery = new GetReponseByIdQuery(denonciation.ReponseId.Value);
            reponse = await _mediator.Send(getReponseByIdQuery);
        }

        return Ok(new DenonciationGetAPI(denonciation, informateur, suspect, reponse));
    }
}