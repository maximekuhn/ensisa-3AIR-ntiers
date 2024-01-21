using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model;

public class VIP : Personne
{
    public VIP(int id) : base(id)
    {
    }

    public VIP() : base(0)
    {
    }

    public VIP(Nom nom, Nom prenom, Adresse adresse) : base(0)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
    }

    public VIP(Nom nom, Nom prenom, Adresse adresse, int id) : base(id)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
    }
}