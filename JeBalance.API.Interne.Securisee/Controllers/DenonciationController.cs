using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Interne.Securisee.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class DenonciationController: ControllerBase
{
    private readonly IMediator _mediator;

    public DenonciationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("denonciationsNonTraitees")]
    public async Task<IActionResult> GetDenonciationsNonTraitees()
    {
        return Ok("");
    }
}