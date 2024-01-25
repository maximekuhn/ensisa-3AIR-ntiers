using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;

namespace JeBalance.Domain.Repositories;

public interface DenonciationRepository : Repository<Denonciation, Guid>
{
    public Task<bool> SetReponseId(Guid denonciationId, int reponseId);

    public Task<(IEnumerable<Denonciation> Results, int Total)> GetSortDenonsiationsNonTraitee(int limit, int offset,
        FindDenonciationsNonTraiteesSpecification specification);
}