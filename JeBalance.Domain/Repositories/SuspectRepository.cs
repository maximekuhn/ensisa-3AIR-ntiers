using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;

namespace JeBalance.Domain.Repositories;

public interface SuspectRepository : Repository<Suspect>
{
    public Task<Suspect?> FindOne(FindPersonneSpecification specification);
}