using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JeBalance.API.Interne.Securisee.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JeBalance.API.Interne.Securisee.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles) authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var token = GetToken(authClaims);

            return Ok(new
            {
                username = user.UserName,
                role = userRoles.FirstOrDefault(),
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        return Unauthorized();
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

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            _configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}