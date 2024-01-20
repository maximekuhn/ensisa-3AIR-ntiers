using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class SuspectRepositoryDriver: SuspectRepository
{
    public List<Suspect> Suspects;
    
    private int _lastId = 0;

    public SuspectRepositoryDriver()
    {
        Suspects = new List<Suspect>();
    }

    public Task<IEnumerable<Suspect>> Find(int limit, int offset, Specification<Suspect> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Suspect> GetOne(int id)
    {
        foreach (var suspect in Suspects)
        {
            if (suspect.Id == id) return Task.FromResult(suspect);
        }
        return null;
    }

    public Task<int> Create(Suspect suspect)
    {
        suspect.Id = ++_lastId;
        Suspects.Add(suspect);
        return Task.FromResult<int>(_lastId);
    }

    public Task<int> Update(int id, Suspect T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Suspect?> FindOne(Specification<Suspect> specification)
    {
        return Task.FromResult<Suspect?>(null);
    }
}