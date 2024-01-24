using System.Text.Json.Serialization;
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
    [JsonPropertyName("typeDelit")] public TypeDelit TypeDelit { get; set; }

    [JsonPropertyName("paysEvasion")] public string? PaysEvasion { get; set; }

    // Information à propos de l'informateur 

    [JsonPropertyName("informateur")] public InformateurAPI Informateur { get; set; }

    // Informations à propos du suspect
    [JsonPropertyName("suspect")] public SuspectAPI Suspect { get; set; }
}