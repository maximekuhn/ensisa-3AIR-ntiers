using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Repositories;

namespace JeBalance.Infrastructure.Tests;

public class VIPRepositoryTests : RepositoryTest
{
    private const string _nom = "vipNom";
    private const string _prenom = "vipPrenom";

    private readonly Adresse _adresse = new(new NumeroVoie(10), new NomVoie("Rue des vip"),
        new CodePostal(68200), new NomCommune("Vip"));

    private readonly VIPRepositorySQLite _repository;

    public VIPRepositoryTests()
    {
        _repository = new VIPRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var vipId = await AddVIP();
        var result = await _repository.GetOne(vipId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var vip = new VIP(_nom, _prenom, _adresse);
        var vipId = await _repository.Create(vip);
        var lastVIP = Context.VIPs.Last();
        Assert.Equal(vipId, lastVIP.Id);
        Assert.Equal(_nom, lastVIP.Nom);
        Assert.Equal(_prenom, lastVIP.Prenom);
        Assert.Equal(_adresse, lastVIP.Adresse);
    }

    [Fact]
    public async Task ShouldFindOneAsync()
    {
        var vipId = await AddVIP();
        var specification = new FindPersonneSpecification<VIP>(_nom, _prenom, _adresse);
        var vip = await _repository.FindOne(specification);
        Assert.Equal(vipId, vip.Id);
    }

    private Task<int> AddVIP(string nom = _nom, string prenom = _prenom)
    {
        var vip = new VIP(nom, prenom, _adresse);
        return _repository.Create(vip);
    }
}