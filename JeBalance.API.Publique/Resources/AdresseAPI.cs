using System.Text.Json.Serialization;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Publique.Resources;

public class AdresseAPI
{
    public AdresseAPI()
    {
    }

    public AdresseAPI(Adresse source)
    {
        NomCommune = source.NomCommune.Value;
        NomVoie = source.NomVoie.Value;
        NumeroVoie = source.NumeroVoieDeVoie.Value;
        CodePostal = source.CodePostal.Value;
    }

    [JsonPropertyName("nomCommune")] public string NomCommune { get; set; }

    [JsonPropertyName("nomVoie")] public string NomVoie { get; set; }

    [JsonPropertyName("numeroDeVoie")] public int NumeroVoie { get; set; }

    [JsonPropertyName("codePostal")] public int CodePostal { get; set; }

    public Adresse ToAdresse()
    {
        return new Adresse(new NumeroVoie(NumeroVoie), new NomVoie(NomVoie),
            new CodePostal(CodePostal), new NomCommune(NomCommune));
    }
}