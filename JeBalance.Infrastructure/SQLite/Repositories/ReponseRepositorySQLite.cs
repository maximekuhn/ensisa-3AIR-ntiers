using JeBalance.Architecture.SQLite.Model;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Architecture.SQLite.Repositories;

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
        await _context.AddAsync(reponse);
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
        throw new NotImplementedException();
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