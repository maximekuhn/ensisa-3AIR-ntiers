using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.Tests;

public class InformateurRepositoryTests : RepositoryTest
{
    private const int _informateurId = 1;
    private const string _nom = "toto";
    private const string _prenom = "tata";
    private readonly InformateurRepositorySQLite _repository;

    private readonly Adresse _adresse = new(new NumeroVoie(10), new NomVoie("Rue des freres"),
        new CodePostal(68200), new NomCommune("Mulhouse"));

    public InformateurRepositoryTests()
    {
        _repository = new InformateurRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var id = await AddInformateur();
        var result = await _repository.GetOne(id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var informateur = new Informateur(_nom, _prenom, _adresse, _informateurId);
        var result = await _repository.Create(informateur);

        var lastInformateur = Context.Informateurs.Last();
        Assert.Equal(lastInformateur.Id, result);
        Assert.Equal(lastInformateur.Nom, _nom);
        Assert.Equal(lastInformateur.Prenom, _prenom);
    }

    [Fact]
    public async Task ShouldFindOneAsync()
    {
        var goodId = await AddInformateur();
        var specification = new FindPersonneSpecification<Informateur>(_nom, _prenom, _adresse);
        var result = await _repository.FindOne(specification);
        Assert.Equal(goodId, result.Id);
    }

    private Task<int> AddInformateur(int informateurId = _informateurId, string nom = _nom, string prenom = _prenom)
    {
        var informateur = new Informateur(nom, prenom, _adresse, informateurId);
        return _repository.Create(informateur);
    }
}