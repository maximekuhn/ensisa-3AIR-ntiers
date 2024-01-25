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
    }

    public List<Denonciation> Denonciations { get; }

    public async Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset,
        Specification<Denonciation>? specification)
    {
        var denonciations = Denonciations.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
        return (denonciations, Denonciations.Count);
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

    public async Task<(IEnumerable<Denonciation> Results, int Total)> GetSortDenonsiationsNonTraitee(int limit,
        int offset, FindDenonciationsNonTraiteesSpecification specification)
    {
        var query = Denonciations.Where(specification.IsSatisfiedBy);
        var sortedQuery = query.OrderBy(d => d.Horodatage);
        var denonciations = sortedQuery.Skip(offset).Take(limit);

        return (denonciations, Denonciations.Count);
    }
}