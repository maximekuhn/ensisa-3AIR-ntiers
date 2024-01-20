using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class InformateurRepositoryDriver : InformateurRepository
{
    public InformateurRepositoryDriver()
    {
        Informateurs = new List<Informateur>();
    }

    public List<Informateur> Informateurs { get; set; }

    public async Task<(IEnumerable<Informateur> Results, int Total)> Find(int limit, int offset,
        Specification<Informateur> specification)
    {
        var informateurs = Informateurs.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
        return (informateurs, Informateurs.Count);
    }

    public Task<Informateur> GetOne(int id)
    {
        return Task.FromResult(Informateurs.First(informateur => id == informateur.Id));
    }

    public Task<int> Create(Informateur informateur)
    {
        if (Informateurs.Count > 0)
            informateur.Id = Informateurs.Last().Id + 1;
        else
            informateur.Id = 1;
        Informateurs.Add(informateur);
        return Task.FromResult(Informateurs.Last().Id);
    }

    public async Task<int> Update(int id, Informateur updatedInformateur)
    {
        var informateur = await GetOne(updatedInformateur.Id);
        var index = Informateurs.IndexOf(informateur);
        Informateurs[index] = new Informateur(informateur.Id, updatedInformateur.Nom, updatedInformateur.Prenom,
            updatedInformateur.Adresse, updatedInformateur.EstCalomniateur);
        return id;
    }

    public Task<bool> Delete(int id)
    {
        Informateurs.RemoveAll(informateur => id == informateur.Id);
        return Task.FromResult(true);
    }

    public Task<Informateur?> FindOne(Specification<Informateur> specification)
    {
        return Task.FromResult(Informateurs.FirstOrDefault(specification.IsSatisfiedBy));
    }
}