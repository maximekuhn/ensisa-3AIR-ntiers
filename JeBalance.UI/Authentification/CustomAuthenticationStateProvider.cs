using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace JeBalance.UI.Authentification;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string SessionKey = "UserSession";
    private readonly ProtectedSessionStorage _sessionStorage;
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSSR = await _sessionStorage.GetAsync<UserSession>(SessionKey);
            var userSession = userSSR.Success
                ? userSSR.Value
                : null;

            if (userSession == null) return new AuthenticationState(_anonymous);

            return new AuthenticationState(userSession.ToClaimsPrincipal());
        }
        catch (Exception)
        {
            return new AuthenticationState(_anonymous);
        }
    }

    public async Task<string> GetJWT()
    {
        try
        {
            var userSSR = await _sessionStorage.GetAsync<UserSession>(SessionKey);
            var userSession = userSSR.Success
                ? userSSR.Value
                : null;

            if (userSession == null) return null;

            return userSession.Token;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task UpdateAuthenticationState(UserSession userSession)
    {
        ClaimsPrincipal claimsPrincipal;

        if (userSession != null)
        {
            await _sessionStorage.SetAsync(SessionKey, userSession);
            claimsPrincipal = userSession.ToClaimsPrincipal();
        }
        else
        {
            await _sessionStorage.DeleteAsync(SessionKey);
            claimsPrincipal = _anonymous;
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
}