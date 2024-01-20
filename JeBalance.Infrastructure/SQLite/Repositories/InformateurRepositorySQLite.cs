using JeBalance.Architecture.SQLite.Model;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.Repositories;

namespace JeBalance.Architecture.SQLite.Repositories;

public class InformateurRepositorySQLite : InformateurRepository
{
    private readonly DatabaseContext _context;

    public InformateurRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Informateur>> Find(int limit, int offset, Specification<Informateur> specification)
    {
        throw new NotImplementedException();
    }

    public Task<Informateur> GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Create(Informateur informateur)
    {
        var informateurToSave = informateur.ToSQLite();
        await _context.AddAsync(informateurToSave);
        await _context.SaveChangesAsync();
        return informateurToSave.Id;
    }

    public Task<int> Update(int id, Informateur T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Informateur?> FindOne(FindPersonneSpecification specification)
    {
        return null;
    }
}