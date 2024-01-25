using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Interne.Securisee.Resources;

public class DenonciationGetAPI
{
    public DenonciationGetAPI()
    {
    }

    public DenonciationGetAPI(Denonciation denonciation, Informateur informateur, Suspect suspect)
    {
        Id = denonciation.Id;
        TypeDelit = denonciation.TypeDelit;
        PaysEvasion = denonciation.PaysEvasion;
        Horodatage = denonciation.Horodatage;
        Informateur = new InformateurAPI(informateur);
        Suspect = new SuspectAPI(suspect);
    }

    // Informations de la dénonciation
    [JsonPropertyName("id")] public Guid Id { get; set; }
    [JsonPropertyName("typeDelit")] public TypeDelit TypeDelit { get; set; }

    [JsonPropertyName("paysEvasion")] public string? PaysEvasion { get; set; }

    [JsonPropertyName("horodatage")] public DateTime Horodatage { get; set; }

    // Information à propos de l'informateur 
    [JsonPropertyName("informateur")] public InformateurAPI Informateur { get; set; }

    // Informations à propos du suspect
    [JsonPropertyName("suspect")] public SuspectAPI Suspect { get; set; }
}