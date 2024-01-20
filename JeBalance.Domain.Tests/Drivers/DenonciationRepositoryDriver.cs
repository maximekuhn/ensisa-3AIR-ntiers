using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class DenonciationRepositoryDriver: DenonciationRepository
{
    public List<Denonciation> Denonciations { get; }

    public DenonciationRepositoryDriver()
    {
        Denonciations = new List<Denonciation>();
    }

    public Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Denonciation> GetOne(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(Denonciation denonciation)
    {
        Denonciations.Add(denonciation);
        return Task.FromResult(Denonciations.Last().Id);
    }

    public Task<Guid> Update(Guid id, Denonciation T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}