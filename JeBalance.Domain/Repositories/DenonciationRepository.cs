using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface DenonciationRepository : Repository<Denonciation, Guid>
{
    public Task<bool> SetReponseId(Guid denonciationId, int reponseId);
}