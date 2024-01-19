using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model;

public class Suspect : Personne
{
    public Suspect(int id) : base(id)
    {
    }

    public Suspect() : base(0)
    {
    }

    public Suspect(string prenom, string nom) : base(0)
    {
        Nom = new Nom(nom);
        Prenom = new Nom(nom);
    }
}