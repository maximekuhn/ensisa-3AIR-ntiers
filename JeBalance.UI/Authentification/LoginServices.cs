using System.Text.Json;
using JeBalance.API.Securite.Shared.Model;

namespace JeBalance.UI.Authentification;

public class LoginServices : UserAccountService<UserSession?, LoginModel>
{
    private readonly string _interneBaseUrl;
    private readonly string _secreteBaseUrl;
    private const string Controller = "Authenticate";

    public LoginServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _interneBaseUrl = configuration["ApiInterne:BaseUrl"] ??
                           throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
        _secreteBaseUrl = configuration["ApiSecrete:BaseUrl"] ??
                          throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public Task<UserSession?> LoginIntenreAsync(LoginModel data)
    {
        var request = MakeRequest($"{_interneBaseUrl}/{Controller}/login", data);
        var session = SendRequest(request);
        return session;
    }

    public Task<UserSession?> LoginSecreteAsync(LoginModel data)
    {
        var request = MakeRequest($"{_secreteBaseUrl}/{Controller}/login", data);
        var session = SendRequest(request);
        return session;
    }
}