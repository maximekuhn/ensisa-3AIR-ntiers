using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

public class Denonciation : Entity
{
    public Denonciation(int id) : base(id)
    {
    }

    public Denonciation(TypeDelit typeDelit, string? paysEvasion) : base(0)
    {
        if (typeDelit == TypeDelit.EvasionFiscale && paysEvasion == null)
            throw new ApplicationException("Une infraction d'evasion fiscale doit avoir un pays d'evasion");
        TypeDelit = typeDelit;
        PaysEvasion = paysEvasion;
        Statut = StatutDenonciation.EnAttenteDeReponse;
    }

    public TypeDelit TypeDelit { get; }
    public string? PaysEvasion { get; }
    public StatutDenonciation Statut { get; }
}
