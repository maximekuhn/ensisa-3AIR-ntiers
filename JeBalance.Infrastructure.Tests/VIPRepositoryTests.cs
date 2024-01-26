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
    public Task ShouldFindAsync()
    {
        return Task.CompletedTask;
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
    public async Task ShouldUpdateAsync()
    {
        var id = await AddVIP();
        var newNom = "Updated Nom";
        var newPrenom = "Updated Prenom";
        var newAdresse = new Adresse(new NumeroVoie(20), new NomVoie("Updated nom de voie"),
            new CodePostal(68700), new NomCommune("Updated commune"));
        var updatedVIP = new VIP(newNom, newPrenom, newAdresse);
        await _repository.Update(id, updatedVIP);
        var vip = Context.VIPs.Single(vip => vip.Id == id);
        Assert.Equal(newNom, vip.Nom);
        Assert.Equal(newPrenom, vip.Prenom);
        Assert.Equal(newAdresse, vip.Adresse);
    }

    [Fact]
    public async Task ShouldDeleteAsync()
    {
        var id = await AddVIP();
        var result = await _repository.Delete(id);
        Assert.True(result);
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