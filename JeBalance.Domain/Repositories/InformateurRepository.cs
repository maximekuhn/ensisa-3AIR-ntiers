using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;

namespace JeBalance.Domain.Repositories;

public interface InformateurRepository : Repository<Informateur, int>
{
    public Task<Informateur?> FindOne(FindPersonneSpecification specification);
}