using JeBalance.API.Publique.Resources;
using JeBalance.Domain.Model;

namespace JeBalance.UI.Data.Services;

public class DenonciationService : ServiceBase<DenonciationAPI>
{
    private const string Controller = "Denonciation";
    
    public DenonciationService(IHttpClientFactory clientFactory) : base(clientFactory, Controller)
    {
    }

    public async Task<Denonciation?> GetDenonciationAsync(Guid id)
    {
        var request = await MakeGetOneRequest(id);
        var denonciation = await SendGetOneRequestDenonciation(request);
        return denonciation;
    }

    public async Task<Guid?> AddDenonciationAsync(DenonciationAPI denonciation)
    {
        var request = await MakeAddRequest(denonciation, "/create");
        var id = await SendAddRequest(request);
        return id;
    }
    
    
}