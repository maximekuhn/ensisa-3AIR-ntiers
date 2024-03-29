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

    public async Task<(IEnumerable<Denonciation> Results, int Total)> GetSortedDenonciationsNonTraitees(int limit,
        int offset,
        FindDenonciationsNonTraiteesSpecification specification)
    {
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
            .Select(d => d.ToDomain())
            .ToListAsync();

        return (results, total);
    }

    public async Task<bool> Has2ReponsesDeTypeRejet(int informateurId)
    {
        // TODO: optimiser la requête pour ne récupérer que les résultats intéressant depuis la base
        // Il y a peut être un problème de configuration de relations des entités EF qui nous
        // empêche de le faire correctement pour le moment

        // Récupérer les Id des réponses dont la dénonciation avait pour informateur informateurId
        var denonciations = await _context.Denonciations
            .ToListAsync();

        var reponsesIdForInformateurId = denonciations
            .AsEnumerable()
            .Where(denonciation => denonciation.IdInformateur == informateurId)
            .Where(denonciation => denonciation.ReponseId != null)
            .Select(denonciation => denonciation.ReponseId);

        var reponses = await _context.Reponses
            .Where(reponse => reponse.TypeReponse == TypeReponse.Rejet)
            .Where(reponse => reponsesIdForInformateurId.Contains(reponse.Id))
            .ToListAsync();

        return reponses.Count() >= 2;
    }
}