using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface VIPRepository : Repository<VIP, int>
{
    public Task<VIP?> FindOne(Specification<VIP> specification);
}