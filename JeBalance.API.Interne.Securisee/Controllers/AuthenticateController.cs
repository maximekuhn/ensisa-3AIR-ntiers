using JeBalance.API.Interne.Securisee.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Interne.Securisee.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost("register-admin-fiscal")]
    public async Task<IActionResult> RegisterAdministrateurFiscal([FromBody] RegisterModel model)
    {
        var adminExists = await _userManager.FindByEmailAsync(model.Email);
        if (adminExists != null)
            return StatusCode(StatusCodes.Status409Conflict,
                new Response
                    { Status = "Error", Message = "An administrateur fiscal with the same email already exists !" });

        var admin = new ApplicationUser
        {
            UserName = model.Username,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        var result = await _userManager.CreateAsync(admin, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                {
                    Status = "Error",
                    Message = "Administrateur fiscal creation failed! Please check user details and try again."
                });


        if (!await _roleManager.RoleExistsAsync(UserRoles.AdministrateurFiscale))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.AdministrateurFiscale));

        if (await _roleManager.RoleExistsAsync(UserRoles.AdministrateurFiscale))
            await _userManager.AddToRoleAsync(admin, UserRoles.AdministrateurFiscale);
            
        return Ok(new Response { Status = "Success", Message = "Administrateur fiscal created successfully" });
    }
}