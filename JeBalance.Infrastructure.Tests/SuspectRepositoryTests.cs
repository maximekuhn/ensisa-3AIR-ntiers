using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Repositories;

namespace JeBalance.Infrastructure.Tests;

public class SuspectRepositoryTests : RepositoryTest
{
    private const string _nom = "toto";
    private const string _prenom = "tata";

    private readonly Adresse _adresse = new(new NumeroVoie(10), new NomVoie("Rue des freres"),
        new CodePostal(68200), new NomCommune("Mulhouse"));

    private readonly SuspectRepositorySQLite _repository;

    public SuspectRepositoryTests()
    {
        _repository = new SuspectRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var suspectId = await AddSuspect();
        var result = await _repository.GetOne(suspectId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var suspect = new Suspect(_nom, _prenom, _adresse);
        var suspectId = await _repository.Create(suspect);
        var lastSuspect = Context.Suspects.Last();
        Assert.Equal(suspectId, lastSuspect.Id);
        Assert.Equal(_nom, lastSuspect.Nom);
        Assert.Equal(_prenom, lastSuspect.Prenom);
        Assert.Equal(_adresse, lastSuspect.Adresse);
    }

    [Fact]
    public async Task ShouldUpdateAsync()
    {
        var id = await AddSuspect();
        var newNom = "Updated Nom";
        var newPrenom = "Updated Prenom";
        var newAdresse = new Adresse(new NumeroVoie(20), new NomVoie("Updated nom de voie"),
            new CodePostal(68700), new NomCommune("Updated commune"));
        var updatedSuspect = new Suspect(newNom, newPrenom, newAdresse);
        await _repository.Update(id, updatedSuspect);
        var suspect = Context.Suspects.Single(suspect => suspect.Id == id);
        Assert.Equal(newNom, suspect.Nom);
        Assert.Equal(newPrenom, suspect.Prenom);
        Assert.Equal(newAdresse, suspect.Adresse);
    }

    [Fact]
    public async Task ShouldDeleteAsync()
    {
        var id = await AddSuspect();
        var result = await _repository.Delete(id);
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldFindOneAsync()
    {
        var suspectId = await AddSuspect();
        var specification = new FindPersonneSpecification<Suspect>(_nom, _prenom, _adresse);
        var suspect = await _repository.FindOne(specification);
        Assert.Equal(suspectId, suspect.Id);
    }

    private Task<int> AddSuspect(string nom = _nom, string prenom = _prenom)
    {
        var suspect = new Suspect(nom, prenom, _adresse);
        return _repository.Create(suspect);
    }
}