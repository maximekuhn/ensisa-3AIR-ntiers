using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class DenonciationRepositoryDriver : DenonciationRepository
{
    public DenonciationRepositoryDriver()
    {
        Denonciations = new List<Denonciation>();
        Suspects = new List<Suspect>();
        VIPs = new List<VIP>();
    }

    public List<Denonciation> Denonciations { get; }
    public List<Suspect> Suspects { get; }
    public List<VIP> VIPs { get; }

    public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset,
        Specification<Denonciation>? specification)
    {
        var denonciations = Denonciations.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
        return Task.FromResult((denonciations, Denonciations.Count));
    }

    public Task<Denonciation> GetOne(Guid id)
    {
        return Task.FromResult(Denonciations.First(denonciation => id.Equals(denonciation.Id)));
    }

    public Task<Guid> Create(Denonciation denonciation)
    {
        Denonciations.Add(denonciation);
        return Task.FromResult(Denonciations.Last().Id);
    }

    public Task<Guid> Update(Guid id, Denonciation updatedDenonciation)
    {
        var denonciation = Denonciations.Single(denonciation => id == denonciation.Id);
        var index = Denonciations.IndexOf(denonciation);
        Denonciations[index] = new Denonciation(
            id,
            updatedDenonciation.TypeDelit,
            updatedDenonciation.PaysEvasion,
            updatedDenonciation.InformateurId,
            updatedDenonciation.SuspectId,
            updatedDenonciation.ReponseId
        );
        return Task.FromResult(id);
    }

    public Task<bool> Delete(Guid id)
    {
        Denonciations.RemoveAll(denonciation => id == denonciation.Id);
        return Task.FromResult(true);
    }

    public Task<bool> SetReponseId(Guid denonciationId, int reponseId)
    {
        var denonciation = Denonciations.FirstOrDefault(d => d.Id == denonciationId);

        if (denonciation != null)
        {
            denonciation.ReponseId = reponseId;
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    public Task<(IEnumerable<Denonciation> Results, int Total)> GetSortedDenonciationsNonTraitees(int limit,
        int offset, FindDenonciationsNonTraiteesSpecification specification)
    {   
        // Récupérer les IDs des suspects qui sont des VIPs
        var vipSuspectIds = Suspects
            .Where(suspect => VIPs.Any(vip => vip.Nom == suspect.Nom && vip.Prenom == suspect.Prenom && vip.Adresse == suspect.Adresse))
            .Select(suspect => suspect.Id)
            .ToList();

        // Filtrer les dénonciations pour exclure celles concernant des suspects VIPs
        var filteredDenonciations = Denonciations
            .Where(d => specification.IsSatisfiedBy(d) && !vipSuspectIds.Contains(d.SuspectId))
            .ToList();

        // Compter le total des résultats après filtrage
        var total = filteredDenonciations.Count;

        // Appliquer le tri et la pagination
        var results = filteredDenonciations
            .OrderBy(d => d.Horodatage)
            .Skip(offset)
            .Take(limit);

        return Task.FromResult((results, total));
    }
}