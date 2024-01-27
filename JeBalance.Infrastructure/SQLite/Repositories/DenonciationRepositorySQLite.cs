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

    public Task<Guid> Update(Guid id, Denonciation denonciation)
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

    public async Task<(IEnumerable<Denonciation> Results, int Total)> GetSortedDenonciationsNonTraitees(int limit, int offset, FindDenonciationsNonTraiteesSpecification specification)
    {
        // Todo : sa marche pt etre utiliser une autre manière
        
        // Récupérer les IDs des suspects qui sont des VIPs
        var vipSuspectIds = await _context.Suspects
            .Join(_context.VIPs,
                suspect => new { suspect.Nom, suspect.Prenom, suspect.Adresse },
                vip => new { vip.Nom, vip.Prenom, vip.Adresse },
                (suspect, vip) => suspect.Id)
            .ToListAsync();

        // Filtrer les dénonciations pour exclure celles concernant des suspects VIPs
        var filteredQuery = _context.Denonciations
            .Apply(specification.ToSQLiteExpression<Denonciation, DenonciationSQLite>())
            .Where(d => !vipSuspectIds.Contains(d.IdSuspect));

        // Compter le total des résultats après filtrage
        var total = await filteredQuery.CountAsync();

        // Appliquer le tri et la pagination
        var results = await filteredQuery
            .OrderBy(d => d.Horodatage)
            .Skip(offset)
            .Take(limit)
            .Select(d => d.ToDomain()) // Assurez-vous que la méthode ToDomain() convertit correctement les objets SQLite en objets de domaine
            .ToListAsync();

        return (results, total);
    }
}