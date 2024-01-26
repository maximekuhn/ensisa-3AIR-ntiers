using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Securite.Shared;

public interface IAuthenticationHelper
{
    public Task<AuthenticationResult> Login([FromBody] LoginModel model);
}