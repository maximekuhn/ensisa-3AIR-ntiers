using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface DenunciationRepository : Repository<Denunciation>
{
    Task SetStatus(int id, DenunciationStatus newStatus);
}