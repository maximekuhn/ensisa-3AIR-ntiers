using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class ReponseRepositorySQLite : ReponseRepository
{
    private readonly DatabaseContext _context;

    public ReponseRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Reponse reponse)
    {
        var reponseToSave = reponse.ToSQLite();
        await _context.AddAsync(reponseToSave);
        await _context.SaveChangesAsync();
        return reponseToSave.Id;
    }

    public Task<(IEnumerable<Reponse> Results, int Total)> Find(int limit, int offset,
        Specification<Reponse> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Reponse> GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(int id, Reponse reponse)
    {
        var reponseToUpdate = await _context.Reponses.FindAsync(id);
        if (reponseToUpdate == null) throw new KeyNotFoundException("Reponse not found");

        _context.Reponses.Update(reponseToUpdate);
        await _context.SaveChangesAsync();

        return reponseToUpdate.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var reponse = await _context.Reponses.FindAsync(id);
        if (reponse == null) return false;

        _context.Reponses.Remove(reponse);
        await _context.SaveChangesAsync();

        return true;
    }
}