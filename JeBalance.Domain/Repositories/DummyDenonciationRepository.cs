using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

// TODO: move to infra

public class DummyDenonciationRepository : DenonciationRepository
{
    private readonly List<Denonciation> _denonciations = new();

    public Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Denonciation> GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(Denonciation T)
    {
        _denonciations.Add(T);
        return Task.FromResult(12);
    }

    public Task<int> Update(int id, Denonciation T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}