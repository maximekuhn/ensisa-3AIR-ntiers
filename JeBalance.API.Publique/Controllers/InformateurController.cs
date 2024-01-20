using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Publique.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class InformateurController : ControllerBase
{
    private readonly IMediator _mediator;

    public InformateurController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetInformateurById([FromQuery] int informateurId)
    {
        var getInforamteurByIdQuery = new GetInformateurByIdQuery(informateurId);
        var informateur = await _mediator.Send(getInforamteurByIdQuery);
        return Ok(new InformateurAPI(informateur));
    }
}