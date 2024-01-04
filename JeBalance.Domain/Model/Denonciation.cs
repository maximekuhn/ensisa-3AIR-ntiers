using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

public class Denonciation : Entity
{
    public Denonciation(int id) : base(id)
    {
    }
    
    public Denonciation(): base(0) {}

    public Denonciation(TypeDelit typeDelit, string? paysEvasion, Informateur informateur, Suspect suspect) : base(0)
    {
        if (typeDelit == TypeDelit.EvasionFiscale && paysEvasion == null)
            throw new ApplicationException("Une infraction d'evasion fiscale doit avoir un pays d'evasion");
        TypeDelit = typeDelit;
        PaysEvasion = paysEvasion;
        Statut = StatutDenonciation.EnAttenteDeReponse;
        Informateur = informateur;
        Suspect = suspect;
    }

    public TypeDelit TypeDelit { get; }
    public string? PaysEvasion { get; }
    public StatutDenonciation Statut { get; }
    public Informateur Informateur { get; }
    public Suspect Suspect { get; }
 
    // TODO: add Reponse + Horodatage
}