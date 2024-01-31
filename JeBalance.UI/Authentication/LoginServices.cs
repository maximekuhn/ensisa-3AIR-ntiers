using JeBalance.API.Securite.Shared.Model;
using JeBalance.UI.Data.Services.Error;

namespace JeBalance.UI.Authentification;

public class LoginServices : UserAccountService<UserSession?, LoginModel>
{
    private const string Controller = "Authenticate";
    private readonly string _interneBaseUrl;
    private readonly string _secreteBaseUrl;

    public LoginServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _interneBaseUrl = configuration["ApiInterne:BaseUrl"] ??
                          throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
        _secreteBaseUrl = configuration["ApiSecrete:BaseUrl"] ??
                          throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public Task<RequestResult<UserSession?>> LoginIntenreAsync(LoginModel data)
    {
        var request = MakeRequest($"{_interneBaseUrl}/{Controller}/login", data);
        var session = SendRequest(request);
        return session;
    }

    public Task<RequestResult<UserSession?>> LoginSecreteAsync(LoginModel data)
    {
        var request = MakeRequest($"{_secreteBaseUrl}/{Controller}/login", data);
        var session = SendRequest(request);
        return session;
    }
}