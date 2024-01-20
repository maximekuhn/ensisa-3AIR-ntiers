using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.Tests;

public class SuspectRepositoryTests : RepositoryTest
{
    private const int _suspectId = 1;
    private const string _nom = "toto";
    private const string _prenom = "tata";
    private readonly SuspectRepositorySQLite _repository;

    private readonly Adresse _adresse = new(new NumeroVoie(10), new NomVoie("Rue des freres"),
        new CodePostal(68200), new NomCommune("Mulhouse"));

    public SuspectRepositoryTests()
    {
        _repository = new SuspectRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var id = await AddSuspect();
        var result = await _repository.GetOne(id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var suspect = new Suspect(_nom, _prenom, _adresse, _suspectId);
        var result = await _repository.Create(suspect);
        var lastSuspect = Context.Suspects.Last();
        Assert.Equal(lastSuspect.Id, result);
        Assert.Equal(lastSuspect.Nom, _nom);
        Assert.Equal(lastSuspect.Prenom, _prenom);
        Assert.Equal(lastSuspect.Adresse, _adresse);
    }

    [Fact]
    public async Task ShouldFindOneAsync()
    {
        var goodId = await AddSuspect();
        var specification = new FindPersonneSpecification<Suspect>(_nom, _prenom, _adresse);
        var result = await _repository.FindOne(specification);
        Assert.Equal(goodId, result.Id);
    }
    
    private Task<int> AddSuspect(int suspectId = _suspectId, string nom = _nom, string prenom = _prenom)
    {
        var suspect = new Suspect(nom, prenom, _adresse, suspectId);
        return _repository.Create(suspect);
    }
}