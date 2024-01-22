using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class VIPRepositoryDriver : VIPRepository
{
    public VIPRepositoryDriver()
    {
        VIPs = new List<VIP>();
    }

    public List<VIP> VIPs { get; set; }

    public async Task<(IEnumerable<VIP> Results, int Total)> Find(int limit, int offset,
        Specification<VIP>? specification)
    {
        var vips = VIPs.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
        return (vips, VIPs.Count);
    }

    public Task<VIP> GetOne(int id)
    {
        return Task.FromResult(VIPs.First(vip => id.Equals(vip.Id)));
    }

    public Task<int> Create(VIP vip)
    {
        if (VIPs.Count > 0)
            vip.Id = VIPs.Last().Id + 1;
        else
            vip.Id = 1;
        VIPs.Add(vip);
        return Task.FromResult(VIPs.Last().Id);
    }

    public async Task<int> Update(int id, VIP updatedVIP)
    {
        var vip = await GetOne(updatedVIP.Id);
        var index = VIPs.IndexOf(vip);
        VIPs[index] = new VIP(updatedVIP.Nom, updatedVIP.Prenom, updatedVIP.Adresse, vip.Id);
        return id;
    }

    public Task<bool> Delete(int id)
    {
        VIPs.RemoveAll(vip => id.Equals(vip.Id));
        return Task.FromResult(true);
    }

    public Task<VIP?> FindOne(Specification<VIP> specification)
    {
        return Task.FromResult(VIPs.FirstOrDefault(specification.IsSatisfiedBy));
    }
}