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

    public Informateur(Nom nom, Nom prenom, Adresse adresse) : base(0)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
    }
    
    public Informateur(Nom nom, Nom prenom, Adresse adresse, bool estCalomniateur) : base(0)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
        EstCalomniateur = estCalomniateur;
    }

    public Informateur(Nom nom, Nom prenom, Adresse adresse, int id) : base(id)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
    }

    public Informateur(int id, Nom nom, Nom prenom, Adresse adresse, bool estCalomniateur) : base(id)
    {
        Nom = nom;
        Prenom = prenom;
        Adresse = adresse;
        EstCalomniateur = estCalomniateur;
    }

    public bool EstCalomniateur { get; set; }
}