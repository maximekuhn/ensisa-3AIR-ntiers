using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class VIPRepositorySQLite : VIPRepository
{
    private readonly DatabaseContext _context;

    public VIPRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<(IEnumerable<VIP> Results, int Total)> Find(int limit, int offset,
        Specification<VIP> specification)
    {
        throw new NotImplementedException();
    }

    public async Task<VIP> GetOne(int id)
    {
        var vip = await _context.VIPs.FirstAsync(vip => id.Equals(vip.Id));
        return vip.ToDomain();
    }

    public async Task<int> Create(VIP vip)
    {
        var vipToSave = vip.ToSQLite();
        await _context.AddAsync(vipToSave);
        await _context.SaveChangesAsync();
        return vipToSave.Id;
    }

    public Task<int> Update(int id, VIP T)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<VIP?> FindOne(Specification<VIP> specification)
    {
        var vip = await _context.VIPs.Apply(specification.ToSQLiteExpression<VIP, VIPsQLite>())
            .FirstOrDefaultAsync();
        return vip?.ToDomain();
    }
}