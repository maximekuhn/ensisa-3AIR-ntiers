using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class ReponseRepositoryDriver : ReponseRepository
{
    public List<Reponse> Reponses { get; set; } = new();

    public Task<(IEnumerable<Reponse> Results, int Total)> Find(int limit, int offset,
        Specification<Reponse>? specification)
    {
        throw new NotImplementedException();
    }

    public Task<Reponse> GetOne(int id)
    {
        return Task.FromResult(Reponses.First(reponse => id == reponse.Id));
    }

    public Task<int> Create(Reponse reponse)
    {
        if (Reponses.Count > 0)
            reponse.Id = Reponses.Last().Id + 1;
        else
            reponse.Id = 1;
        Reponses.Add(reponse);
        return Task.FromResult(Reponses.Last().Id);
    }

    public Task<int> Update(int id, Reponse T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}