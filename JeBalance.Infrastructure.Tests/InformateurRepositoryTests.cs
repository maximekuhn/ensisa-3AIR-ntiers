using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.Tests;

public class InformateurRepositoryTests : RepositoryTest
{
    private const int _informateurId = 1;
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
    public async Task ShouldCreateAsync()
    {
        var informateur = new Informateur(_nom, _prenom, _adresse, _informateurId);
        var result = await _repository.Create(informateur);

        var lastInformateur = Context.Informateurs.Last();
        Assert.Equal(lastInformateur.Id, result);
        Assert.Equal(lastInformateur.Nom, _nom);
        Assert.Equal(lastInformateur.Prenom, _prenom);
    }
}