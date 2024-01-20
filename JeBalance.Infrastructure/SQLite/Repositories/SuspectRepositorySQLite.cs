using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class SuspectRepositorySQLite : SuspectRepository
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

    public async Task<Suspect> GetOne(int id)
    {
        var suspect = await _context.Suspects.FirstAsync(suspect => id.Equals(suspect.Id));
        return suspect.ToDomain();
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

    public async Task<Suspect?> FindOne(Specification<Suspect> specification)
    {
        var suspect = await _context.Suspects.Apply(specification.ToSQLiteExpression<Suspect, SuspectSQLite>())
            .FirstOrDefaultAsync();
        return suspect?.ToDomain();
    }
}