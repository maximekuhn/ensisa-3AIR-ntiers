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

    public async Task<int> Update(int id, VIP newVIP)
    {
        var vipToUpdate = await _context.VIPs.FirstAsync(vip => vip.Id == id);
        if (vipToUpdate == null)
            throw new KeyNotFoundException("Le VIP n'a pas été trouvé");

        vipToUpdate.Nom = newVIP.Nom;
        vipToUpdate.Prenom = newVIP.Prenom;
        vipToUpdate.Adresse = newVIP.Adresse;

        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var vipToDelete = await _context.VIPs.FirstOrDefaultAsync(vip => vip.Id == id);

            if (vipToDelete == null)
                return false;

            _context.Remove(vipToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<VIP?> FindOne(Specification<VIP> specification)
    {
        var vip = await _context.VIPs.Apply(specification.ToSQLiteExpression<VIP, VIPsQLite>())
            .FirstOrDefaultAsync();
        return vip?.ToDomain();
    }
}