using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model;

public class Personne: Entity
{
    public Nom Prenom { get; set; }
    public Nom Nom { get; set; }
    public Adresse Adresse { get; set; }

    public Personne(int id) : base(id)
    {
    }
}