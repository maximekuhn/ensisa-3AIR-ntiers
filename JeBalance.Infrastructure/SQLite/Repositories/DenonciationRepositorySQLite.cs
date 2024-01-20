using JeBalance.Architecture.SQLite.Model;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Architecture.SQLite.Repositories;

public class DenonciationRepositorySQLite : DenonciationRepository
{
    private readonly DatabaseContext _context;

    public DenonciationRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Denonciation>> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Denonciation> GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Create(Denonciation denonciation)
    {
        var denonciationToSave = denonciation.ToSQLite();
        await _context.AddAsync(denonciationToSave);
        await _context.SaveChangesAsync();
        return denonciationToSave.Id;
    }

    public Task<Guid> Update(int id, Denonciation denonciation)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}