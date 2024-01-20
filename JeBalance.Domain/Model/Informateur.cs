using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model;

public class Informateur : Personne
{
    public Informateur(int id) : base(id)
    {
    }

    public Informateur() : base(0)
    {
    }

    public Informateur(string nom, string prenom) : base(0)
    {
        Nom = new Nom(nom);
        Prenom = new Nom(prenom);
        EstCalomniateur = false;
    }

    public Informateur(Nom nom, Nom prenom, Adresse adresse, int id) : base(id)
    {
        Nom = nom;
        Prenom = Prenom;
        Adresse = adresse;
    }

    public bool EstCalomniateur { get; set; }
}