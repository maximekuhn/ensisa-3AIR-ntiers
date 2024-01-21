using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class InformateurRepositorySQLite : InformateurRepository
{
    private readonly DatabaseContext _context;

    public InformateurRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<(IEnumerable<Informateur> Results, int Total)> Find(int limit, int offset,
        Specification<Informateur> specification)
    {
        throw new NotImplementedException();
    }

    public async Task<Informateur> GetOne(int id)
    {
        var informateur = await _context.Informateurs.FirstAsync(informateur => id.Equals(informateur.Id));
        return informateur.ToDomain();
    }

    public async Task<int> Create(Informateur informateur)
    {
        var informateurToSave = informateur.ToSQLite();
        await _context.AddAsync(informateurToSave);
        await _context.SaveChangesAsync();
        return informateurToSave.Id;
    }

    public async Task<int> Update(int id, Informateur informateur)
    {
        var informateurToUpdate = await _context.Informateurs.FindAsync(id);
        if (informateurToUpdate == null) throw new KeyNotFoundException("L'informateur n'existe pas");

        _context.Informateurs.Update(informateurToUpdate);
        await _context.SaveChangesAsync();

        return informateurToUpdate.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var informateur = await _context.Informateurs.FindAsync(id);
        if (informateur == null) return false;

        _context.Informateurs.Remove(informateur);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Informateur?> FindOne(Specification<Informateur> specification)
    {
        var informateur = await _context.Informateurs
            .Apply(specification.ToSQLiteExpression<Informateur, InformateurSQLite>()).FirstOrDefaultAsync();
        return informateur?.ToDomain();
    }
}