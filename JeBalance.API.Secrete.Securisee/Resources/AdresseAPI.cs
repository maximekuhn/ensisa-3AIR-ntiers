using System.Text.Json.Serialization;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class AdresseAPI
{
    [JsonPropertyName("nomCommune")] public string NomCommune { get; set; }

    [JsonPropertyName("nomVoie")] public string NomVoie { get; set; }

    [JsonPropertyName("numeroDeVoie")] public int NumeroVoie { get; set; }

    [JsonPropertyName("codePostal")] public int CodePostal { get; set; }
}