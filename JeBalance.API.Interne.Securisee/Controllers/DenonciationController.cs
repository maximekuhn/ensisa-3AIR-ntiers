using JeBalance.API.Interne.Securisee.Parameters;
using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.API.Securite.Shared.Model;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Queries.Informateurs;
using JeBalance.Domain.Queries.Suspects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Interne.Securisee.Controllers;

[Authorize(Roles = UserRoles.AdministrateurFiscale)]
[Route("/api/[controller]")]
[ApiController]
public class DenonciationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DenonciationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("denonciationsNonTraitees")]
    public async Task<IActionResult> GetDenonciationsNonTraitees(
        [FromQuery] FindDenonciationsNonTraiteesParameter parameter)
    {
        var getDenonciationsNonTraiteesQuery =
            new GetDenonciationsNonTraiteesQuery((parameter.Limit, parameter.Offset));
        var (denonciations, total) = await _mediator.Send(getDenonciationsNonTraiteesQuery);

        var denonciationGetApiList = new List<DenonciationGetAPI>();

        foreach (var denonciation in denonciations)
        {
            var informateur = await _mediator.Send(new GetInformateurByIdQuery(denonciation.InformateurId));
            var suspect = await _mediator.Send(new GetSuspectByIdQuery(denonciation.SuspectId));

            denonciationGetApiList.Add(new DenonciationGetAPI(denonciation, informateur, suspect));
        }

        return Ok(new DenonciationsAPI(denonciationGetApiList.ToArray(), total));
    }
}