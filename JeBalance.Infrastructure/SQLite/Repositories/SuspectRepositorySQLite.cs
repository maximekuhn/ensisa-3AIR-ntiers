using JeBalance.Architecture.SQLite.Model;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<int> Create(Suspect suspect)
    {
        var suspectToSave = suspect.ToSQLite();
        await _context.AddAsync(suspectToSave);
        await _context.SaveChangesAsync();
        return suspectToSave.Id;
    }

    public Task<int> Update(int id, Suspect T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Suspect?> FindOne(FindPersonneSpecification specification)
    {
        var suspect = await _context.Suspects.FirstAsync(suspect => specification.IsSatisfiedBy(suspect));
        return suspect.ToDomain();
    }
}