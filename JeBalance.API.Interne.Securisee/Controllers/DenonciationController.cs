using JeBalance.API.Interne.Securisee.Parameters;
using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.Domain.Queries.Denonciations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Interne.Securisee.Controllers;

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
        return Ok(denonciations.Select(denonciation => new DenonciationAPI(denonciation)));
    }
}