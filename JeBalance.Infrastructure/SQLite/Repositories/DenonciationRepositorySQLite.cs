using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;
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

    public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset,
        Specification<Denonciation>? specification)
    {
        var results = _context.Denonciations
            .Apply(specification.ToSQLiteExpression<Denonciation, DenonciationSQLite>())
            .Skip(offset)
            .Take(limit)
            .AsEnumerable()
            .Select(denonciation => denonciation.ToDomain());
        

        return Task.FromResult((results, _context.Denonciations.Count()));
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
        throw new NotImplementedException();
    }


    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var denonciationToDelete =
                await _context.Denonciations.FirstOrDefaultAsync(denonciation => denonciation.Id == id);

            if (denonciationToDelete == null)
                return false;

            _context.Remove(denonciationToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SetReponseId(Guid denonciationId, int reponseId)
    {
        var denonciationToUpdate = await _context.Denonciations.FindAsync(denonciationId);
        if (denonciationToUpdate == null) return false;

        denonciationToUpdate.ReponseId = reponseId;
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<(IEnumerable<Denonciation> Results, int Total)> GetSortDenonsiationsNonTraitee(int limit, int offset, FindDenonciationsNonTraiteesSpecification specification)
    {
        var query = _context.Denonciations
            .Apply(specification.ToSQLiteExpression<Denonciation, DenonciationSQLite>());
        
        var sortedQuery = query.OrderByDescending(d => d.Horodatage);
        
        var results = sortedQuery
            .Skip(offset)
            .Take(limit)
            .AsEnumerable()
            .Select(denonciation => denonciation.ToDomain());

        return Task.FromResult((results, _context.Denonciations.Count()));
    }
}