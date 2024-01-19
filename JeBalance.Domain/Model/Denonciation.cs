using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

public class Denonciation : Entity
{
    public Denonciation(int id) : base(id)
    {
    }

    public Denonciation() : base(0)
    {
    }

    public Denonciation(TypeDelit typeDelit, string? paysEvasion, int informateurId, int suspectId) : base(0)
    {
        if (typeDelit == TypeDelit.EvasionFiscale && paysEvasion == null)
            throw new ApplicationException("Une infraction d'evasion fiscale doit avoir un pays d'evasion");
        TypeDelit = typeDelit;
        PaysEvasion = paysEvasion;
        Statut = StatutDenonciation.EnAttenteDeReponse;
        InformateurId = informateurId;
        SuspectId = suspectId;
    }

    public TypeDelit TypeDelit { get; }
    public string? PaysEvasion { get; }
    public DateTime Horodatage { get; }
    public StatutDenonciation Statut { get; }

    public int InformateurId { get; }
    public int SuspectId { get; }
    public int ReponseId { get; }
}