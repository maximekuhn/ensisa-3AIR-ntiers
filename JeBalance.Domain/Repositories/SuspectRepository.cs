using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface SuspectRepository : Repository<Suspect, int>
{
    public Task<Suspect?> FindOne(Specification<Suspect> specification);
}