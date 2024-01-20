using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface InformateurRepository : Repository<Informateur, int>
{
    public Task<Informateur?> FindOne(Specification<Informateur> specification);
}