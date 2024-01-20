using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

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

    public async Task<Denonciation> GetOne(Guid id)
    {
        var denonciation = await _context.Denonciations.FirstAsync(denonciation => id.Equals(denonciation.Id));
        return denonciation.ToDomain();
    }

    public async Task<Guid> Create(Denonciation denonciation)
    {
        var denonciationToSave = denonciation.ToSQLite();
        await _context.AddAsync(denonciationToSave);
        await _context.SaveChangesAsync();
        return denonciationToSave.Id;
    }

    public Task<Guid> Update(Guid id, Denonciation denonciation)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}