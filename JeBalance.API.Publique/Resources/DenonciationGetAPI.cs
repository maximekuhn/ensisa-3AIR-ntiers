using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class DenonciationGetAPI
{
    public DenonciationGetAPI()
    {
    }

    public DenonciationGetAPI(Denonciation denonciation, Informateur informateur, Suspect suspect, Reponse? reponse)
    {
        TypeDelit = denonciation.TypeDelit;
        PaysEvasion = denonciation.PaysEvasion;
        Horodatage = denonciation.Horodatage;
        Informateur = new InformateurAPI(informateur);
        Suspect = new SuspectAPI(suspect);
        if (reponse != null)
            Reponse = new ReponseAPI(reponse);
    }

    // Informations de la dénonciation
    [JsonPropertyName("typeDelit")] public TypeDelit TypeDelit { get; set; }

    [JsonPropertyName("paysEvasion")] public string? PaysEvasion { get; set; }

    [JsonPropertyName("horodatage")] public DateTime Horodatage { get; set; }

    // Information à propos de l'informateur 
    [JsonPropertyName("informateur")] public InformateurAPI Informateur { get; set; }

    // Informations à propos du suspect
    [JsonPropertyName("suspect")] public SuspectAPI Suspect { get; set; }

    // Information à propos de la reponse
    [JsonPropertyName("reponse")] public ReponseAPI Reponse { get; set; }
}