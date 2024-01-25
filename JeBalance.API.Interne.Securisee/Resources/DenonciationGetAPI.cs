using JeBalance.Domain.Model;

namespace JeBalance.API.Interne.Securisee;

public class DenonciationGetAPI
{
    public DenonciationGetAPI()
    {
    }

    public DenonciationGetAPI(Denonciation denonciation, Informateur informateur, Suspect suspect)
    {
        DenonciationId = denonciation.Id;
        TypeDelit = denonciation.TypeDelit;
        PaysEvasion = denonciation.PaysEvasion;
        Informateur = new InformateurAPI(informateur);
        Suspect = new SuspectAPI(suspect);
    }

    // Informations de la dénonciation
    public Guid DenonciationId { get; set; }
    public TypeDelit TypeDelit { get; set; }
    public string? PaysEvasion { get; set; }

    // Information à propos de l'informateur 
    public InformateurAPI Informateur { get; set; }

    // Informations à propos du suspect
    public SuspectAPI Suspect { get; set; }
}