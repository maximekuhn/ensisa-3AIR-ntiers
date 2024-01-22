using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Tests.Drivers;

public class SuspectRepositoryDriver : SuspectRepository
{
    public List<Suspect> Suspects;

    public SuspectRepositoryDriver()
    {
        Suspects = new List<Suspect>();
    }

    public async Task<(IEnumerable<Suspect> Results, int Total)> Find(int limit, int offset,
        Specification<Suspect>? specification)
    {
        var suspects = Suspects.Where(specification.IsSatisfiedBy).Skip(offset).Take(limit);
        return (suspects, Suspects.Count);
    }

    public Task<Suspect> GetOne(int id)
    {
        return Task.FromResult(Suspects.First(suspect => id == suspect.Id));
    }

    public Task<int> Create(Suspect suspect)
    {
        if (Suspects.Count > 0)
            suspect.Id = Suspects.Last().Id + 1;
        else
            suspect.Id = 1;
        Suspects.Add(suspect);
        return Task.FromResult(Suspects.Last().Id);
    }

    public async Task<int> Update(int id, Suspect updatedSuspect)
    {
        var suspect = await GetOne(updatedSuspect.Id);
        var index = Suspects.IndexOf(suspect);
        Suspects[index] = new Suspect(updatedSuspect.Nom, updatedSuspect.Prenom, updatedSuspect.Adresse,
            updatedSuspect.Id);
        return id;
    }

    public Task<bool> Delete(int id)
    {
        Suspects.RemoveAll(suspect => id == suspect.Id);
        return Task.FromResult(true);
    }

    public Task<Suspect?> FindOne(Specification<Suspect> specification)
    {
        return Task.FromResult(Suspects.FirstOrDefault(specification.IsSatisfiedBy));
    }
}