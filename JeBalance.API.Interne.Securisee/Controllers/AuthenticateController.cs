using JeBalance.API.Securite.Shared.Helper;
using JeBalance.API.Securite.Shared.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Interne.Securisee.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticationHelper _authenticationHelper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticateController(IAuthenticationHelper authenticationHelper, RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _authenticationHelper = authenticationHelper;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var authenticationResult = await _authenticationHelper.Login(model);
        if (!authenticationResult.Success) return Unauthorized();
        return Ok(new
        {
            username = authenticationResult.Username,
            role = authenticationResult.Role,
            token = authenticationResult.Token,
            expiration = authenticationResult.Expiration
        });
    }

    [HttpPost]
    [Route("register-administrateur-fiscal")]
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