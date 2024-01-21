using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class DenonciationRepositorySQLite : DenonciationRepository
{
    private readonly DatabaseContext _context;

    public DenonciationRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset,
        Specification<Denonciation> specification)
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

    public async Task<Guid> Update(Guid id, Denonciation denonciation)
    {
        var denonciationToUpdate = await _context.Denonciations.FindAsync(id);
        if (denonciationToUpdate == null) throw new KeyNotFoundException("La dénonciation n'existe pas");

        denonciationToUpdate.ReponseId = denonciation.ReponseId;
        await _context.SaveChangesAsync();

        return denonciationToUpdate.Id;
    }


    public async Task<bool> Delete(Guid id)
    {
        var denonciation = await _context.Denonciations.FindAsync(id);
        if (denonciation == null) return false;

        _context.Denonciations.Remove(denonciation);
        await _context.SaveChangesAsync();

        return true;
    }
}