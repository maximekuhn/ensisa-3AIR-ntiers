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
        Prenom = new Nom(prenom);
    }

    public Suspect(Nom nom, Nom prenom, Adresse adresse, int id) : base(id)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
    }
}