using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

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
        Specification<Reponse>? specification)
    {
        var results = _context.Reponses.Apply(specification.ToSQLiteExpression<Reponse, ReponseSQLite>()).Skip(offset)
            .Take(limit).AsEnumerable().Select(reponse => reponse.ToDomain());

        return Task.FromResult((results, _context.Reponses.Count()));
    }

    public async Task<Reponse> GetOne(int id)
    {
        var reponse = await _context.Reponses.FirstOrDefaultAsync(reponse => id.Equals(reponse.Id));
        if (reponse == null) throw new KeyNotFoundException("Cette réponse n'existe pas");

        return reponse.ToDomain();
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