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

    public async Task<Reponse> GetOne(int id)
    {
        var reponse = await _context.Reponses.FindAsync(id);
        if (reponse == null) throw new KeyNotFoundException("Cette réponse n'existe pas");

        return reponse;
    }

    public Task<int> Update(int id, Reponse reponse)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}