using JeBalance.Domain.Model;
using JeBalance.Infrastructure.SQLite.Repositories;

namespace JeBalance.Infrastructure.Tests;

public class ReponseRepositoryTests : RepositoryTest
{
    private const TypeReponse _typeReponse = TypeReponse.Confirmation;
    private const double _retribution = 22.33;
    private readonly ReponseRepositorySQLite _repository;

    public ReponseRepositoryTests()
    {
        _repository = new ReponseRepositorySQLite(Context);
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        var reponse = new Reponse(_typeReponse, _retribution);
        var reponseId = await _repository.Create(reponse);
        var lastReponse = Context.Reponses.Last();
        Assert.Equal(reponseId, lastReponse.Id);
        Assert.Equal(_typeReponse, lastReponse.TypeReponse);
        Assert.Equal(_retribution, lastReponse.Retribution);
    }

    [Fact]
    public async Task ShouldFindAsync()
    {
        // TODO
    }

    [Fact]
    public async Task ShouldGetOneAsync()
    {
        var reponseId = await AddReponse();
        var result = await _repository.GetOne(reponseId);
        Assert.NotNull(result);
    }

    private Task<int> AddReponse(TypeReponse typeReponse = _typeReponse, double retribution = _retribution)
    {
        var reponse = new Reponse(typeReponse, retribution);
        return _repository.Create(reponse);
    }
}