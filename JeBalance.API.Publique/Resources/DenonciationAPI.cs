using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class DenonciationAPI
{
    public DenonciationAPI()
    {
        Informateur = new InformateurAPI();
        Suspect = new SuspectAPI();
    }


    public DenonciationAPI(Denonciation denonciation, Informateur informateur, Suspect suspect)
    {
        TypeDelit = denonciation.TypeDelit;
        PaysEvasion = denonciation.PaysEvasion;
        Informateur = new InformateurAPI(informateur);
        Suspect = new SuspectAPI(suspect);
    }

    // Informations de la dénonciation
    public TypeDelit TypeDelit { get; set; }
    public string? PaysEvasion { get; set; }

    // Information à propos de l'informateur 
    public InformateurAPI Informateur { get; set; }

    // Informations à propos du suspect
    public SuspectAPI Suspect { get; set; }
}