using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.Repositories;

namespace JeBalance.Architecture.SQLite.Repositories;

public class SuspectRepositorySQLite: SuspectRepository
{
    private readonly DatabaseContext _context;

    public SuspectRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Suspect>> Find(int limit, int offset, Specification<Suspect> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Suspect> GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(Suspect T)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(int id, Suspect T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Suspect?> FindOne(FindPersonneSpecification specification)
    {
        throw new NotImplementedException();
    }
}