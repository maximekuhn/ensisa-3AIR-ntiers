using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.Model;

public class Denonciation : Entity<Guid>
{
    public Denonciation(Guid id) : base(id)
    {
    }

    public Denonciation() : base(Guid.Empty)
    {
    }

    public Denonciation(TypeDelit typeDelit, string? paysEvasion, int informateurId, int suspectId) : base(Guid.Empty)
    {
        if (typeDelit == TypeDelit.EvasionFiscale && paysEvasion == null)
            throw new ApplicationException("Une infraction d'evasion fiscale doit avoir un pays d'evasion");
        TypeDelit = typeDelit;
        PaysEvasion = paysEvasion;
        Statut = StatutDenonciation.EnAttenteDeReponse;
        InformateurId = informateurId;
        SuspectId = suspectId;
    }

    public TypeDelit TypeDelit { get; set; }
    public string? PaysEvasion { get; set; }
    public DateTime Horodatage { get; set; }
    public StatutDenonciation Statut { get; }

    public int InformateurId { get; set; }
    public int SuspectId { get; set; }
    public int ReponseId { get; set; }
}