using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class InformateurRepositorySQLite : InformateurRepository
{
    private readonly DatabaseContext _context;

    public InformateurRepositorySQLite(DatabaseContext context)
    {
        _context = context;
    }

    public Task<(IEnumerable<Informateur> Results, int Total)> Find(int limit, int offset,
        Specification<Informateur> specification)
    {
        throw new NotImplementedException();
    }

    public async Task<Informateur> GetOne(int id)
    {
        var informateur = await _context.Informateurs.FirstAsync(informateur => id.Equals(informateur.Id));
        return informateur.ToDomain();
    }

    public async Task<int> Create(Informateur informateur)
    {
        var informateurToSave = informateur.ToSQLite();
        await _context.AddAsync(informateurToSave);
        await _context.SaveChangesAsync();
        return informateurToSave.Id;
    }

    public async Task<int> Update(int id, Informateur newInformateur)
    {
        var informateurToUpdate = await _context.Informateurs.FirstAsync(informateur => informateur.Id == id);
        if (informateurToUpdate == null) throw new KeyNotFoundException("L'informateur n'a pas été trouvé");

        informateurToUpdate.Nom = newInformateur.Nom;
        informateurToUpdate.Prenom = newInformateur.Prenom;
        informateurToUpdate.Adresse = newInformateur.Adresse;
        informateurToUpdate.EstCalomniateur = newInformateur.EstCalomniateur;

        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var informateurToDelete =
                await _context.Informateurs.FirstOrDefaultAsync(informateur => informateur.Id == id);

            if (informateurToDelete == null)
                return false;

            _context.Remove(informateurToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Informateur?> FindOne(Specification<Informateur> specification)
    {
        var informateur = await _context.Informateurs
            .Apply(specification.ToSQLiteExpression<Informateur, InformateurSQLite>()).FirstOrDefaultAsync();
        return informateur?.ToDomain();
    }
}