using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model;

public class Informateur : Personne
{
    
    public bool EstCalomniateur { get; set; }
    
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
}