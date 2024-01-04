using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface DenonciationRepository : Repository<Denonciation>
{
    Task SetStatus(int id, StatutDenonciation nvStatus);
}