using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class InformateurRepositoryDriver: InformateurRepository
{
    public List<Informateur> Informateurs { get; set; }

    public InformateurRepositoryDriver()
    {
        Informateurs = new List<Informateur>();
    }

    private int _lastId = 0;
    
    public Task<IEnumerable<Informateur>> Find(int limit, int offset, Specification<Informateur> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Informateur> GetOne(int id)
    {
        foreach (var informateur in Informateurs)
        {
            if (informateur.Id == id) return Task.FromResult(informateur);
        }
        return null;
    }

    public Task<int> Create(Informateur informateur)
    {
        informateur.Id = ++_lastId;
        Informateurs.Add(informateur);
        return Task.FromResult(_lastId);
    }

    public Task<int> Update(int id, Informateur T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Informateur?> FindOne(Specification<Informateur> specification)
    {
        return Task.FromResult<Informateur?>(null);
    }
}