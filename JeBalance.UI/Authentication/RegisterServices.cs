using JeBalance.API.Securite.Shared.Model;
using JeBalance.UI.Data.Services.Error;

namespace JeBalance.UI.Authentification;

public class RegisterServices : UserAccountService<Response, RegisterModel>
{
    private const string Controller = "Authenticate";
    private readonly string _interneBaseUrl;
    private readonly string _secreteBaseUrl;

    public RegisterServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _interneBaseUrl = configuration["ApiInterne:BaseUrl"] ??
                          throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
        _secreteBaseUrl = configuration["ApiSecrete:BaseUrl"] ??
                          throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public Task<RequestResult<Response?>> RegisterInterneAsync(RegisterModel data)
    {
        var request = MakeRequest($"{_interneBaseUrl}/{Controller}/register-administrateur-fiscal", data);
        var res = SendRequest(request);
        return res;
    }

    public Task<RequestResult<Response?>> RegisterSecreteAsync(RegisterModel data)
    {
        var request = MakeRequest($"{_secreteBaseUrl}/{Controller}/register-administrateur", data);
        var res = SendRequest(request);
        return res;
    }
}