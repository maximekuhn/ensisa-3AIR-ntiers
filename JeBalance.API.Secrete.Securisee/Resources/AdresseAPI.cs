using System.Text.Json.Serialization;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class AdresseAPI
{
    public AdresseAPI()
    {
    }

    public AdresseAPI(Adresse adresse)
    {
        NomCommune = adresse.NomCommune.Value;
        NomVoie = adresse.NomVoie.Value;
        NumeroVoie = adresse.NumeroVoieDeVoie.Value;
        CodePostal = adresse.CodePostal.Value;
    }
    [JsonPropertyName("nomCommune")] public string NomCommune { get; set; }

    [JsonPropertyName("nomVoie")] public string NomVoie { get; set; }

    [JsonPropertyName("numeroDeVoie")] public int NumeroVoie { get; set; }

    [JsonPropertyName("codePostal")] public int CodePostal { get; set; }
}