using JeBalance.API.Secrete.Securisee.Parameters;
using JeBalance.API.Secrete.Securisee.Resources;
using JeBalance.API.Securite.Shared.Model;
using JeBalance.Domain.Commands.VIPs;
using JeBalance.Domain.Queries.VIPs;
using JeBalance.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Secrete.Securisee.Controllers;

[Authorize(Roles = UserRoles.Administrateur)]
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
        try
        {
            var createVIPCommand = new CreateVIPCommand(resource.Nom, resource.Prenom,
                new Adresse(new NumeroVoie(resource.Adresse.NumeroVoie), new NomVoie(resource.Adresse.NomVoie),
                    new CodePostal(resource.Adresse.CodePostal), new NomCommune(resource.Adresse.NomCommune)));
            var vipId = await _mediator.Send(createVIPCommand);
            return Ok(vipId);
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

    [HttpDelete("{vipId}")]
    public async Task<IActionResult> Delete(int vipId)
    {
        try
        {
            var command = new DeleteVIPCommand(vipId);
            var deleteResult = await _mediator.Send(command);
            return Ok(deleteResult);
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

    [HttpGet]
    public async Task<IActionResult> GetVIPs([FromQuery] FindVIPs parameters)
    {
        try
        {
            var getVIPs = new GetVIPsQuery((parameters.Limit, parameters.Offset));
            var (vips, total) = await _mediator.Send(getVIPs);
            var vipGetApiList = vips.Select(vip => new VIPGetAPI(vip));
            return Ok(new VIPsAPI(vipGetApiList.ToArray(), total));
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