using JeBalance.API.Securite.Shared.Helper;
using JeBalance.API.Securite.Shared.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Secrete.Securisee.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticationHelper _authenticationHelper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IAuthenticationHelper authenticationHelper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _authenticationHelper = authenticationHelper;
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
    [Route("register-administrateur")]
    public async Task<IActionResult> RegisterAdministrateur([FromBody] RegisterModel model)
    {
        var adminExists = await _userManager.FindByEmailAsync(model.Email);
        if (adminExists != null)
            return StatusCode(StatusCodes.Status409Conflict,
                new Response
                    { Status = "Error", Message = "An administrateur with the same email already exists !" });

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
                    Message = "Administrateur creation failed! Please check user details and try again."
                });


        if (!await _roleManager.RoleExistsAsync(UserRoles.Administrateur))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Administrateur));

        if (await _roleManager.RoleExistsAsync(UserRoles.Administrateur))
            await _userManager.AddToRoleAsync(admin, UserRoles.Administrateur);

        return Ok(new Response { Status = "Success", Message = "Administrateur created successfully" });
    }
}