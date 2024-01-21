using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Repositories;

namespace JeBalance.Infrastructure.Tests;

public class InformateurRepositoryTests : RepositoryTest
{
    private const string _nom = "toto";
    private const string _prenom = "tata";

    private readonly Adresse _adresse = new(new NumeroVoie(10), new NomVoie("Rue des freres"),
        new CodePostal(68200), new NomCommune("Mulhouse"));

    private readonly InformateurRepositorySQLite _repository;

    public InformateurRepositoryTests()
    {
        _repository = new InformateurRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var informateurId = await AddInformateur();
        var result = await _repository.GetOne(informateurId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var informateur = new Informateur(_nom, _prenom, _adresse);
        var informateurId = await _repository.Create(informateur);
        var lastInformateur = Context.Informateurs.Last();
        Assert.Equal(informateurId, lastInformateur.Id);
        Assert.Equal(_nom, lastInformateur.Nom);
        Assert.Equal(_prenom, lastInformateur.Prenom);
        Assert.Equal(_adresse, lastInformateur.Adresse);
    }

    [Fact]
    public async Task ShouldUpdateAsync()
    {
        var id = await AddInformateur();
        var newNom = "Updated Nom";
        var newPrenom = "Updated Prenom";
        var newAdresse = new Adresse(new NumeroVoie(20), new NomVoie("Updated nom de voie"),
            new CodePostal(68700), new NomCommune("Updated commune"));
        var newEstCalomniateur = true;
        var updatedInforamteur = new Informateur(newNom, newPrenom, newAdresse, newEstCalomniateur);
        await _repository.Update(id, updatedInforamteur);
        var informateur = Context.Informateurs.Single(inforamteuer => inforamteuer.Id == id);
        Assert.Equal(newNom, informateur.Nom);
        Assert.Equal(newPrenom, informateur.Prenom);
        Assert.Equal(newAdresse, informateur.Adresse);
    }

    [Fact]
    public async Task ShouldDeleteAsync()
    {
        var id = await AddInformateur();
        var result = await _repository.Delete(id);
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldFindOneAsync()
    {
        var informateurId = await AddInformateur();
        var specification = new FindPersonneSpecification<Informateur>(_nom, _prenom, _adresse);
        var informateur = await _repository.FindOne(specification);
        Assert.Equal(informateurId, informateur.Id);
    }

    private Task<int> AddInformateur(string nom = _nom, string prenom = _prenom)
    {
        var informateur = new Informateur(nom, prenom, _adresse);
        return _repository.Create(informateur);
    }
}