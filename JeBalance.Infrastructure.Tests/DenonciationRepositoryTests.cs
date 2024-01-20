using JeBalance.Architecture.SQLite.Repositories;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.Tests;

public class DenonciationRepositoryTests : RepositoryTest
{
    private const TypeDelit _typeDelit = TypeDelit.EvasionFiscale;
    private const string _paysEvasion = "Suisse";
    private const int _informateurId = 1;
    private const int _suspectId = 1;

    private readonly DenonciationRepositorySQLite _repository;

    public DenonciationRepositoryTests()
    {
        _repository = new DenonciationRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var guid = await AddDenonciation();
        var result = await _repository.GetOne(guid);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var denonciation = new Denonciation(_typeDelit, _paysEvasion, _informateurId, _suspectId);
        var result = await _repository.Create(denonciation);
        var lastDenonciation = Context.Denonciations.Last();
        Assert.Equal(result, lastDenonciation.Id);
        Assert.Equal(_typeDelit, lastDenonciation.TypeDelit);
        Assert.Equal(_paysEvasion, lastDenonciation.PaysEvasion);
        Assert.Equal(_informateurId, lastDenonciation.IdInformateur);
        Assert.Equal(_informateurId, lastDenonciation.IdSuspect);
    }

    private Task<Guid> AddDenonciation(TypeDelit typeDelit = _typeDelit, string paysEvasion = _paysEvasion,
        int inforamateurId = _informateurId, int suspectId = _suspectId)
    {
        var denonciation = new Denonciation(typeDelit, paysEvasion, inforamateurId, suspectId);
        return _repository.Create(denonciation);
    }
}