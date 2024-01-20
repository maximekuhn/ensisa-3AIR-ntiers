using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.Tests;

public class InformateurRepositoryTests : RepositoryTest
{
    private readonly InformateurRepositorySQLite _repository;
    private const int _informateurId = 1;
    private const string _nom = "toto";
    private const string _prenom = "tata";
    private Adresse _adresse = new Adresse(new NumeroVoie(10), new NomVoie("Rue des freres"),
        new CodePostal(68200), new NomCommune("Mulhouse"));

    public InformateurRepositoryTests() : base()
    {
        _repository = new InformateurRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldCreate()
    {
        var informateur = new Informateur(_nom, _prenom, _adresse, _informateurId);
        var result = await _repository.Create(informateur);
        Assert.Equal(Context.Informateurs.Last().Id, _informateurId);
        Assert.Equal(Context.Informateurs.Last().Nom, _nom);
        Assert.Equal(Context.Informateurs.Last().Prenom, _prenom);
    }
}