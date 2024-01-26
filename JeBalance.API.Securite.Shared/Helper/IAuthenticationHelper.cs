using JeBalance.API.Securite.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.API.Securite.Shared.Helper;

public interface IAuthenticationHelper
{
    public Task<AuthenticationResult> Login([FromBody] LoginModel model);
}